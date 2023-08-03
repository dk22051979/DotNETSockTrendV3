using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputCsvDisplayChartForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void commodityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
        }

        private void chartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            InputCSVForm myChartForm = new InputCSVForm();
            //myChartForm.TopLevel = false;
            //this.pnlMain.Controls.Add(myChartForm);
            //myChartForm.FormBorderStyle = FormBorderStyle.None;
            myChartForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            Application.Exit();
        }

        private void nSEAllEquityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            NiftyEquityCompareChart myChartForm = new NiftyEquityCompareChart();
            //myChartForm.TopLevel = false;
            //myChartForm.AutoScroll = true;
            //this.pnlMain.Controls.Add(myChartForm);
            //myChartForm.FormBorderStyle = FormBorderStyle.None;
            myChartForm.Show();
        }

        private void nseNiftyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            NiftyEquityCompareChartWithMT myChartForm = new NiftyEquityCompareChartWithMT();
            //myChartForm.TopLevel = false;
            //myChartForm.AutoScroll = true;
            //this.pnlMain.Controls.Add(myChartForm);
            //myChartForm.FormBorderStyle = FormBorderStyle.None;
            myChartForm.Show();
        }

        private void nseNonNiftyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            FNOVolume myChartForm = new FNOVolume();
            //myChartForm.TopLevel = false;
            //myChartForm.AutoScroll = true;
            //this.pnlMain.Controls.Add(myChartForm);
            //myChartForm.FormBorderStyle = FormBorderStyle.None;
            myChartForm.Show();
        }

        private void nseMyEquityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
        }

        private void equityBuyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            MultithreadedInputCSVForm myChartForm = new MultithreadedInputCSVForm();
            myChartForm.Show();
        }

        private void equitySellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
        }

        private void optionBuyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            FOMultiChartForm myChartForm = new FOMultiChartForm();
            myChartForm.Show();
        }

        private void optionSellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            //CSVFormMTN myChartForm = new CSVFormMTN();
            //myChartForm.Show();
        }

        private void equityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
        }

        private void futureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
        }

        private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
        }

        private void transactionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            InputIndexCSV myChartForm = new InputIndexCSV();
            myChartForm.TopLevel = false;
            //myChartForm.AutoScroll = true;
            this.pnlMain.Controls.Add(myChartForm);
            myChartForm.FormBorderStyle = FormBorderStyle.None;
            myChartForm.Show();
        }

        private void nseAllFnOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            NiftyEquityCompareChartFno myChartForm = new NiftyEquityCompareChartFno();
            //myChartForm.TopLevel = false;
            //myChartForm.AutoScroll = true;
            //this.pnlMain.Controls.Add(myChartForm);
            //myChartForm.FormBorderStyle = FormBorderStyle.None;            
            myChartForm.Show();
            //this.Hide();
        }

        private void fnOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            InputCSVForm myChartForm = new InputCSVForm();
            myChartForm.TopLevel = false;
            //myChartForm.AutoScroll = true;
            this.pnlMain.Controls.Add(myChartForm);
            myChartForm.FormBorderStyle = FormBorderStyle.None;
            myChartForm.Show();
        }

        private void eQLoopToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.pnlMain.Controls.Clear();
            InputCSVFilesLoop myChartForm = new InputCSVFilesLoop();
            myChartForm.TopLevel = false;
            //myChartForm.AutoScroll = true;
            this.pnlMain.Controls.Add(myChartForm);
            myChartForm.FormBorderStyle = FormBorderStyle.None;
            myChartForm.Show();
     
        }

        private void niftyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            NiftyEquityCompareChart myChartForm = new NiftyEquityCompareChart();
            myChartForm.Show();
        }

        private void eQBhavCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            BhavCopyForm myChartForm = new BhavCopyForm();
            myChartForm.Show();
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void niftyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.pnlMain.Controls.Clear();
            InputIndexCSV myChartForm = new InputIndexCSV();
            myChartForm.Show();
        }
    }
}
