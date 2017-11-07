using Phishbait.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Phishbait
{
    class cPhishbait
    {
        public string Url;

        public bool Detected = false;
        bool IsTestEnvironment;
        int TestPassScore;

        public int LayerDetected = 0;

        public Dictionary<string, int> grdFreq;
        Dictionary<string, string> ConfigItems;

        PhishModel db;
        EFRepository Repository;

        public Resource Resource;

        public cPhishbait(Resource pResource, string paramUrl, Dictionary<string, string> Configuration, 
                            bool IgnoreLayer1, bool IgnoreLayer2, bool IgnoreLayer3,
                            bool IgnoreLayer4, bool IgnoreLayer5,
                            bool pIsTestEnvironment, int pTestPassScore)
        {
            db = new PhishModel();
            Repository = new EFRepository(db);

            Resource = pResource;

            ConfigItems = Configuration;

            IsTestEnvironment = pIsTestEnvironment;

            TestPassScore = pTestPassScore;

            Url = paramUrl;

            grdFreq = new Dictionary<string, int>();

            if (!IgnoreLayer1)
            {
                Detected = Layer1(Resource);
            }

            if (!Detected && !IgnoreLayer2)
                Detected = Layer2(Resource);

            if (!Detected && !IgnoreLayer3)
                Detected = Layer3(Resource);

            if (!Detected && !IgnoreLayer4)
                Detected = Layer4(Resource);

            if (!Detected && !IgnoreLayer5)
                Detected = Layer5(Resource);
        }

        //Check if website is in whitelist
        public bool Layer1(Resource Resource)
        {
            if (Resource.ItemType == PhishDataType.Positive)
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
        public bool Layer2(Resource Resource)
        {
            if (Resource.ItemType == PhishDataType.Negative)
            {
                LayerDetected = 2;
                return true;
            }
            else
            {
                return false;
            }

        }

        //Layer 3 - URL-Based Features
        public bool Layer3(Resource Resource)
        {
            int DigitCount = Resource.Url.Count(char.IsDigit);

            int URLLength = Resource.Url.Length;

            int NumberOfSubDomains = 0;

            bool CommonTLD = false;

            string Url = Resource.Url;

            if (Url.StartsWith("http://"))
                Url = Url.Substring("http://".Length);

            if (Url.StartsWith("https://"))
                Url = Url.Substring("https://".Length);

            if (Url.EndsWith(".php"))
                Url = Url.Substring(0, Url.Length - 4);

            if (Url.EndsWith(".html"))
                Url = Url.Substring(0, Url.Length - 5);

            if (Url.EndsWith(".htm"))
                Url = Url.Substring(0, Url.Length - 5);

            List<string> SplitUrl = Url.Split('.').ToList();

            TldList ls = new TldList();

            //Checking for TLD and removing it so that subdomains can be traced
            if (SplitUrl.Count > 1)
            {
                if (SplitUrl[SplitUrl.Count - 1].Contains('/'))
                    SplitUrl[SplitUrl.Count - 1] = SplitUrl[SplitUrl.Count - 1].Substring(0, SplitUrl[SplitUrl.Count - 1].IndexOf("/"));

                string LastTwo = SplitUrl[SplitUrl.Count - 2] + "." + SplitUrl[SplitUrl.Count - 1];

                if (ls.Exact.Any(s => s == LastTwo) || ls.UnderCombined.Any(s => s == LastTwo))
                {
                    CommonTLD = true;
                    SplitUrl.RemoveAt(SplitUrl.Count - 1);
                    SplitUrl.RemoveAt(SplitUrl.Count - 1);
                }
                else if (ls.Exact.Any(s => s == SplitUrl[SplitUrl.Count - 1]) || ls.UnderCombined.Any(s => s == SplitUrl[SplitUrl.Count - 1]))
                {
                    CommonTLD = true;
                    SplitUrl.RemoveAt(SplitUrl.Count - 1);
                }
            }

            NumberOfSubDomains = SplitUrl.Count - 1;

            double OverallUrl = 0;

            if (DigitCount > 0) //Convert.ToInt32(ConfigItems["DigitCount"])
                OverallUrl += 1;// Convert.ToInt32(ConfigItems["DigitCount"]);

            if (Resource.NumberOfFullStops > Convert.ToInt32(ConfigItems["FullStops"]))
            {
                double Mod = Math.Round((double)(Resource.NumberOfFullStops - Convert.ToInt32(ConfigItems["FullStops"])) / Convert.ToInt32(ConfigItems["FullStops"]), 2);
                var x = (Convert.ToInt32(ConfigItems["FullStopsW"]) * Mod);
                OverallUrl += x;
            }

            //Resource.SetDetectionVariables();

            double PassScore = 0;

            if (!IsTestEnvironment)
            {
                PassScore = Convert.ToDouble(ConfigItems["Layer3Pass"]);
            }

            if (OverallUrl >= PassScore)
            {
                LayerDetected = 3;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Layer 4 - Domain-Based Features
        public bool Layer4(Resource Resource)
        {
            bool HasIPAddress = false;
            int DaysSinceDomainRegistered = 0;
            bool RegistrantNameHidden = false;

            return true;
        }

        //Layer 5 - Page-Based Features
        public bool Layer5(Resource Resource)
        {
            int GlobalPagerank = 0;
            int CountryPagerank = 0;

            //Estimated number of visit for the domain ın a daily, weekly, or monthly basis
            // Average Pageviews per visit
            //Average Visit Duration
            //Web traffic share per country
            return true;
        }
    }
}
