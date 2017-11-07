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

            //Url = paramUrl;

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
            double DigitPhishing = 7.82;
            double DigitDelta = 6.37;
            double DigitDeltaHalved = DigitPhishing - (DigitDelta / 2);

            double URLPhishing = 75.28;
            double URLDelta = 21.51;
            double URLDeltaHalved = URLPhishing - (URLDelta / 2);

            Resource.SetDetectionVariables();

            double OverallUrl = 0;

            if (Resource.DigitCount >= DigitDeltaHalved)
                OverallUrl += 1;

            if (Resource.URLLength >= URLDeltaHalved)
                OverallUrl += 1;

            double FailScore = 0;

            if (OverallUrl > FailScore)
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
            double OverallUrl = 0;

            if (Resource.HasIPAddress)
                OverallUrl += 1;

            if (Resource.DaysSinceDomainRegistered >= 0)
                OverallUrl += 1;

            if (Resource.RegistrantNameHidden)
                OverallUrl += 1;

            double FailScore = 0;

            if (OverallUrl > FailScore)
            {
                LayerDetected = 4;
                return true;
            }
            else
            {
                return false;
            }

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
