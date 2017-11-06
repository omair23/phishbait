using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Phishbait
{
    public class Algorithms : BaseClass
    {

        public static double MinusFunction(double A, double B)
        {
            if (A > B)
                return A - B;
            else
                return B - A;
        }

        
        public string SourceCodeGet(string Url)
        {
            string urlAddress = "http://google.com";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            return "";
        }

        public void ColdStartDb()
        {
            //Configuration Model

            List<Configuration> ExistingConfigs = Repository.GetAll<Configuration>().ToList();
            Repository.DeleteMultiple(ExistingConfigs);

            List<Configuration> Configs = new List<Configuration>();
            Configs.Add(new Configuration("FrequentItems_MinimumLength", "3"));
            Configs.Add(new Configuration("FrequentItems_Confidence", "3"));
            Configs.Add(new Configuration("UrlAnalysisWeight", "50"));
            Configs.Add(new Configuration("UrlFqWeight", "50"));
            Configs.Add(new Configuration("PassValue", "50"));

            Repository.AddMultiple(Configs);
        }
    }
}
