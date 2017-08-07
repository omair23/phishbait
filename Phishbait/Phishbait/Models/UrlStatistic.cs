using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Phishbait
{
    public enum StatisticType
    {
        GoodSites,
        BadSites,
        Overall
    }

    public partial class UrlStatistic : AuditableEntity
    {
        public StatisticType Type { get; set; }

        public double FullStopAverage { get; set; }

        public double AtSymbolsAverage { get; set; }

        public double ForwardSlashAverage { get; set; }

        public double MultipleForwardSlashAverage { get; set; }

        public double AverageIPAddress { get; set; }

        public double AveragePortNumbers { get; set; }

        public double AverageBadHttps { get; set; }

        public UrlStatistic()
        {

        }

        public UrlStatistic(StatisticType PType)
        {
            Type = PType;
        }

        public UrlStatistic(List<Resource> Sites, StatisticType PType)
        {
            Type = PType;

            if (Sites.Count > 0)
            {
                foreach (var item in Sites)
                {
                    item.SetDetectionVariables();
                }

                FullStopAverage = Math.Round(Sites.Average(s => s.NumberOfFullStops), 4);
                AtSymbolsAverage = Math.Round(Sites.Average(s => s.NumberOfAtSymbols), 4);
                ForwardSlashAverage = Math.Round(Sites.Average(s => s.NumberOfForwardSlashes), 4);
                MultipleForwardSlashAverage = Math.Round(Sites.Average(s => s.NumberOfMultipleForwardSlashes), 4);

                AverageIPAddress = Math.Round(Sites.Average(s => Convert.ToInt16(s.HasIPAddress)), 4);
                AveragePortNumbers = Math.Round(Sites.Average(s => Convert.ToInt16(s.HasPortNumber)), 4);

                AverageBadHttps = Math.Round((double)Sites
                                .Where(s => s.HasHttps && !s.HasValidSSL)
                                .Count() / Sites.Count(), 4);
            }


        }
        
    }
}
