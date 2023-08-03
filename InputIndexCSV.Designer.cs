
namespace InputCsvDisplayChartForms
{
    partial class InputIndexCSV
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
            this.textBoxIndexCSV = new System.Windows.Forms.TextBox();
            this.buttonIndexInsert = new System.Windows.Forms.Button();
            this.dataGridViewIndexCSV = new System.Windows.Forms.DataGridView();
            this.buttonDialog = new System.Windows.Forms.Button();
            this.buttonBankNifty = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndexCSV)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxIndexCSV
            // 
            this.textBoxIndexCSV.Location = new System.Drawing.Point(118, 40);
            this.textBoxIndexCSV.Name = "textBoxIndexCSV";
            this.textBoxIndexCSV.Size = new System.Drawing.Size(496, 20);
            this.textBoxIndexCSV.TabIndex = 0;
            this.textBoxIndexCSV.Text = "nifty2022.csv";
            this.textBoxIndexCSV.TextChanged += new System.EventHandler(this.textBoxIndexCSV_TextChanged);
            // 
            // buttonIndexInsert
            // 
            this.buttonIndexInsert.Location = new System.Drawing.Point(661, 40);
            this.buttonIndexInsert.Name = "buttonIndexInsert";
            this.buttonIndexInsert.Size = new System.Drawing.Size(135, 23);
            this.buttonIndexInsert.TabIndex = 1;
            this.buttonIndexInsert.Text = "Insert Nifty to DB";
            this.buttonIndexInsert.UseVisualStyleBackColor = true;
            this.buttonIndexInsert.Click += new System.EventHandler(this.buttonIndexInsert_Click);
            // 
            // dataGridViewIndexCSV
            // 
            this.dataGridViewIndexCSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIndexCSV.Location = new System.Drawing.Point(118, 80);
            this.dataGridViewIndexCSV.Name = "dataGridViewIndexCSV";
            this.dataGridViewIndexCSV.Size = new System.Drawing.Size(496, 338);
            this.dataGridViewIndexCSV.TabIndex = 2;
            this.dataGridViewIndexCSV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIndexCSV_CellContentClick);
            // 
            // buttonDialog
            // 
            this.buttonDialog.Location = new System.Drawing.Point(12, 37);
            this.buttonDialog.Name = "buttonDialog";
            this.buttonDialog.Size = new System.Drawing.Size(75, 23);
            this.buttonDialog.TabIndex = 3;
            this.buttonDialog.Text = "Select";
            this.buttonDialog.UseVisualStyleBackColor = true;
            this.buttonDialog.Click += new System.EventHandler(this.buttonDialog_Click);
            // 
            // buttonBankNifty
            // 
            this.buttonBankNifty.Location = new System.Drawing.Point(661, 80);
            this.buttonBankNifty.Name = "buttonBankNifty";
            this.buttonBankNifty.Size = new System.Drawing.Size(135, 23);
            this.buttonBankNifty.TabIndex = 4;
            this.buttonBankNifty.Text = "Insert BankNifty to DB";
            this.buttonBankNifty.UseVisualStyleBackColor = true;
            this.buttonBankNifty.Click += new System.EventHandler(this.buttonBankNifty_Click);
            // 
            // InputIndexCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 450);
            this.Controls.Add(this.buttonBankNifty);
            this.Controls.Add(this.buttonDialog);
            this.Controls.Add(this.dataGridViewIndexCSV);
            this.Controls.Add(this.buttonIndexInsert);
            this.Controls.Add(this.textBoxIndexCSV);
            this.Name = "InputIndexCSV";
            this.Text = "InputIndexCSV";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndexCSV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIndexCSV;
        private System.Windows.Forms.Button buttonIndexInsert;
        private System.Windows.Forms.DataGridView dataGridViewIndexCSV;
        private System.Windows.Forms.Button buttonDialog;
        private System.Windows.Forms.Button buttonBankNifty;
    }
}