using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Phishbait.Classes;

namespace Phishbait
{
    public enum Source
    {
        File,
        Online,
        Query
    };

    public enum PhishDataType
    {
        Undefined,
        Positive,
        Negative
    }

    public partial class Resource: AuditableEntity
    {
        public Resource()
        {

        }

        public Resource(string ParamUrl)
        {
            Url = ParamUrl;
        }

        public string Url { get; set; }

        public int LayerDetected { get; set; }

        public string PageContent { get; set; }

        public PhishDataType ItemType { get; set; }

        //////
        ///Layer3
        public int DigitCount { get; set; } = 0;

        public int URLLength { get; set; } = 0;

        public int NumberOfSubDomains { get; set; } = 0;

        public bool CommonTLD { get; set; } = false;

        /////

        /////Layer4
        public bool HasIPAddress { get; set; }

        public bool RegistrantNameHidden { get; set; }

        public int DaysSinceDomainRegistered { get; set; }

        /////

        public bool HasPortNumber { get; set; }

        public bool HasHttps { get; set; }

        public bool HasValidSSL { get; set; }

        public bool IsBadHttps { get; set; }

        public bool DetectionAnalysisConducted { get; set; }

        public void SetDetectionVariables()
        {
            //---------------Layer3--------------------------//
            DigitCount = Url.Count(char.IsDigit);
            URLLength = Url.Length;

            /*string EditedUrl = Url;

            if (EditedUrl.StartsWith("http://"))
                EditedUrl = EditedUrl.Substring("http://".Length);

            if (EditedUrl.StartsWith("https://"))
                EditedUrl = EditedUrl.Substring("https://".Length);

            if (EditedUrl.EndsWith(".php"))
                EditedUrl = EditedUrl.Substring(0, EditedUrl.Length - 4);

            if (EditedUrl.EndsWith(".html"))
                EditedUrl = EditedUrl.Substring(0, EditedUrl.Length - 5);

            if (EditedUrl.EndsWith(".htm"))
                EditedUrl = EditedUrl.Substring(0, EditedUrl.Length - 4);

            List<string> SplitUrl = EditedUrl.Split('.').ToList();

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
            */
            //---------------End Layer3--------------------------//

            HasIPAddress = Regex.Match(Url, @"\b(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\b").Success;

            HasPortNumber = Regex.Match(Url, @"\b(:\d{1,5})\b").Success;

            HasHttps = Regex.Match(Url, "https://").Success;

            DetectionAnalysisConducted = true;

            if (HasHttps)
            {
                ////Test to see if site has valid(non-expired) SSL Certificate 
                //try
                //{
                //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                //    //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //    //response.Close();
                //    X509Certificate cert = request.ServicePoint.Certificate;
                //    X509Certificate2 cert2 = new X509Certificate2(cert);
                //    DateTime ExpiryDate = Convert.ToDateTime(cert2.GetExpirationDateString());

                //    if (ExpiryDate > DateTime.Now)
                //        HasValidSSL = true;
                //}
                //catch (Exception ex)
                //{
                //    HasValidSSL = false;
                //}
            }

            if (HasHttps && !HasValidSSL)
                IsBadHttps = true;
        }


    }

}
