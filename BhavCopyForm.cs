using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputCsvDisplayChartForms
{
    public partial class BhavCopyForm : Form
    {
        public BhavCopyForm()
        {
            InitializeComponent();
            textBoxFrom.Text = DateTime.Now.AddDays(-1).ToString("d/MM/yyyy");
            textBoxTo.Text = DateTime.Now.AddDays(-1).ToString("d/MM/yyyy");
        }

        private void buttonDownloadBhavCopy_Click(object sender, EventArgs e)
        {

            int startDD, startMM, startYYYY, endDD, endMM, endYYYY;
            string sd = (textBoxFrom.Text).Substring(0, 2), sm = (textBoxFrom.Text).Substring(3, 2), sy = (textBoxFrom.Text).Substring(6, 4), ed = (textBoxTo.Text).Substring(0, 2), em = (textBoxTo.Text).Substring(3, 2), ey = (textBoxTo.Text).Substring(6, 4);
            startDD = Convert.ToInt32(sd);
            startMM = Convert.ToInt32(sm);
            startYYYY = Convert.ToInt32(sy);
            endDD =  Convert.ToInt32(ed);
            endMM = Convert.ToInt32(em);
            endYYYY = Convert.ToInt32(ey);
            DateTime dt0 = new DateTime(startYYYY, startMM, startDD);
            DateTime dt1 = new DateTime(endYYYY, endMM, endDD);
            //cm01JAN2021bhav.csv.zip
            for (; dt0.Date <= dt1.Date; dt0 = dt0.AddDays(1))
            {
                //Console.WriteLine(dt0.Date.ToString("ddMMMyyyy"));
                string mydate = dt0.Date.ToString("ddMMMyyyy");
                string mymon = dt0.Date.ToString("MMM");
                string myyr = dt0.Date.ToString("yyyy");
                string remoteUri = "https://www1.nseindia.com/content/historical/EQUITIES/" + myyr.ToUpper() + "/" + mymon.ToUpper() + "/";
                string fileName = "cm" + mydate.ToUpper() + "bhav.csv.zip", myStringWebResource = null;
                Console.WriteLine(remoteUri + fileName);

                using (WebClient myWebClient = new WebClient())
                {
                    myStringWebResource = remoteUri + fileName;
                    try { 
                        myWebClient.DownloadFile(myStringWebResource, fileName);
                        MessageBox.Show(fileName + " Downloaded To C:\\InputCsvDisplayChartForms\\bin\\Debug", "NOLIMIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (WebException ex) {
                        //Console.WriteLine("resource not found"); 
                        MessageBox.Show(ex.ToString(),"NOLIMIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            buttonDownloadBhavCopy.Text = "DONE";

        }

        private void textBoxFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
