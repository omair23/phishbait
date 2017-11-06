using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class frmCrawler : Form
    {
        List<string> MainList;
        PhishModel db;
        EFRepository Repository;

        public frmCrawler()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            MainList = new List<string>();

            //lstSites.Items.Add("https://www.uj.ac.za/");

            //lstSites.Items.Add("http://eve.uj.ac.za/rkw/login.php");

            //lstSites.Items.Add("https://www.fnb.co.za/");

            //lstSites.Items.Add("https://www.standardbank.co.za/");

            //lstSites.Items.Add("https://www.nedbank.co.za/");

            //lstSites.Items.Add("https://home.kpmg.com/za/en/home.html");

            //lstSites.Items.Add("https://www2.deloitte.com/za/en.html");

            lstSites.Items.Add("http://www.flysaa.com/");
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            ListBox.ObjectCollection Sites = lstSites.Items;

            foreach (var Site in Sites)
            {
                CrawlPages(Site.ToString());

                lblCounter.Text = MainList.Count.ToString();

                lstCrawled.DataSource = MainList;
            }

            List<Resource> Resources = new List<Resource>();

            foreach(var Item in MainList)
            {
                Resource Resource = new Resource(Item);
                Resource.ItemType = PhishDataType.Positive;

                Resources.Add(Resource);
            }

            Repository.AddMultiple(Resources);

            lblCounter.Text = Resources.Count.ToString();
        }

        public void CrawlPages(string Url)
        {
            string htmlCode = GetWebContent(Url);

            List<string> LinksCrawled = GetNewLinks(htmlCode).ToList();

            List<string> PossibleLinks = LinksCrawled.Where(s => s.Contains("http")).ToList();

            MainList.AddRange(PossibleLinks);

            foreach (var link in PossibleLinks)
            {
                htmlCode = GetWebContent(link);

                List<string> NewLinks = GetNewLinks(htmlCode).ToList();

                NewLinks = NewLinks.Where(s => s.Contains("http")).ToList();

                MainList.AddRange(NewLinks);
            }
        }

        public string GetWebContent(string Url)
        {
            string htmlCode = "";

            try
            {
                using (WebClient client = new WebClient())
                {
                    string EditedUrl = Url;

                    //Add http://
                    if (Url.Substring(0, 4) != "http")
                    {
                        EditedUrl = "http://" + Url;
                    }

                    htmlCode = client.DownloadString(EditedUrl);
                }

                return htmlCode;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        public ISet<string> GetNewLinks(string content)
        {
            Regex regexLink = new Regex("(?<=<a\\s*?href=(?:'|\"))[^'\"]*?(?=(?:'|\"))");

            ISet<string> newLinks = new HashSet<string>();
            foreach (var match in regexLink.Matches(content))
            {
                if (!newLinks.Contains(match.ToString()))
                    newLinks.Add(match.ToString());
            }

            return newLinks;
        }
    }
}
