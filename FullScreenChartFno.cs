using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace InputCsvDisplayChartForms
{
    public partial class NiftyEquityCompareChartFno : Form
    {
        
        public NiftyEquityCompareChartFno()
        {
            InitializeComponent();
        }

        private void NiftyEquityCompareChartFno_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=CORESIXTEEN;Initial Catalog=nsefo2020;Integrated Security=true;");

            SqlCommand cmd, cmd2, cmd11, cmd12, cmd13;
            SqlDataReader dr, dr2, dr11, dr12, dr13;
            con.Open();
            cmd = new SqlCommand("SELECT sobjects.name FROM sysobjects sobjects WHERE sobjects.xtype = 'U' AND sobjects.name LIKE 'fut_%'ORDER BY sobjects.name", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string tableName = dr[0].ToString();
                cmbFut.Items.Add(tableName);
            }
            dr.Close();
            
            cmd2 = new SqlCommand("SELECT sobjects.name FROM sysobjects sobjects WHERE sobjects.xtype = 'U' AND sobjects.name LIKE 'opt_%' ORDER BY sobjects.name", con);


            dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                string tableName = dr2[0].ToString();
                cmbOpt.Items.Add(tableName);
            }
            dr2.Close();
/*
            cmd11 = new SqlCommand("SELECT DISTINCT expiry  FROM optidx_nifty ORDER BY expiry", con);
            dr11 = cmd11.ExecuteReader();
            while (dr11.Read())
            {
                string tableName = dr11[0].ToString();
                cmbStrike.Items.Add(tableName);
            }
            dr11.Close();

            cmbOptype.Items.Add("XX");
            cmd12 = new SqlCommand("SELECT DISTINCT optype FROM optidx_nifty ORDER BY optype", con);
            dr12 = cmd12.ExecuteReader();
            while (dr12.Read())
            {
                string tableName = dr12[0].ToString();
                cmbOptype.Items.Add(tableName);
                
            }
            
            dr12.Close();

            cmbExpiry.Items.Add("0.00");
            cmd13 = new SqlCommand("SELECT DISTINCT strike FROM optidx_nifty ORDER BY strike", con);
            dr13 = cmd13.ExecuteReader();
            while (dr13.Read())
            {
                string tableName = dr13[0].ToString();
                cmbExpiry.Items.Add(tableName);
            }
            
            dr13.Close();*/

            con.Close();
        }

        private void cmbFut_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOpt.Text = "";
            txtTable.Text = cmbFut.SelectedItem.ToString();
            
            chart1.Series.Clear();
            chart2.Series.Clear();

            cmbExpiry.Items.Clear();            
            cmbOptype.Items.Clear();
            cmbOptype.Items.Add("XX");
            cmbStrike.Items.Clear();
            cmbStrike.Items.Add("0.00");

            SqlConnection con = new SqlConnection("Data Source=CORESIXTEEN;Initial Catalog=nsefo2020;Integrated Security=true;");

            SqlCommand cmd100;
            SqlDataReader dr100;
            con.Open();
            cmd100 = new SqlCommand("SELECT DISTINCT expiry FROM " + cmbFut.SelectedItem.ToString() + "  ORDER BY expiry", con);
            dr100 = cmd100.ExecuteReader();
            while (dr100.Read())
            {
                string tableName = dr100[0].ToString();
                cmbExpiry.Items.Add(tableName);
            }
            dr100.Close();
            con.Close();

            //PopulateChartFromDB(cmbFut.SelectedItem.ToString());
        }

        private void cmbOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            cmbFut.Text = "";
            txtTable.Text = cmbOpt.SelectedItem.ToString();
            
            chart1.Series.Clear();
            chart2.Series.Clear();

            cmbOptype.Items.Clear();
            cmbOptype.Items.Add("CE");
            cmbOptype.Items.Add("PE");
            
            SqlConnection con = new SqlConnection("Data Source=CORESIXTEEN;Initial Catalog=nsefo2020;Integrated Security=true;");

            SqlCommand cmd100, cmd200;
            SqlDataReader dr100, dr200;
            con.Open();
            cmbStrike.Items.Clear();
            cmd100 = new SqlCommand("SELECT DISTINCT strike FROM " + cmbOpt.SelectedItem.ToString() + "  ORDER BY strike", con);
            dr100 = cmd100.ExecuteReader();
            while (dr100.Read())
            {
                string tableName = dr100[0].ToString();
                cmbStrike.Items.Add(tableName);
            }
            dr100.Close();

            cmbExpiry.Items.Clear();
            cmd200 = new SqlCommand("SELECT DISTINCT expiry FROM " + cmbOpt.SelectedItem.ToString() + "  ORDER BY expiry", con);
            dr200 = cmd200.ExecuteReader();
            while (dr200.Read())
            {
                string tableName = dr200[0].ToString();
                cmbExpiry.Items.Add(tableName);
            }
            dr200.Close();

            con.Close();
            //PopulateChartFromDB(cmbOpt.SelectedItem.ToString());
        }

        private void PopulateChartFromDB()
        {
            chart1.Series.Clear();


            SqlConnection con = new SqlConnection("Data Source=CORESIXTEEN;Initial Catalog=nsefo2020;Integrated Security=true;");

            con.Open();

            DataSet ds = new DataSet();
            decimal mystrike;
            mystrike = Convert.ToDecimal(txtStrike.Text.ToString());
            //string sql = "Select tradedate, dayhigh, daylow, dayopen, dayclose, volume from " + txtTable.Text + " WHERE (( strike = '" + mystrike + "' AND optype = '" + txtOptype.Text + "') AND expiry = '" + txtExpiry.Text + "')";
            //Console.WriteLine(sql);
            
            SqlDataAdapter adapt = new SqlDataAdapter("Select tradedate, dayhigh, daylow, dayopen, dayclose, volume from " + txtTable.Text + " WHERE (( strike = '" + mystrike + "' AND optype = '" + txtOptype.Text + "') AND expiry = '" + txtExpiry.Text + "')", con);
            adapt.Fill(ds);
            chart1.DataSource = ds;



            string seriesName1 = txtTable.Text;            
            Series ser1 = chart1.Series.Add(seriesName1);
            

            ser1.ChartArea = chart1.ChartAreas[0].Name;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;

            ChartArea CA = chart1.ChartAreas[0];

            CA.AxisX.ScaleView.Zoomable = true;
            CA.AxisY.ScaleView.Zoomable = true;
            CA.CursorX.AutoScroll = true;
            CA.CursorX.IsUserSelectionEnabled = true;
            ser1.Name = seriesName1;
            

            ser1.ChartType = SeriesChartType.Candlestick;         

            ser1.BorderWidth = 3;
            ser1.XValueMember = "tradedate";
            ser1.YValueMembers = "dayhigh,daylow,dayopen,dayclose";
            ser1.SetCustomProperty("PriceUpColor", "Green");
            ser1.SetCustomProperty("PriceDownColor", "Red");
            ser1.ToolTip = "H #VALY1, L #VALY2, O #VALY3, C #VALY4, #VALX";

            chart2.Series.Clear();

            DataSet ds2 = new DataSet();
            SqlDataAdapter adapt2 = new SqlDataAdapter("Select tradedate, volume from " + txtTable.Text.ToString() + " WHERE (( strike = '" + mystrike + "' AND optype = '" + txtOptype.Text + "') AND expiry = '" + txtExpiry.Text + "')", con);
            adapt2.Fill(ds2);
            chart2.DataSource = ds2;



            string seriesName2 = txtTable.Text.ToString();
            Series ser2 = chart2.Series.Add(seriesName2);

            ser2.ChartArea = chart2.ChartAreas[0].Name;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;

            ChartArea CA2 = chart2.ChartAreas[0];

            CA2.AxisX.ScaleView.Zoomable = true;
            CA2.AxisY.ScaleView.Zoomable = true;
            CA2.CursorX.AutoScroll = true;
            CA2.CursorX.IsUserSelectionEnabled = true;

            ser2.Name = seriesName2;
            ser2.ChartType = SeriesChartType.Column;

            ser2.BorderWidth = 3;
            ser2.XValueMember = "tradedate";
            ser2.YValueMembers = "volume";
            ser2.SetCustomProperty("PriceUpColor", "Green");
            ser2.SetCustomProperty("PriceDownColor", "Red");
            ser2.ToolTip = "Date #VALX,Volume #VALY";

            con.Close();
        }


        private void cmbExpiry_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtExpiry.Text = cmbExpiry.Text;

        }

        private void cmbOptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOptype.Text = cmbOptype.Text;
        }

        private void cmbStrike_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStrike.Text = cmbStrike.Text;
            PopulateChartFromDB();

        }

        private void txtExpiry_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtStrike_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtOptype_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTable_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            PopulateChartFromDB();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
