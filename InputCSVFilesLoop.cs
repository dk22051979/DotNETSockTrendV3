using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputCsvDisplayChartForms
{
    public partial class InputCSVFilesLoop : Form
    {
        private static SqlConnection objConnection = null;
        public static string ConnectionString = "Data Source=CORESIXTEEN;Initial Catalog=nse_eq_2020;Integrated Security=true;";
        public static string ConnectionStringSegm = "Data Source=CORESIXTEEN;Initial Catalog=segments;Integrated Security=true;";
        public InputCSVFilesLoop()
        {
            InitializeComponent();
        }

        private void InputCSVFilesLoop_Load(object sender, EventArgs e)
        {
  
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
                MessageBox.Show("Deepak " + ex);
                //Console.WriteLine(ex);
            }
            return csvData;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DateTime dt0 = new DateTime(2020, 1, 1);
            DateTime dt1 = new DateTime(2020, 1, 31);
            //cm01JAN2021bhav.csv.zip
            for (; dt0.Date <= dt1.Date; dt0 = dt0.AddDays(1))
            {
                string mydate = dt0.Date.ToString("ddMMMyyyy");
                string mymon = dt0.Date.ToString("MMM");
                string myyr = dt0.Date.ToString("yyyy");

                string fileName = "cm" + mydate.ToUpper() + "bhav.csv";

                try
                {
                    DataTable dtItem = new DataTable();
                    dtItem = PopulateDTFromCSVFile(fileName);
                    string Series, Symbol, DayHigh, DayLow, DayOpen, DayClose, TradeDate, Volume, DayPrevClose, TDate = "2020-03-23";
                    string DeleteQry = "";
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
                            
                            DeleteQry = "DELETE FROM " + Symbol.ToLower() + " WHERE tradedate BETWEEN '2020-01-01' AND '2020-01-31'";
                            objConnection = new SqlConnection(ConnectionString);
                            objConnection.Open();

                            //Console.WriteLine(DeleteQry);
                            SqlCommand cmd = new SqlCommand(DeleteQry, objConnection);
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine(ex);
                            }

                            objConnection.Close();
                            objConnection.Dispose();
                        }
                    }
                    if (DeleteQry.Length > 0)
                    {
                        if (isSuccess)
                        {
                            //MessageBox.Show("Item Imported Successfully, Total Imported Records : " + count + "", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Console.WriteLine("Success");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Exception " + ex);
                    Console.WriteLine("File Not Found");
                }


            }
        }

        private void buttonLoop_Click(object sender, EventArgs e)
        {

            DateTime dt0 = new DateTime(Convert.ToInt32(textBoxStart.Text), Convert.ToInt32(textBoxStartM.Text), Convert.ToInt32(textBoxStartD.Text));
            DateTime dt1 = new DateTime(Convert.ToInt32(textBoxStop.Text), Convert.ToInt32(textBoxStopM.Text), Convert.ToInt32(textBoxStopD.Text));

            for (; dt0.Date <= dt1.Date; dt0 = dt0.AddDays(1))
            {
                string mydate = dt0.Date.ToString("ddMMMyyyy").ToUpper();
                
                string myyr = dt0.Date.ToString("yyyy");
                string mymon = dt0.Date.ToString("MMM").ToUpper();
                string mydt = mydate.Substring(0, 2);

                string fileName = "cm" + mydate + "bhav.csv";

                try
                {
                    DataTable dtItem = new DataTable();
                    dtItem = PopulateDTFromCSVFile(fileName);
                    
                    string Series, Symbol, DayHigh, DayLow, DayOpen, DayClose, TradeDate, Volume, DayPrevClose;
                    string InsertItemQry = "", CreateTblQry = "";
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
                            CreateTblQry = "if not exists(select * from sysobjects where name = 'eq_" + Symbol.ToLower() + "' and xtype = 'U') CREATE TABLE eq_" + Symbol.ToLower() + " (tradedate date, dayhigh decimal(15,2), daylow decimal(15,2), dayopen decimal(15,2), dayclose decimal(15,2), dayprevclose decimal(15,2), volume int);";


                            objConnection = new SqlConnection(ConnectionString);
                            objConnection.Open();

                     
                            SqlCommand cmd = new SqlCommand(CreateTblQry, objConnection);
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine(ex);
                            }

                            objConnection.Close();
                            objConnection.Dispose();


                            ++count;

                            string mm = "";
                            if (mymon.ToUpper() == "JAN")
                            {
                                mm = "01";
                            }
                            else if (mymon.ToUpper() == "FEB")
                            {
                                mm = "02";
                            }
                            else if (mymon.ToUpper() == "MAR")
                            {
                                mm = "03";
                            }
                            else if (mymon.ToUpper() == "APR")
                            {
                                mm = "04";
                            }
                            else if (mymon.ToUpper() == "MAY")
                            {
                                mm = "05";
                            }
                            else if (mymon.ToUpper() == "JUN")
                            {
                                mm = "06";
                            }
                            else if (mymon.ToUpper() == "JUL")
                            {
                                mm = "07";
                            }
                            else if (mymon.ToUpper() == "AUG")
                            {
                                mm = "08";
                            }
                            else if (mymon.ToUpper() == "SEP")
                            {
                                mm = "09";
                            }
                            else if (mymon.ToUpper() == "OCT")
                            {
                                mm = "10";
                            }
                            else if (mymon.ToUpper() == "NOV")
                            {
                                mm = "11";
                            }
                            else if (mymon.ToUpper() == "DEC")
                            {
                                mm = "12";
                            }
                            InsertItemQry = "INSERT INTO eq_" + Symbol.ToLower() + "  VALUES ('" + myyr + "-" + mm + "-" + mydt + "','" + DayHigh + "','" + DayLow + "','" + DayOpen + "','" + DayClose + "','" + DayPrevClose + "','" + Volume + "'); ";
                            //isSuccess = DBAccess.ExecuteQuery(InsertItemQry);
                            objConnection = new SqlConnection(ConnectionString);
                            objConnection.Open();

                            //Console.WriteLine(InsertItemQry);
                            SqlCommand cmd2 = new SqlCommand(InsertItemQry, objConnection);
                            try
                            {
                                cmd2.ExecuteNonQuery();
                            }
                            catch(SqlException ex)
                            {
                                Console.WriteLine(ex);
                            }

                            objConnection.Close();
                            objConnection.Dispose();                 
                        }
                    }
                    if (InsertItemQry.Length > 0)
                    {
                        if (isSuccess)
                        {
                            //MessageBox.Show("Item Imported Successfully, Total Imported Records : " + count + "", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Console.WriteLine("Success");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Exception " + ex);
                   // Console.WriteLine("File Not Found");
                }
                Console.WriteLine(fileName + " inserted");

            }
        }

        private void textBoxStart_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxStop_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtItem = new DataTable();
                dtItem = PopulateDTFromCSVFile(tbxCSVFileName.Text);
                string Symbol, Lot;
                string InstType = "stockfo";
                string InsertItemQry = "", CreateTblQry = "";

                foreach (DataRow dr in dtItem.Rows)
                {
                    Lot = Convert.ToString(dr["Lot"]);
                    Symbol = Regex.Replace(Convert.ToString(dr["symbol"]), @"[^\w\d]", "");
                    if (Lot != "" && Symbol != "" )
                    {
                        CreateTblQry = "if not exists(select * from sysobjects where name = 'alleq' and xtype = 'U') CREATE TABLE alleq" + " (symbol varchar(100), lot int, insttype varchar(100));";


                        objConnection = new SqlConnection(ConnectionStringSegm);
                        objConnection.Open();


                        SqlCommand cmd = new SqlCommand(CreateTblQry, objConnection);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex);
                        }

                        objConnection.Close();
                        objConnection.Dispose();


                        
                        InsertItemQry = "INSERT INTO alleq VALUES ('neq" + Symbol.ToLower() + "','" + Lot + "','" + InstType + "'); ";
                        //isSuccess = DBAccess.ExecuteQuery(InsertItemQry);
                        objConnection = new SqlConnection(ConnectionStringSegm);
                        objConnection.Open();

                        //Console.WriteLine(InsertItemQry);
                        SqlCommand cmd2 = new SqlCommand(InsertItemQry, objConnection);
                        try
                        {
                            cmd2.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex);
                        }

                        objConnection.Close();
                        objConnection.Dispose();
                        Console.WriteLine(Symbol);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
                // Console.WriteLine("File Not Found");
            }

        } 
    }
}
