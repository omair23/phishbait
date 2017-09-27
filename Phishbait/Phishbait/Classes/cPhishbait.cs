using BayesClassifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Phishbait
{
    class cPhishbait
    {
        public string Url;
        public Resource Resource;

        public bool Detected = false;

        public int LayerDetected = 0;
        int PassScore1;

        public Dictionary<string, int> grdFreq;
        public Dictionary<string, double> BayesScore;
        Dictionary<string, string> ConfigItems;

        Classifier m_Classifier;
        PhishModel db;
        EFRepository Repository;

        public cPhishbait(string paramUrl, Dictionary<string, string> Configuration, 
                            bool IgnoreLayer1, bool IgnoreLayer2, bool IgnoreLayer3,
                            bool IgnoreLayer4, bool IgnoreLayer5,
                            int Score1)
        {
            db = new PhishModel();
            Repository = new EFRepository(db);

            PassScore1 = Score1;
            ConfigItems = Configuration;

            Url = paramUrl;

            grdFreq = new Dictionary<string, int>();

            Resource = Repository.Find<Resource>(s => s.Url == Url).FirstOrDefault();

            if (Resource == null)
            {
                Resource = new Resource(Url);
            }

            if (!IgnoreLayer1)
            {
                Detected = Layer1();
            }

            if (!Detected && !IgnoreLayer2)
                Detected = Layer2();

            if (!Detected && !IgnoreLayer3)
                Detected = Layer3();

            if (!Detected && !IgnoreLayer4)
                Detected = Layer4();

            if (!Detected && !IgnoreLayer5)
                Detected = Layer5();
        }

        //Check if website is in whitelist
        public bool Layer1()
        {
            Resource WhiteListItem = Repository
                                        .Find<Resource>(s => s.Url == Url
                                                        && s.ItemType == PhishDataType.Positive)
                                        .FirstOrDefault();

            if (WhiteListItem != null)
            {
                LayerDetected = 1;
                return true;
            }
            else
            {
                return false;
            }

        }

        //Check if website is in blacklist
        public bool Layer2()
        {
            Resource BlackListItem = Repository
                                        .Find<Resource>(s => s.Url == Url
                                                        && s.ItemType == PhishDataType.Negative)
                                        .FirstOrDefault();

            if (BlackListItem != null)
            {
                LayerDetected = 2;
                return true;
            }
            else
            {
                return false;
            }

        }

        //Check heuristic elements of URL
        public bool Layer3()
        {
            Resource.SetDetectionVariables();

            double OverallUrl = 0;

            if (Resource.IsBadHttps)
                OverallUrl += Convert.ToInt32(ConfigItems["InvalidHttpsW"]);

            if (Resource.HasPortNumber)
                OverallUrl += Convert.ToInt32(ConfigItems["PortNumbersW"]);

            if (Resource.HasIPAddress)
                OverallUrl += Convert.ToInt32(ConfigItems["IPAddressW"]);

            if (Resource.NumberOfFullStops > Convert.ToInt32(ConfigItems["FullStops"]))
            {
                double Mod = Math.Round((double)(Resource.NumberOfFullStops - Convert.ToInt32(ConfigItems["FullStops"])) / Convert.ToInt32(ConfigItems["FullStops"]), 2);
                var x = (Convert.ToInt32(ConfigItems["FullStopsW"]) * Mod);
                OverallUrl += x;
            }
            
            if (Resource.NumberOfAtSymbols > Convert.ToInt32(ConfigItems["AtSymbols"]))
            {
                var x = (Convert.ToInt32(ConfigItems["AtSymbolsW"]) * Resource.NumberOfAtSymbols);
                OverallUrl += x;
            }  

            if (Resource.NumberOfForwardSlashes > Convert.ToInt32(ConfigItems["ForwardSlashes"]))
            {
                var x = (Convert.ToInt32(ConfigItems["ForwardSlashesW"]) * (Resource.NumberOfForwardSlashes - 1));
                OverallUrl += x;
            }
                 
            if (Resource.NumberOfMultipleForwardSlashes > Convert.ToInt32(ConfigItems["MultipleForwardSlashes"]))
            {
                var x = (Convert.ToInt32(ConfigItems["MultipleForwardSlashesW"]) * Resource.NumberOfMultipleForwardSlashes);
                OverallUrl += x;
            }
                

            if (OverallUrl >= Convert.ToDouble(ConfigItems["HeuristicPassScore"])) //Pass Score
            {
                LayerDetected = 3;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Check string of URL for frequent items
        public bool Layer4()
        {
            //Cleaning URL
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            String StrippedUrl = rgx.Replace(Url, " ");
            var SplitUrl = StrippedUrl.Split(null).ToList();
            SplitUrl.RemoveAll(item => String.IsNullOrWhiteSpace(item) || String.IsNullOrEmpty(item));

            List<FrequentItem> PositiveFrequentItems = Repository
                                                .Find<FrequentItem>(s => s.ItemType == PhishDataType.Positive)
                                                .ToList();

            List<FrequentItem> NegativeFrequentItems = Repository
                                                .Find<FrequentItem>(s => s.ItemType == PhishDataType.Negative)
                                                .ToList();


            List<IgnoreRule> IgnoreRules = Repository
                                            .Find<IgnoreRule>(s => s.Type == IgnoreType.FrequentItem)
                                            .ToList();

            List<string> PositiveNonUnion = PositiveFrequentItems
                            .Select(s => s.Term)
                            .Intersect(SplitUrl)
                            .Except(IgnoreRules.Select(x => x.Term))
                            .ToList();

            List<string> UnionItems = NegativeFrequentItems
                            .Select(s => s.Term)
                            .Intersect(SplitUrl)
                            .Except(IgnoreRules.Select(x => x.Term))
                            //Perhaps reconsider
                            .Except(PositiveNonUnion)
                            .ToList();

            int TotalRecords = SplitUrl.Count - PositiveNonUnion.Count;
            int ProbabilityCounter = 0;

            grdFreq.Clear();

            foreach (var item in UnionItems)
            {
                FrequentItem fitem = NegativeFrequentItems.Where(s => s.Term == item).FirstOrDefault();
                grdFreq.Add(item, fitem.Frequency);
                ProbabilityCounter += 1;// fitem.Frequency;
            }

            if (TotalRecords > 0)
                ProbabilityCounter = ProbabilityCounter * 100 / TotalRecords;
            else
                ProbabilityCounter = 0;

            Resource.UrlFrequentPercentage = ProbabilityCounter;

            if (ProbabilityCounter >= 40) //Pass score
            {
                LayerDetected = 4;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Bayesian Classification of URL
        public bool Layer5()
        {
            m_Classifier = new Classifier();

            var GoodUrls = Repository
                            .Find<Resource>(s => s.ItemType == PhishDataType.Positive)
                            .Select(x => x.Url)
                            .ToList();

            var BadUrls = Repository
                            .Find<Resource>(s => s.ItemType == PhishDataType.Negative)
                            .Select(x => x.Url)
                            .ToList();

            //Even out the lists so that the results aren't skewed by sample sizes
            BadUrls = BadUrls.Take(GoodUrls.Count).ToList();

            m_Classifier.TeachCategoryList("Phishing", BadUrls);

            m_Classifier.TeachCategoryList("Non Phishing", GoodUrls);

            BayesScore = m_Classifier.Classify(Url);

            double sc = BayesScore["Phishing"];

            if (BayesScore["Phishing"] < BayesScore["Non Phishing"])
            {
                LayerDetected = 5;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
