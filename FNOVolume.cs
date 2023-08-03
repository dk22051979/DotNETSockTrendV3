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
    public partial class FNOVolume : Form
    {
        public FNOVolume()
        {
            InitializeComponent();
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
            //ser1.ChartType = SeriesChartType.Stock;

            //ser1.ChartType = SeriesChartType.Candlestick;
            ser1.ChartType = SeriesChartType.Column;

            ser1.BorderWidth = 3;
            ser1.XValueMember = "tradedate";
           // ser1.YValueMembers = "dayhigh,daylow,dayopen,dayclose";
            ser1.YValueMembers = "volume";

            ser1.SetCustomProperty("PriceUpColor", "Green");
            ser1.SetCustomProperty("PriceDownColor", "Red");
            ser1.ToolTip = "#VALX, #VALY";
            con.Close();
        }

        private void txtStrike_TextChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            PopulateChartFromDB();
        }

        private void txtOptype_TextChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            PopulateChartFromDB();
        }

        private void txtExpiry_TextChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            PopulateChartFromDB();

        }

        private void txtTable_TextChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            //PopulateChartFromDB();

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            PopulateChartFromDB();

        }
    }
}
