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
        #region FrequentItems
        public void FrequentItemCounter(PhishDataType Type,
                                        int FrequentItems_MinimumLength,
                                        int FrequentItems_Confidence)
        {
            List<string> Urls;

            List<String> UrlsCleaned = new List<string>();

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            Urls = Repository
                    .Find<Resource>(s => s.ItemType == Type)
                    .Select(a => a.Url)
                    .ToList();

            foreach (var record in Urls)
            {
                String result = Regex.Replace(record, @"\p{P}", " ");
                result = Regex.Replace(result, @"[\d-]", " ");
                result = result.Replace("=", " ");
                UrlsCleaned.Add(result);
            }

            foreach (var item in UrlsCleaned)
            {
                var line = item.ToLower().Trim();
                var words = line.Split(' ');

                foreach (var word in words)
                {
                    if (String.IsNullOrEmpty(word) || word.Length < FrequentItems_MinimumLength)
                        continue;

                    if (!dictionary.ContainsKey(word))
                    {
                        dictionary.Add(word, 1);
                    }
                    else
                    {
                        dictionary[word] = dictionary[word] + 1;
                    }
                }

            }

            List<FrequentItem> FrequentItems = Repository
                                                .Find<FrequentItem>(s => s.ItemType == Type)
                                                .ToList();

            List<FrequentItem> NewFrequentItems = new List<FrequentItem>();

            List<FrequentItem> UpdateFrequentItems = new List<FrequentItem>();

            foreach (var item in dictionary)
            {
                if (item.Value < FrequentItems_Confidence)
                    continue;

                if (FrequentItems.Any(s => s.Term == item.Key))
                {
                    FrequentItem UItem = FrequentItems.Where(s => s.Term == item.Key).FirstOrDefault();
                    UItem.MinimumFrequency = FrequentItems_MinimumLength;
                    UItem.Frequency = item.Value;
                    UItem.ItemType = Type;
                    UpdateFrequentItems.Add(UItem);
                }
                else
                {
                    FrequentItem UItem = new FrequentItem();
                    UItem.Term = item.Key;
                    UItem.ItemType = Type;
                    UItem.MinimumFrequency = FrequentItems_MinimumLength;
                    UItem.Frequency = item.Value;
                    NewFrequentItems.Add(UItem);
                }
            }

            Repository.AddMultiple(NewFrequentItems);
            Repository.UpdateMultiple(UpdateFrequentItems);
        }
        #endregion

        #region URLStatistics
        public void UrlStatsCalc()
        {
            List<Resource> BadSiteList = Repository
                                    .Find<Resource>
                                    (s => s.ItemType == PhishDataType.Negative)
                                    .ToList();

            UrlStatistic BadSites = new UrlStatistic(BadSiteList, StatisticType.BadSites);

            List<Resource> GoodSiteList = Repository
                                    .Find<Resource>(s => s.ItemType == PhishDataType.Positive)
                                    .ToList();

            UrlStatistic GoodSites = new UrlStatistic(GoodSiteList, StatisticType.GoodSites);

            UrlStatistic CombinedStats = OverallStatsCalc(BadSites, GoodSites);

            List<UrlStatistic> ExistingStats = Repository.GetAll<UrlStatistic>().ToList();
            Repository.DeleteMultiple(ExistingStats);

            List<UrlStatistic> NewStats = new List<UrlStatistic>();
            NewStats.Add(BadSites);
            NewStats.Add(GoodSites);
            NewStats.Add(CombinedStats);
            Repository.AddMultiple(NewStats);
        }

        public static UrlStatistic OverallStatsCalc(UrlStatistic BadSites, UrlStatistic GoodSites)
        {
            UrlStatistic Stat = new UrlStatistic(StatisticType.Overall);

            Stat.AtSymbolsAverage = BadSites.AtSymbolsAverage - GoodSites.AtSymbolsAverage;
            Stat.AverageBadHttps = BadSites.AverageBadHttps - GoodSites.AverageBadHttps;

            Stat.AverageIPAddress = BadSites.AverageIPAddress - GoodSites.AverageIPAddress;
            Stat.AveragePortNumbers = BadSites.AveragePortNumbers - GoodSites.AveragePortNumbers;

            Stat.ForwardSlashAverage = BadSites.ForwardSlashAverage - GoodSites.ForwardSlashAverage;
            Stat.FullStopAverage = BadSites.FullStopAverage - GoodSites.FullStopAverage;

            Stat.MultipleForwardSlashAverage = BadSites.MultipleForwardSlashAverage - GoodSites.MultipleForwardSlashAverage;


            return Stat;
        }
        #endregion

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
    }
}
