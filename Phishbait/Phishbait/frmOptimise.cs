using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class frmOptimise : Form
    {
        PhishModel db;
        EFRepository Repository;

        public frmOptimise()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            DrawChart();
        }

        public void DrawChart()
        {
            chart1.ChartAreas[0].AxisY.Maximum = 10;

            var PhishingSites = Repository
                                .Find<Resource>(s => s.ItemType == PhishDataType.Negative)
                                .Take(100000)
                                .ToList();

            var PhishingFullStops = PhishingSites.Select(s => s.NumberOfFullStops).ToArray();
            chart1.Series[0].Name = "Number of Fullstops";
            chart1.Series[0].Points.DataBindY(PhishingFullStops);
            var FullStops = Math.Round(PhishingSites.Average(s => s.NumberOfFullStops));

            var PhishingForwardSlashes = PhishingSites.Select(s => s.NumberOfForwardSlashes).ToArray();
            chart1.Series.Add("Forward Slashes");
            chart1.Series[1].Name = "Number of Forward Slashes";
            chart1.Series[1].Points.DataBindY(PhishingForwardSlashes);
            var ForwardSlashes = Math.Round(PhishingSites.Average(s => s.NumberOfForwardSlashes));

            var PhishingAtSymbols = PhishingSites.Select(s => s.NumberOfAtSymbols).ToArray();
            chart1.Series.Add("At Symbols");
            chart1.Series[2].Name = "Number of At Symbols";
            chart1.Series[2].Points.DataBindY(PhishingAtSymbols);
            var AtSymbols = Math.Round(PhishingSites.Average(s => s.NumberOfAtSymbols));

            var PhishingIPAddresses = PhishingSites.Select(s => s.HasIPAddress).ToArray();
            chart1.Series.Add("IP Address");
            chart1.Series[3].Name = "IP Address";
            chart1.Series[3].Points.DataBindY(PhishingIPAddresses);
            var IPAddresses = Math.Round(PhishingSites.Average(s => Convert.ToInt16(s.HasIPAddress)));

            var PhishingPortNumber = PhishingSites.Select(s => s.HasPortNumber).ToArray();
            chart1.Series.Add("Port Numbers");
            chart1.Series[4].Name = "Port Numbers";
            chart1.Series[4].Points.DataBindY(PhishingPortNumber);
            var PortNumbers = Math.Round(PhishingSites.Average(s => Convert.ToInt16(s.HasPortNumber)));

            var MultipleForwardSlashes = PhishingSites.Select(s => s.NumberOfMultipleForwardSlashes).ToArray();
            chart1.Series.Add("Multiple Forward Slashes");
            chart1.Series[5].Name = "Multiple Forward Slashes";
            chart1.Series[5].Points.DataBindY(MultipleForwardSlashes);
            var MultipleFSlashes = Math.Round(PhishingSites.Average(s => Convert.ToInt16(s.NumberOfMultipleForwardSlashes)));

            var InvalidHttpsArray = PhishingSites.Select(s => s.IsBadHttps).ToArray();
            chart1.Series.Add("Invalid Https");
            chart1.Series[6].Name = "Invalid Https";
            chart1.Series[6].Points.DataBindY(InvalidHttpsArray);
            var InvalidHttps = Math.Round(PhishingSites.Average(s => Convert.ToInt16(s.IsBadHttps)));

            listBox1.Items.Add("Full Stops: " + FullStops.ToString());
            listBox1.Items.Add("Forward Slashes: " + ForwardSlashes.ToString());
            listBox1.Items.Add("Multiple Forward Slashes: " + MultipleFSlashes.ToString());
            listBox1.Items.Add("At Symbols: " + AtSymbols.ToString());
            listBox1.Items.Add("IP Address: " + IPAddresses.ToString());
            listBox1.Items.Add("Port Numbers: " + PortNumbers.ToString());
            listBox1.Items.Add("Invalid Https: " + InvalidHttps.ToString());

            List<Configuration> ConfigItems = new List<Configuration>();

            ConfigItems.Add(new Configuration("FullStops", FullStops.ToString()));
            ConfigItems.Add(new Configuration("ForwardSlashes", ForwardSlashes.ToString()));
            ConfigItems.Add(new Configuration("MultipleForwardSlashes", MultipleFSlashes.ToString()));
            ConfigItems.Add(new Configuration("AtSymbols", AtSymbols.ToString()));
            ConfigItems.Add(new Configuration("IPAddress", IPAddresses.ToString()));
            ConfigItems.Add(new Configuration("PortNumbers", PortNumbers.ToString()));
            ConfigItems.Add(new Configuration("InvalidHttps", InvalidHttps.ToString()));

            /*
            Config Items
            -------------

            Values:
            FullStops
            ForwardSlashes
            MultipleForwardSlashes
            AtSymbols
            IPAddress
            PortNumbers
            InvalidHttps

            Weights:
            FullStopsW
            ForwardSlashesW
            MultipleForwardSlashesW
            AtSymbolsW
            IPAddressW
            PortNumbersW
            InvalidHttpsW
             
             */

            int HttpsWeight = PhishingSites.Where(s => s.NumberOfFullStops <= 2
                                                    && s.NumberOfForwardSlashes <= 1
                                                    && s.NumberOfMultipleForwardSlashes < 1
                                                    && s.NumberOfAtSymbols < 1
                                                    && s.HasIPAddress == false
                                                    && s.HasPortNumber == false
                                                    && s.IsBadHttps == true)
                                                    .Count();

            int PortsWeight = PhishingSites.Where(s => s.NumberOfFullStops <= 2
                                                    && s.NumberOfForwardSlashes <= 1
                                                    && s.NumberOfMultipleForwardSlashes < 1
                                                    && s.NumberOfAtSymbols < 1
                                                    && s.HasIPAddress == false
                                                    && s.HasPortNumber == true
                                                    && s.IsBadHttps == false)
                                                    .Count();

            int IPWeight = PhishingSites.Where(s => s.NumberOfFullStops <= 2
                                                    && s.NumberOfForwardSlashes <= 1
                                                    && s.NumberOfMultipleForwardSlashes < 1
                                                    && s.NumberOfAtSymbols < 1
                                                    && s.HasIPAddress == true
                                                    && s.HasPortNumber == false
                                                    && s.IsBadHttps == false)
                                                    .Count();

            int AtSymbolWeight = PhishingSites.Where(s => s.NumberOfFullStops <= 2
                                                    && s.NumberOfForwardSlashes <= 1
                                                    && s.NumberOfMultipleForwardSlashes < 1
                                                    && s.NumberOfAtSymbols >= 1
                                                    && s.HasIPAddress == false
                                                    && s.HasPortNumber == false
                                                    && s.IsBadHttps == false)
                                                    .Count();

            int MultipleFSlashWeight = PhishingSites.Where(s => s.NumberOfFullStops <= 2
                                                    && s.NumberOfForwardSlashes <= 1
                                                    && s.NumberOfMultipleForwardSlashes >= 1
                                                    && s.NumberOfAtSymbols < 1
                                                    && s.HasIPAddress == false
                                                    && s.HasPortNumber == false
                                                    && s.IsBadHttps == false)
                                                    .Count();

            int ForwardSlashesWeight = PhishingSites.Where(s => s.NumberOfFullStops <= 2
                                                     && s.NumberOfForwardSlashes > 1
                                                     && s.NumberOfMultipleForwardSlashes < 1
                                                     && s.NumberOfAtSymbols < 1
                                                     && s.HasIPAddress == false
                                                     && s.HasPortNumber == false
                                                     && s.IsBadHttps == false)
                                                    .Count();

            int FullStopsWeight = PhishingSites.Where(s => s.NumberOfFullStops > 2
                                                     && s.NumberOfForwardSlashes <= 1
                                                     && s.NumberOfMultipleForwardSlashes < 1
                                                     && s.NumberOfAtSymbols < 1
                                                     && s.HasIPAddress == false
                                                     && s.HasPortNumber == false
                                                     && s.IsBadHttps == false)
                                                    .Count();

            int TotalWeight = AtSymbolWeight + ForwardSlashesWeight
                                + FullStopsWeight + HttpsWeight + IPWeight
                                + MultipleFSlashWeight + PortsWeight;

            AtSymbolWeight = MyCalculator(AtSymbolWeight, TotalWeight);
            ForwardSlashesWeight = MyCalculator(ForwardSlashesWeight, TotalWeight);
            FullStopsWeight = MyCalculator(FullStopsWeight, TotalWeight);
            HttpsWeight = MyCalculator(HttpsWeight, TotalWeight);
            IPWeight = MyCalculator(IPWeight, TotalWeight);
            MultipleFSlashWeight = MyCalculator(MultipleFSlashWeight, TotalWeight);
            PortsWeight = MyCalculator(PortsWeight, TotalWeight);
        }

        public int MyCalculator(int A, int B)
        {
            double a = A * 100;
            double b = a / B;
            return Convert.ToInt32(Math.Round(b));
        }
    }
}
