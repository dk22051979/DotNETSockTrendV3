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
    public partial class InputCSVForm : Form
    {
        public InputCSVForm()
        {
            InitializeComponent();
        }

        private void InputCSVForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectDialog_Click(object sender, EventArgs e)
        {
            btnSelectDialog.BackColor = Color.Red;
            btnInsertToDB.BackColor = Color.Green;
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
                        if (Convert.ToString(dtNew.Columns[0]).ToLower() != "symbol")
                        {
                            MessageBox.Show("Invalid Items File");
                            btnInsertToDB.Enabled = false;
                            return;
                        }
                        txtCsvFileName.Text = dialog.SafeFileName;
                        SourceURl = dialog.FileName;
                        if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)
                        {
                            dgvCsvFile.DataSource = dtNew;
                        }
                        foreach (DataGridViewRow row in dgvCsvFile.Rows)
                        {
                            if (Convert.ToString(row.Cells["symbol"].Value) == "" || row.Cells["series"].Value == null || Convert.ToString(row.Cells["open"].Value) == "" || row.Cells["high"].Value == null || Convert.ToString(row.Cells["low"].Value) == "" || row.Cells["close"].Value == null || Convert.ToString(row.Cells["timestamp"].Value) == "" || row.Cells["tottrdqty"].Value == null)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                inValidItem += 1;
                            }
                            else
                            {
                                ImportedRecord += 1;
                            }
                        }
                        if (dgvCsvFile.Rows.Count == 0)
                        {
                            btnInsertToDB.Enabled = false;
                            MessageBox.Show("There is no data in this file", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected File is Invalid, Please Select valid csv file.", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }

        }
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

        private void btnInsertToDB_Click(object sender, EventArgs e)
        {
            
            try
            {
                DataTable dtItem = (DataTable)(dgvCsvFile.DataSource);
                string Series, Symbol, DayHigh, DayLow, DayOpen, DayClose, TradeDate, Volume, DayPrevClose, TDate = "2020-03-23";
                string InsertItemQry = "";
                int count = 0;
                bool isSuccess = false;
                foreach (DataRow dr in dtItem.Rows)
                {
                    Series = Convert.ToString(dr["series"]);
                    Symbol = Regex.Replace(Convert.ToString(dr["symbol"]), @"[^\w\d]", "");
                    DayHigh = Convert.ToString(dr["high"]);
                    DayLow = Convert.ToString(dr["low"]);
                    DayOpen = Convert.ToString(dr["open"]);
                    DayClose = Convert.ToString(dr["close"]);
                    DayPrevClose = Convert.ToString(dr["prevclose"]);
                    TradeDate = Convert.ToString(dr["timestamp"]);
                    Volume = Convert.ToString(dr["tottrdqty"]);
                    if (Series == "EQ" && Symbol != "" && DayHigh != "" && DayLow != "" && DayOpen != "" && DayClose != "" && TradeDate != "" && Volume != "")
                    {
                        InsertItemQry = "";


                        InsertItemQry = "if not exists(select * from sysobjects where name = 'neq" + Symbol.ToLower() + "' and xtype = 'U') CREATE TABLE neq" + Symbol.ToLower() + " (tradedate date, dayhigh decimal(15,2), daylow decimal(15,2), dayopen decimal(15,2), dayclose decimal(15,2), dayprevclose decimal(15,2), volume int);";
                        DBAccess.ExecuteQuery(InsertItemQry);
                        InsertItemQry = "";
                        ++count;
                        TDate = TradeDate;
                        int index = TDate.IndexOf("-");
                        //Console.WriteLine(index);
                        /*
                        string dd = TDate.Substring(0, 2);
                        string mmm = TDate.Substring(index + 1, 3);
                        int index2 = TDate.LastIndexOf("-");
                        string yy = TDate.Substring(index2 + 1, 2);
                        string yyyy = "20" + yy;*/

                        string dd = (txtCsvFileName.Text).Substring(2, 2);
                        string mmm = (txtCsvFileName.Text).Substring(4, 3);
                        string yyyy = (txtCsvFileName.Text).Substring(7, 4);
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
                        InsertItemQry = "INSERT INTO neq" + Symbol.ToLower() + "  VALUES ('" + yyyy + "-" + mm + "-" + dd + "','" + DayHigh + "','" + DayLow + "','" + DayOpen + "','" + DayClose + "','" + DayPrevClose + "','" + Volume + "'); ";
                        isSuccess = DBAccess.ExecuteQuery(InsertItemQry);
                        //Console.WriteLine(InsertItemQry);                   
                    }
                }
                if (InsertItemQry.Length > 0)
                {
                    if (isSuccess)
                    {
                        MessageBox.Show("Item Imported Successfully, Total Imported Records : " + count + "", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvCsvFile.DataSource = null;
                        btnInsertToDB.BackColor = Color.White;
                        txtCsvFileName.Text = txtCsvFileName.Text + " done";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        private void txtCsvFileName_TextChanged(object sender, EventArgs e)
        {
            btnInsertToDB.BackColor = Color.Red;
        }

        private void pnlInputCsv_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                        if (Convert.ToString(dtNew.Columns[0]) != "INSTRUMENT")
                        {
                            MessageBox.Show("Invalid Items File");
                            btnInsertToDB.Enabled = false;
                            return;
                        }
                        textBox1.Text = dialog.SafeFileName;
                        SourceURl = dialog.FileName;
                        if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)                    //INSTRUMENT,SYMBOL,EXPIRY_DT,STRIKE_PR,OPTION_TYP,OPEN,HIGH,LOW,CLOSE,SETTLE_PR,CONTRACTS,VAL_INLAKH,OPEN_INT,CHG_IN_OI,TIMESTAMP
                        {
                            dgvCsvFile.DataSource = dtNew;
                        }
                        foreach (DataGridViewRow row in dgvCsvFile.Rows)
                        {
                            if ( row.Cells["INSTRUMENT"].Value == null || Convert.ToString(row.Cells["SYMBOL"].Value) == "" || Convert.ToString(row.Cells["EXPIRY_DT"].Value) == "" || Convert.ToString(row.Cells["STRIKE_PR"].Value) == "" || Convert.ToString(row.Cells["OPTION_TYP"].Value) == "" || Convert.ToString(row.Cells["OPEN"].Value) == "" || row.Cells["HIGH"].Value == null || Convert.ToString(row.Cells["LOW"].Value) == "" || row.Cells["CLOSE"].Value == null || Convert.ToString(row.Cells["CONTRACTS"].Value) == "" || Convert.ToString(row.Cells["OPEN_INT"].Value) == "" || Convert.ToString(row.Cells["CHG_IN_OI"].Value) == "" || Convert.ToString(row.Cells["TIMESTAMP"].Value) == "" || row.Cells["SETTLE_PR"].Value == null )
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                inValidItem += 1;
                            }
                            else
                            {
                                ImportedRecord += 1;
                            }
                        }
                        if (dgvCsvFile.Rows.Count == 0)
                        {
                            button2.Enabled = false;
                            MessageBox.Show("There is no data in this file", "NO LIMIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected File is Invalid, Please Select valid csv file.", "NO LIMIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dtItem = (DataTable)(dgvCsvFile.DataSource);
                //INSTRUMENT,SYMBOL,EXPIRY_DT,STRIKE_PR,OPTION_TYP,OPEN,HIGH,LOW,CLOSE,CONTRACTS,OPEN_INT,CHG_IN_OI,TIMESTAMP,SETTLE_PR
                string Instrument, Symbol, Expiry, Strike, Optype, DayHigh, DayLow, DayOpen, DayClose, Contracts, Volume, ChangeInOpenInt, TradeDate, SettlePrice, TDate = "2020-03-23";
                string InsertItemQry = "";
                string CreateItemQry = "";
                int count = 0;
                bool isSuccess = false;
                foreach (DataRow dr in dtItem.Rows)
                {
                    Instrument = Convert.ToString(dr["INSTRUMENT"]);
                    Symbol = Regex.Replace(Convert.ToString(dr["SYMBOL"]), @"[^\w\d]", "");
                    Expiry = Convert.ToString(dr["EXPIRY_DT"]);
                    Strike = Convert.ToString(dr["STRIKE_PR"]);
                    Optype = Convert.ToString(dr["OPTION_TYP"]);
                    DayHigh = Convert.ToString(dr["HIGH"]);
                    DayLow = Convert.ToString(dr["LOW"]);
                    DayOpen = Convert.ToString(dr["OPEN"]);
                    DayClose = Convert.ToString(dr["CLOSE"]);
                    Contracts = Convert.ToString(dr["CONTRACTS"]);
                    Volume = Convert.ToString(dr["OPEN_INT"]);
                    ChangeInOpenInt = Convert.ToString(dr["CHG_IN_OI"]);
                    TradeDate = Convert.ToString(dr["TIMESTAMP"]);
                    SettlePrice = Convert.ToString(dr["SETTLE_PR"]);

                    if (Instrument != "" && Symbol != "" && DayHigh != "" && DayLow != "" && DayOpen != "" && DayClose != "" && TradeDate != "" && Volume != "")
                    {
                        
                        CreateItemQry = "";

                        CreateItemQry = "if not exists(select * from sysobjects where name = '" + Instrument.ToLower() + "_" + Symbol.ToLower() + 
                            "' and xtype = 'U') CREATE TABLE " + Instrument.ToLower() + "_" + Symbol.ToLower() + 
                            " (tradedate date, instrument char(30), symbol char(30), expiry char(50), strike decimal(15,2), optype char(30), volume int, dayhigh decimal(15,2), daylow decimal(15,2), dayopen decimal(15,2), dayclose decimal(15,2), contracts int,  changeoi int, settleprice decimal(15,2));";
                        DBAccess.ExecuteFOQuery(CreateItemQry);
                        //Console.WriteLine(CreateItemQry);
                        
                        InsertItemQry = "";
                        ++count;
                        TDate = TradeDate;
                        int index = TDate.IndexOf("-");
                        //Console.WriteLine(index);
                        string dd = TDate.Substring(0, 2);
                        string mmm = TDate.Substring(index + 1, 3);
                        int index2 = TDate.LastIndexOf("-");
                        string yy = TDate.Substring(index2 + 1, 2);
                        string yyyy = "20" + yy;
                        //Console.WriteLine(dd+"  "+mmm+"  "+yy);
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
                        //tradedate date, 
                        //instrument char(30), symbol char(30), expiry char(50), strike decimal(15, 2), optype char(30), volume int, 
                        //dayhigh decimal(15, 2), daylow decimal(15, 2), dayopen decimal(15, 2), dayclose decimal(15, 2), 
                        //contracts int, changeoi int, settleprice decimal(15, 2)
                        InsertItemQry = "INSERT INTO " + Instrument.ToLower() + "_" + Symbol.ToLower() + "  VALUES ('" + yyyy + "-" + mm + "-" + dd + "','"
                             + Instrument + "','" + Symbol + "','" + Expiry + "','" + Strike + "','" + Optype + "','" + Volume + "','"
                             + DayHigh + "','" + DayLow + "','" + DayOpen + "','" + DayClose + "','" 
                             + Contracts + "','" + ChangeInOpenInt + "','" + SettlePrice + "'); ";
                        isSuccess = DBAccess.ExecuteFOQuery(InsertItemQry);
                        //Console.WriteLine(count);
                        //textBox1.Text = Convert.ToString(count);
                        //break;
                    }
                }
                if (InsertItemQry.Length > 0)
                {
                    if (isSuccess)
                    {
                        MessageBox.Show("Item Imported Successfully, Total Imported Records : " + count + "", "NO LIMIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvCsvFile.DataSource = null;                        
                        textBox1.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }
    }
}
