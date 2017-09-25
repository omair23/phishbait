using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BayesClassifier;
using System.IO;

namespace Phishbait
{
    public partial class frmBayes : Form
    {
        Classifier m_Classifier;
        PhishModel db;
        EFRepository Repository;

        public frmBayes()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            m_Classifier = new Classifier();

            var GoodUrls = Repository
                            .Find<Resource>(s => s.ItemType == PhishDataType.Positive)
                            .Select(x => x.Url)
                            .ToList();

            var BadUrls = Repository
                            .Find<Resource>(s => s.ItemType == PhishDataType.Negative)
                            .Select(x => x.Url)
                            .ToList();

            //Even out the lists so that the results aren't skewed by sample sizes
            BadUrls = BadUrls.Take(GoodUrls.Count).ToList();

            m_Classifier.TeachCategoryList("Phishing", BadUrls);

            m_Classifier.TeachCategoryList("Non Phishing", GoodUrls);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string SiteToClassify = txtSite.Text;

            Dictionary<string, double> score = m_Classifier.Classify(SiteToClassify);

            double sc = score["Phishing"];

            if (score["Phishing"] < score["Non Phishing"])
                lblClass.Text = "Phishing";
            else
                lblClass.Text = "Non Phishing";

            foreach (string c in score.Keys)
            {
                listBox1.Items.Add(c + ":" + score[c].ToString());
            }
        }
    }
}
