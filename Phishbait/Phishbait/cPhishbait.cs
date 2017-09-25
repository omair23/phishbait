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

        public Dictionary<string, int> grdFreq;
        public Dictionary<string, double> BayesScore;

        Classifier m_Classifier;
        PhishModel db;
        EFRepository Repository;

        public cPhishbait(string paramUrl)
        {
            db = new PhishModel();
            Repository = new EFRepository(db);

            Url = paramUrl;

            grdFreq = new Dictionary<string, int>();

            Resource = Repository.Find<Resource>(s => s.Url == Url).FirstOrDefault();

            if (Resource == null)
            {
                Resource = new Resource(Url);
            }

            Detected = Layer1();

            if (!Detected)
                Detected = Layer2();

            if (!Detected)
                Detected = Layer3();

            if (!Detected)
                Detected = Layer4();

            if (!Detected)
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
                OverallUrl += 14.28;

            if (Resource.HasPortNumber)
                OverallUrl += 14.28;

            if (Resource.HasIPAddress)
                OverallUrl += 14.28;

            if (Resource.NumberOfFullStops > 2)
            {
                double Mod = (Resource.NumberOfFullStops - 2) / 2;
                double FlooredMod = Convert.ToInt32(Math.Floor(Mod));
                OverallUrl += (14.28 * FlooredMod);
            }
            
            if (Resource.NumberOfAtSymbols > 0)
                OverallUrl += (14.28 * Resource.NumberOfAtSymbols);

            if (Resource.NumberOfForwardSlashes > 1)
                OverallUrl += (14.28 * Resource.NumberOfForwardSlashes);

            if (Resource.NumberOfMultipleForwardSlashes > 0)
                OverallUrl += (14.28 * Resource.NumberOfMultipleForwardSlashes);

            if (OverallUrl > 40) //Pass Score
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
