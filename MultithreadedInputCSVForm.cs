using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputCsvDisplayChartForms
{
    public partial class MultithreadedInputCSVForm : Form
    {
        public MultithreadedInputCSVForm()
        {
            InitializeComponent();
            InstantiateWorkerThread();
        }
        BackgroundWorker workerThread = null;

        bool _keepRunning = false;
        int count = 0;

        private void InstantiateWorkerThread()
        {
            workerThread = new BackgroundWorker();
            workerThread.ProgressChanged += WorkerThread_ProgressChanged;
            workerThread.DoWork += WorkerThread_DoWork;
            workerThread.RunWorkerCompleted += WorkerThread_RunWorkerCompleted;
            workerThread.WorkerReportsProgress = true;
            workerThread.WorkerSupportsCancellation = true;
        }

        private void WorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStopWatch.Text =  count + " lines inserted " + "in " + e.UserState.ToString();
            lblStopWatch.ForeColor = Color.Red;
        }

        private void WorkerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                lblStopWatch.Text = "Cancelled";
            }
            else
            {
                lblStopWatch.Text = "Stopped";
            }
            lblStopWatch.Text = "Finished";
        }

        private void WorkerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime startTime = DateTime.Now;

            _keepRunning = true;

            while (_keepRunning)
            {
                //Thread.Sleep(1000);



                ///////////////////////////////////////////////////////////////////////////////

                try
                {
                    DataTable dtItem = (DataTable)(dgvCsvFile.DataSource);
                    //INSTRUMENT,SYMBOL,EXPIRY_DT,STRIKE_PR,OPTION_TYP,OPEN,HIGH,LOW,CLOSE,CONTRACTS,OPEN_INT,CHG_IN_OI,TIMESTAMP,SETTLE_PR
                    string Instrument, Symbol, Expiry, Strike, Optype, DayHigh, DayLow, DayOpen, DayClose, Contracts, Volume, ChangeInOpenInt, TradeDate, SettlePrice, TDate = "2020-03-23";
                    string InsertItemQry = "";
                    string CreateItemQry = "";
                    
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
                            DBAccess.ExecuteFOTQuery(CreateItemQry);
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
                            isSuccess = DBAccess.ExecuteFOTQuery(InsertItemQry);
                            //Console.WriteLine(count);
                            //textBox1.Text = Convert.ToString(count);
                            //break;

                            ///////////////////                                         
                             
                            string timeElapsedInstring = (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");

                            workerThread.ReportProgress(0, timeElapsedInstring);

                            if (workerThread.CancellationPending)
                            {
                                // this is important as it set the cancelled property of RunWorkerCompletedEventArgs to true
                                e.Cancel = true;
                                break;
                            }

                            ///////////////////

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception " + ex);
                }


                /////////////////////////////////////////////////////////////////////////////////
                

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            workerThread.RunWorkerAsync();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _keepRunning = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            workerThread.CancelAsync();
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
        private void MultithreadedInputCSVForm_Load(object sender, EventArgs e)
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
                            //btnInsertToDB.Enabled = false;
                            return;
                        }
                        //textBox1.Text = dialog.SafeFileName;
                        SourceURl = dialog.FileName;
                        if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)                    //INSTRUMENT,SYMBOL,EXPIRY_DT,STRIKE_PR,OPTION_TYP,OPEN,HIGH,LOW,CLOSE,SETTLE_PR,CONTRACTS,VAL_INLAKH,OPEN_INT,CHG_IN_OI,TIMESTAMP
                        {
                            dgvCsvFile.DataSource = dtNew;
                        }
                        foreach (DataGridViewRow row in dgvCsvFile.Rows)
                        {
                            if (row.Cells["INSTRUMENT"].Value == null || Convert.ToString(row.Cells["SYMBOL"].Value) == "" || Convert.ToString(row.Cells["EXPIRY_DT"].Value) == "" || Convert.ToString(row.Cells["STRIKE_PR"].Value) == "" || Convert.ToString(row.Cells["OPTION_TYP"].Value) == "" || Convert.ToString(row.Cells["OPEN"].Value) == "" || row.Cells["HIGH"].Value == null || Convert.ToString(row.Cells["LOW"].Value) == "" || row.Cells["CLOSE"].Value == null || Convert.ToString(row.Cells["CONTRACTS"].Value) == "" || Convert.ToString(row.Cells["OPEN_INT"].Value) == "" || Convert.ToString(row.Cells["CHG_IN_OI"].Value) == "" || Convert.ToString(row.Cells["TIMESTAMP"].Value) == "" || row.Cells["SETTLE_PR"].Value == null)
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
                            //button2.Enabled = false;
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

        private void dgvCsvFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
