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
    public partial class FullScreenChart : Form
    {
        private const float CZoomScale = 4f;
        private int FZoomLevel = 0;
        public FullScreenChart()
        {
            InitializeComponent();
            chart1.MouseWheel += chart1_MouseWheel;
            chart2.MouseWheel += chart2_MouseWheel;
        }
        private void chart1_MouseEnter(object sender, EventArgs e)
        {
            if (!chart1.Focused)
                chart1.Focus();
        }

        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            if (chart1.Focused)
                chart1.Parent.Focus();
        }

        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                Axis xAxis = chart1.ChartAreas[0].AxisX;
                double xMin = xAxis.ScaleView.ViewMinimum;
                double xMax = xAxis.ScaleView.ViewMaximum;
                double xPixelPos = xAxis.PixelPositionToValue(e.Location.X);

                if (e.Delta < 0 && FZoomLevel > 0)
                {
                    // Scrolled down, meaning zoom out
                    if (--FZoomLevel <= 0)
                    {
                        FZoomLevel = 0;
                        xAxis.ScaleView.ZoomReset();
                    }
                    else
                    {
                        double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) * CZoomScale, 0);
                        double xEndPos = Math.Min(xStartPos + (xMax - xMin) * CZoomScale, xAxis.Maximum);
                        xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                    }
                }
                else if (e.Delta > 0)
                {
                    // Scrolled up, meaning zoom in
                    double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) / CZoomScale, 0);
                    double xEndPos = Math.Min(xStartPos + (xMax - xMin) / CZoomScale, xAxis.Maximum);
                    xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                    FZoomLevel++;
                }
            }
            catch { }
        }
        private void chart2_MouseEnter(object sender, EventArgs e)
        {
            if (!chart2.Focused)
                chart2.Focus();
        }

        private void chart2_MouseLeave(object sender, EventArgs e)
        {
            if (chart2.Focused)
                chart2.Parent.Focus();
        }

        private void chart2_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                Axis xAxis = chart2.ChartAreas[0].AxisX;
                double xMin = xAxis.ScaleView.ViewMinimum;
                double xMax = xAxis.ScaleView.ViewMaximum;
                double xPixelPos = xAxis.PixelPositionToValue(e.Location.X);

                if (e.Delta < 0 && FZoomLevel > 0)
                {
                    // Scrolled down, meaning zoom out
                    if (--FZoomLevel <= 0)
                    {
                        FZoomLevel = 0;
                        xAxis.ScaleView.ZoomReset();
                    }
                    else
                    {
                        double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) * CZoomScale, 0);
                        double xEndPos = Math.Min(xStartPos + (xMax - xMin) * CZoomScale, xAxis.Maximum);
                        xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                    }
                }
                else if (e.Delta > 0)
                {
                    // Scrolled up, meaning zoom in
                    double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) / CZoomScale, 0);
                    double xEndPos = Math.Min(xStartPos + (xMax - xMin) / CZoomScale, xAxis.Maximum);
                    xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                    FZoomLevel++;
                }
            }
            catch { }
        }
        private void FullScreenChart_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ITHREEGIGABYTE;Initial Catalog=nse_eq_2020;Integrated Security=true;");

            SqlCommand cmd, cmd2;
            SqlDataReader dr, dr2;
            con.Open();
            cmd = new SqlCommand("SELECT sobjects.name FROM sysobjects sobjects WHERE sobjects.xtype = 'U' ORDER BY sobjects.name", con);


            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string tableName = dr[0].ToString();
                comboBox2.Items.Add(tableName.Substring(3));
            }
            dr.Close();

            SqlConnection con2 = new SqlConnection("Data Source=ITHREEGIGABYTE;Initial Catalog=segments;Integrated Security=true;");
            con2.Open();
            cmd2 = new SqlCommand("SELECT symbol FROM alleq WHERE insttype='stock' OR insttype='etf'  OR insttype='stockfo' ORDER BY symbol", con2);


            dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                string tableName = dr2[0].ToString();
                comboBox1.Items.Add(tableName.Substring(3));
            }
            dr2.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            PopulateChartFromDB(comboBox1.SelectedItem.ToString());
        }

        private void PopulateChartFromDB(string table)
        {
            chart1.Series.Clear();


            SqlConnection con = new SqlConnection("Data Source=ITHREEGIGABYTE;Initial Catalog=nse_eq_2020;Integrated Security=true;");

            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter("Select tradedate, dayhigh, daylow, dayopen, dayclose, dayprevclose, volume from neq" + table, con);
            adapt.Fill(ds);
            chart1.DataSource = ds;



            string seriesName1 = table;
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
            SqlDataAdapter adapt2 = new SqlDataAdapter("Select tradedate, volume from neq" + table, con);
            adapt2.Fill(ds2);
            chart2.DataSource = ds2;



            string seriesName2 = table;
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
            /*
            string seriesName2 = "Volume";
            Series ser2 = chart1.Series.Add(seriesName2);

            ser2.ChartArea = chart1.ChartAreas[1].Name;
            chart1.ChartAreas[1].AxisX.LabelStyle.Angle = 90;

            ChartArea CA2 = chart1.ChartAreas[0];

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
            ser2.ToolTip = "Date #VALX,Volume #VALY";*/
            con.Close();
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            PopulateChartFromDB(comboBox2.SelectedItem.ToString());
        }
    }
}
