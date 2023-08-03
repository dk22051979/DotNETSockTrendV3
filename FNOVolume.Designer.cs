namespace InputCsvDisplayChartForms
{
    partial class FNOVolume
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.txtExpiry = new System.Windows.Forms.TextBox();
            this.txtOptype = new System.Windows.Forms.TextBox();
            this.txtStrike = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.tableLayoutPanel1.SetColumnSpan(this.chart1, 2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(2, 2);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(700, 422);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(2, 428);
            this.txtTable.Margin = new System.Windows.Forms.Padding(2);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(295, 20);
            this.txtTable.TabIndex = 1;
            this.txtTable.Text = "optidx_nifty";
            this.txtTable.TextChanged += new System.EventHandler(this.txtTable_TextChanged);
            // 
            // txtExpiry
            // 
            this.txtExpiry.Location = new System.Drawing.Point(354, 428);
            this.txtExpiry.Margin = new System.Windows.Forms.Padding(2);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.Size = new System.Drawing.Size(303, 20);
            this.txtExpiry.TabIndex = 2;
            this.txtExpiry.Text = "27-Aug-2020";
            this.txtExpiry.TextChanged += new System.EventHandler(this.txtExpiry_TextChanged);
            // 
            // txtOptype
            // 
            this.txtOptype.Location = new System.Drawing.Point(2, 451);
            this.txtOptype.Margin = new System.Windows.Forms.Padding(2);
            this.txtOptype.Name = "txtOptype";
            this.txtOptype.Size = new System.Drawing.Size(295, 20);
            this.txtOptype.TabIndex = 3;
            this.txtOptype.Text = "CE";
            this.txtOptype.TextChanged += new System.EventHandler(this.txtOptype_TextChanged);
            // 
            // txtStrike
            // 
            this.txtStrike.Location = new System.Drawing.Point(354, 451);
            this.txtStrike.Margin = new System.Windows.Forms.Padding(2);
            this.txtStrike.Name = "txtStrike";
            this.txtStrike.Size = new System.Drawing.Size(303, 20);
            this.txtStrike.TabIndex = 4;
            this.txtStrike.Text = "11600.00";
            this.txtStrike.TextChanged += new System.EventHandler(this.txtStrike_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtExpiry, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtOptype, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTable, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtStrike, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(704, 474);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // FNOVolume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 474);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FNOVolume";
            this.Text = "FNOVolume";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.TextBox txtExpiry;
        private System.Windows.Forms.TextBox txtOptype;
        private System.Windows.Forms.TextBox txtStrike;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}