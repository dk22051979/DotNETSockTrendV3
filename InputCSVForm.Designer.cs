namespace InputCsvDisplayChartForms
{
    partial class InputCSVForm
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
            this.pnlInputCsv = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnInsertToDB = new System.Windows.Forms.Button();
            this.txtCsvFileName = new System.Windows.Forms.TextBox();
            this.btnSelectDialog = new System.Windows.Forms.Button();
            this.dgvCsvFile = new System.Windows.Forms.DataGridView();
            this.pnlInputCsv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsvFile)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInputCsv
            // 
            this.pnlInputCsv.Controls.Add(this.textBox1);
            this.pnlInputCsv.Controls.Add(this.button2);
            this.pnlInputCsv.Controls.Add(this.button1);
            this.pnlInputCsv.Controls.Add(this.btnInsertToDB);
            this.pnlInputCsv.Controls.Add(this.txtCsvFileName);
            this.pnlInputCsv.Controls.Add(this.btnSelectDialog);
            this.pnlInputCsv.Controls.Add(this.dgvCsvFile);
            this.pnlInputCsv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInputCsv.Location = new System.Drawing.Point(0, 0);
            this.pnlInputCsv.Name = "pnlInputCsv";
            this.pnlInputCsv.Size = new System.Drawing.Size(800, 450);
            this.pnlInputCsv.TabIndex = 0;
            this.pnlInputCsv.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInputCsv_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(441, 20);
            this.textBox1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(540, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save FO To DB";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "FO.csv";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnInsertToDB
            // 
            this.btnInsertToDB.Location = new System.Drawing.Point(540, 52);
            this.btnInsertToDB.Name = "btnInsertToDB";
            this.btnInsertToDB.Size = new System.Drawing.Size(104, 23);
            this.btnInsertToDB.TabIndex = 3;
            this.btnInsertToDB.Text = "Save EQ To DB";
            this.btnInsertToDB.UseVisualStyleBackColor = true;
            this.btnInsertToDB.Click += new System.EventHandler(this.btnInsertToDB_Click);
            // 
            // txtCsvFileName
            // 
            this.txtCsvFileName.Location = new System.Drawing.Point(93, 54);
            this.txtCsvFileName.Name = "txtCsvFileName";
            this.txtCsvFileName.Size = new System.Drawing.Size(441, 20);
            this.txtCsvFileName.TabIndex = 2;
            this.txtCsvFileName.TextChanged += new System.EventHandler(this.txtCsvFileName_TextChanged);
            // 
            // btnSelectDialog
            // 
            this.btnSelectDialog.Location = new System.Drawing.Point(12, 49);
            this.btnSelectDialog.Name = "btnSelectDialog";
            this.btnSelectDialog.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDialog.TabIndex = 1;
            this.btnSelectDialog.Text = "EQ.csv";
            this.btnSelectDialog.UseVisualStyleBackColor = true;
            this.btnSelectDialog.Click += new System.EventHandler(this.btnSelectDialog_Click);
            // 
            // dgvCsvFile
            // 
            this.dgvCsvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCsvFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCsvFile.Location = new System.Drawing.Point(0, 163);
            this.dgvCsvFile.Name = "dgvCsvFile";
            this.dgvCsvFile.Size = new System.Drawing.Size(800, 287);
            this.dgvCsvFile.TabIndex = 0;
            // 
            // InputCSVForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlInputCsv);
            this.Name = "InputCSVForm";
            this.Text = "InputCSVForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InputCSVForm_Load);
            this.pnlInputCsv.ResumeLayout(false);
            this.pnlInputCsv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsvFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInputCsv;
        private System.Windows.Forms.Button btnInsertToDB;
        private System.Windows.Forms.TextBox txtCsvFileName;
        private System.Windows.Forms.Button btnSelectDialog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvCsvFile;
    }
}