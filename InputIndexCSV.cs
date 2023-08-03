using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace InputCsvDisplayChartForms
{
    public partial class InputIndexCSV : Form
    {
        public InputIndexCSV()
        {
            InitializeComponent();
        }

        private void buttonIndexInsert_Click(object sender, EventArgs e)
        {


            try
            {
                DataTable dtItem = (DataTable)(dataGridViewIndexCSV.DataSource);
                string Shares, Turnover, DayHigh, DayLow, DayOpen, DayClose, TradeDate;
                string InsertItemQry = "";
                int count = 0;
                bool isSuccess = false;
                foreach (DataRow dr in dtItem.Rows)
                {
                    TradeDate = Convert.ToString(dr["Date"]);
                    DayHigh = Convert.ToString(dr["High"]);
                    DayLow = Convert.ToString(dr["Low"]);
                    DayOpen = Convert.ToString(dr["Open"]);
                    DayClose = Convert.ToString(dr["Close"]);
                    Shares = Convert.ToString(dr["Shares Traded"]);
                    Turnover = Convert.ToString(dr["Turnover (Rs. Cr)"]);

                    if (DayHigh != "" && DayLow != "" && DayOpen != "" && DayClose != "" && TradeDate != "" && Shares != "")
                    {
                        InsertItemQry = "";


                        InsertItemQry = "if not exists(select * from sysobjects where name = 'nifty' and xtype = 'U') CREATE TABLE nifty (tradedate date, dayhigh decimal(15,2), daylow decimal(15,2), dayopen decimal(15,2), dayclose decimal(15,2), volume int);";
                        DBAccess.ExecuteNiftyQuery(InsertItemQry);
                        InsertItemQry = "";
                        ++count;

                        int index = TradeDate.IndexOf("-");
                        //Console.WriteLine(index);
                        
                        string dd = TradeDate.Substring(0, 2);
                        string mmm = TradeDate.Substring(index + 1, 3);
                        int index2 = TradeDate.LastIndexOf("-");
                        string yyyy = TradeDate.Substring(index2 + 1, 4);

                        //string dd = (textBoxIndexCSV.Text).Substring(2, 2);
                        //string mmm = (textBoxIndexCSV.Text).Substring(4, 3);
                        //string yyyy = (textBoxIndexCSV.Text).Substring(7, 4);
                        //Console.WriteLine(dd+"  "+mmm+"  "+yyyy);


                        string mm = "";
                        if (mmm.ToUpper() == "JAN")
                        {
                            mm = "01";
                        }
                        else if (mmm.ToUpper() == "FEB")
                        {
                            mm = "02";
                        }
                        else if (mmm.ToUpper() == "MAR")
                        {
                            mm = "03";
                        }
                        else if (mmm.ToUpper() == "APR")
                        {
                            mm = "04";
                        }
                        else if (mmm.ToUpper() == "MAY")
                        {
                            mm = "05";
                        }
                        else if (mmm.ToUpper() == "JUN")
                        {
                            mm = "06";
                        }
                        else if (mmm.ToUpper() == "JUL")
                        {
                            mm = "07";
                        }
                        else if (mmm.ToUpper() == "AUG")
                        {
                            mm = "08";
                        }
                        else if (mmm.ToUpper() == "SEP")
                        {
                            mm = "09";
                        }
                        else if (mmm.ToUpper() == "OCT")
                        {
                            mm = "10";
                        }
                        else if (mmm.ToUpper() == "NOV")
                        {
                            mm = "11";
                        }
                        else if (mmm.ToUpper() == "DEC")
                        {
                            mm = "12";
                        }
                        InsertItemQry = "INSERT INTO nifty  VALUES ('" + yyyy + "-" + mm + "-" + dd + "','" + DayHigh + "','" + DayLow + "','" + DayOpen + "','" + DayClose + "','" + Shares + "'); ";
                        isSuccess = DBAccess.ExecuteNiftyQuery(InsertItemQry);
                        //Console.WriteLine(InsertItemQry);                   
                    }
                }
                if (InsertItemQry.Length > 0)
                {
                    if (isSuccess)
                    {
                        MessageBox.Show("Item Imported Successfully, Total Imported Records : " + count + "", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewIndexCSV.DataSource = null;
                        buttonIndexInsert.BackColor = Color.White;
                        textBoxIndexCSV.Text = textBoxIndexCSV.Text + " done";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        private void buttonDialog_Click(object sender, EventArgs e)
        {
            buttonDialog.BackColor = Color.Red;
            buttonIndexInsert.BackColor = Color.Green;
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                int ImportedRecord = 0, inValidItem = 0;
                string SourceURl = "";
                if (dialog.FileName != "")
                {
                    if (dialog.FileName.EndsWith(".csv"))
                    {
                        DataTable dtNew = new DataTable();
                        dtNew = PopulateDTFromCSVFile(dialog.FileName);
                        if (Convert.ToString(dtNew.Columns[0]).ToLower() != "date")
                        {
                            MessageBox.Show("Invalid Items File");
                            buttonIndexInsert.Enabled = false;
                            return;
                        }
                        textBoxIndexCSV.Text = dialog.SafeFileName;
                        SourceURl = dialog.FileName;
                        if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)
                        {
                            dataGridViewIndexCSV.DataSource = dtNew;
                        }
                        foreach (DataGridViewRow row in dataGridViewIndexCSV.Rows)
                        {
                            if (Convert.ToString(row.Cells["Date"].Value) == "" ||  Convert.ToString(row.Cells["Open"].Value) == "" || row.Cells["High"].Value == null || Convert.ToString(row.Cells["Low"].Value) == "" || row.Cells["Close"].Value == null || Convert.ToString(row.Cells["Shares Traded"].Value) == "" || row.Cells["Turnover (Rs. Cr)"].Value == null)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                inValidItem += 1;
                            }
                            else
                            {
                                ImportedRecord += 1;
                            }
                        }
                        if (dataGridViewIndexCSV.Rows.Count == 0)
                        {
                            buttonIndexInsert.Enabled = false;
                            MessageBox.Show("There is no data in this file", "Engineer Deepak Kumar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected File is Invalid, Please Select valid csv file.", "Engineer Deepak Kumar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }

        }

        private void textBoxIndexCSV_TextChanged(object sender, EventArgs e)
        {

        }


        //////////////////////////////////////////////

        public static DataTable PopulateDTFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                if (csv_file_path.EndsWith(".csv"))
                {
                    using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path))
                    {
                        csvReader.SetDelimiters(new string[] {
                    ","
                });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        //read column  
                        string[] colFields = csvReader.ReadFields();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            csvData.Columns.Add(datecolumn);
                        }
                        while (!csvReader.EndOfData)
                        {
                            string[] fieldData = csvReader.ReadFields();
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            csvData.Rows.Add(fieldData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exce " + ex);
            }
            return csvData;
        }

        private void dataGridViewIndexCSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonBankNifty_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dtItem = (DataTable)(dataGridViewIndexCSV.DataSource);
                string Shares, Turnover, DayHigh, DayLow, DayOpen, DayClose, TradeDate;
                string InsertItemQry = "";
                int count = 0;
                bool isSuccess = false;
                foreach (DataRow dr in dtItem.Rows)
                {
                    TradeDate = Convert.ToString(dr["Date"]);
                    DayHigh = Convert.ToString(dr["High"]);
                    DayLow = Convert.ToString(dr["Low"]);
                    DayOpen = Convert.ToString(dr["Open"]);
                    DayClose = Convert.ToString(dr["Close"]);
                    Shares = Convert.ToString(dr["Shares Traded"]);
                    Turnover = Convert.ToString(dr["Turnover (Rs. Cr)"]);

                    if (DayHigh != "" && DayLow != "" && DayOpen != "" && DayClose != "" && TradeDate != "" && Shares != "")
                    {
                        InsertItemQry = "";


                        InsertItemQry = "if not exists(select * from sysobjects where name = 'banknifty' and xtype = 'U') CREATE TABLE banknifty (tradedate date, dayhigh decimal(15,2), daylow decimal(15,2), dayopen decimal(15,2), dayclose decimal(15,2), volume int);";
                        DBAccess.ExecuteNiftyQuery(InsertItemQry);
                        InsertItemQry = "";
                        ++count;

                        int index = TradeDate.IndexOf("-");
                        //Console.WriteLine(index);

                        string dd = TradeDate.Substring(0, 2);
                        string mmm = TradeDate.Substring(index + 1, 3);
                        int index2 = TradeDate.LastIndexOf("-");
                        string yyyy = TradeDate.Substring(index2 + 1, 4);

                        //string dd = (textBoxIndexCSV.Text).Substring(2, 2);
                        //string mmm = (textBoxIndexCSV.Text).Substring(4, 3);
                        //string yyyy = (textBoxIndexCSV.Text).Substring(7, 4);
                        //Console.WriteLine(dd+"  "+mmm+"  "+yyyy);


                        string mm = "";
                        if (mmm.ToUpper() == "JAN")
                        {
                            mm = "01";
                        }
                        else if (mmm.ToUpper() == "FEB")
                        {
                            mm = "02";
                        }
                        else if (mmm.ToUpper() == "MAR")
                        {
                            mm = "03";
                        }
                        else if (mmm.ToUpper() == "APR")
                        {
                            mm = "04";
                        }
                        else if (mmm.ToUpper() == "MAY")
                        {
                            mm = "05";
                        }
                        else if (mmm.ToUpper() == "JUN")
                        {
                            mm = "06";
                        }
                        else if (mmm.ToUpper() == "JUL")
                        {
                            mm = "07";
                        }
                        else if (mmm.ToUpper() == "AUG")
                        {
                            mm = "08";
                        }
                        else if (mmm.ToUpper() == "SEP")
                        {
                            mm = "09";
                        }
                        else if (mmm.ToUpper() == "OCT")
                        {
                            mm = "10";
                        }
                        else if (mmm.ToUpper() == "NOV")
                        {
                            mm = "11";
                        }
                        else if (mmm.ToUpper() == "DEC")
                        {
                            mm = "12";
                        }
                        InsertItemQry = "INSERT INTO banknifty  VALUES ('" + yyyy + "-" + mm + "-" + dd + "','" + DayHigh + "','" + DayLow + "','" + DayOpen + "','" + DayClose + "','" + Shares + "'); ";
                        isSuccess = DBAccess.ExecuteNiftyQuery(InsertItemQry);
                        //Console.WriteLine(InsertItemQry);                   
                    }
                }
                if (InsertItemQry.Length > 0)
                {
                    if (isSuccess)
                    {
                        MessageBox.Show("Item Imported Successfully, Total Imported Records : " + count + "", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewIndexCSV.DataSource = null;
                        buttonIndexInsert.BackColor = Color.White;
                        textBoxIndexCSV.Text = textBoxIndexCSV.Text + " done";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }


        //////////////////////////////////////////////
    }
}
