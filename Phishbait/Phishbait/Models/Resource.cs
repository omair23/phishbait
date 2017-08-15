using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Phishbait
{
    public enum Source
    {
        File,
        Online,
        Query
    };

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

        public string PageContent { get; set; }

        public PhishDataType ItemType { get; set; }

        //System Generated/Calculated Values

        public double UrlAnalysisPercentage { get; set; }

        public double UrlFrequentPercentage { get; set; }

        public double OverallRiskPercentage { get; set; }

        ////////////////////////////////////

        public bool IsPhishing { get; set; }

        public Source ResourceSource { get; set; }

        //DetectionVariables

        public int NumberOfFullStops { get; set; }

        public int NumberOfAtSymbols { get; set; }

        public int NumberOfForwardSlashes { get; set; }

        public int NumberOfMultipleForwardSlashes { get; set; }

        public bool HasIPAddress { get; set; }

        public bool HasPortNumber { get; set; }

        public bool HasHttps { get; set; }

        public bool HasValidSSL { get; set; }

        public bool IsBadHttps { get; set; }

        public bool DetectionAnalysisConducted { get; set; }

        public void SetDetectionVariables()
        {
            NumberOfAtSymbols = Url.Count(f => f == '@');
            NumberOfFullStops = Url.Count(f => f == '.');

            NumberOfForwardSlashes = Regex.Matches(Url, "//").Count;

            NumberOfMultipleForwardSlashes = Regex.Matches(Url, "///").Count;

            HasIPAddress = Regex.Match(Url, @"\b(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\b").Success;

            if (HasIPAddress)
                NumberOfFullStops = NumberOfFullStops - 3;

            HasPortNumber = Regex.Match(Url, @"\b(:\d{1,5})\b").Success;

            HasHttps = Regex.Match(Url, "https://").Success;

            DetectionAnalysisConducted = true;

            if (HasHttps)
            {
                //Test to see if site has valid(non-expired) SSL Certificate 
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                    //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    //response.Close();
                    X509Certificate cert = request.ServicePoint.Certificate;
                    X509Certificate2 cert2 = new X509Certificate2(cert);
                    DateTime ExpiryDate = Convert.ToDateTime(cert2.GetExpirationDateString());

                    if (ExpiryDate > DateTime.Now)
                        HasValidSSL = true;
                }
                catch (Exception ex)
                {
                    HasValidSSL = false;
                }
            }

            if (HasHttps && !HasValidSSL)
                IsBadHttps = true;
        }


    }

}
