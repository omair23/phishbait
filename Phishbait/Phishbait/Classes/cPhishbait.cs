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

        public bool Detected = false;
        bool IsTestEnvironment;

        public int LayerDetected = 0;
        int HeurScore;
        int FreqScore;

        public Dictionary<string, int> grdFreq;
        Dictionary<string, string> ConfigItems;

        PhishModel db;
        EFRepository Repository;

        public Resource Resource;

        public cPhishbait(Resource pResource, string paramUrl, Dictionary<string, string> Configuration, 
                            bool IgnoreLayer1, bool IgnoreLayer2, bool IgnoreLayer3,
                            bool IgnoreLayer4, bool IgnoreLayer5,
                            int pHeurScore, int pFreqScore, bool pIsTestEnvironment)
        {
            db = new PhishModel();
            Repository = new EFRepository(db);

            Resource = pResource;

            HeurScore = pHeurScore;
            FreqScore = pFreqScore;

            ConfigItems = Configuration;

            Url = paramUrl;

            grdFreq = new Dictionary<string, int>();

            if (!IgnoreLayer1)
            {
                Detected = Layer1(Resource);
            }

            if (!Detected && !IgnoreLayer2)
                Detected = Layer2(Resource);

            if (!Detected && !IgnoreLayer3)
                Detected = Layer3();

            if (!Detected && !IgnoreLayer4)
                Detected = Layer4();
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


            double PassScore = HeurScore;

            if (!IsTestEnvironment)
            {
                PassScore = Convert.ToDouble(ConfigItems["HeuristicPassScore"]);
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

        //Check string of URL for frequent items
        public bool Layer4()
        {
            return true;
        }
        
    }
}
