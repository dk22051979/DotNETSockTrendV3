namespace InputCsvDisplayChartForms
{
    partial class InputCSVFilesLoop
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.buttonLoop = new System.Windows.Forms.Button();
            this.textBoxStart = new System.Windows.Forms.TextBox();
            this.textBoxStop = new System.Windows.Forms.TextBox();
            this.textBoxStartM = new System.Windows.Forms.TextBox();
            this.textBoxStopM = new System.Windows.Forms.TextBox();
            this.textBoxStartD = new System.Windows.Forms.TextBox();
            this.textBoxStopD = new System.Windows.Forms.TextBox();
            this.tbxCSVFileName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(475, 111);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(186, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "CLEAR";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // buttonLoop
            // 
            this.buttonLoop.Location = new System.Drawing.Point(230, 111);
            this.buttonLoop.Name = "buttonLoop";
            this.buttonLoop.Size = new System.Drawing.Size(75, 23);
            this.buttonLoop.TabIndex = 1;
            this.buttonLoop.Text = "LOOP";
            this.buttonLoop.UseVisualStyleBackColor = true;
            this.buttonLoop.Click += new System.EventHandler(this.buttonLoop_Click);
            // 
            // textBoxStart
            // 
            this.textBoxStart.Location = new System.Drawing.Point(79, 42);
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.Size = new System.Drawing.Size(67, 20);
            this.textBoxStart.TabIndex = 2;
            this.textBoxStart.Text = "2021";
            this.textBoxStart.TextChanged += new System.EventHandler(this.textBoxStart_TextChanged);
            // 
            // textBoxStop
            // 
            this.textBoxStop.Location = new System.Drawing.Point(425, 42);
            this.textBoxStop.Name = "textBoxStop";
            this.textBoxStop.Size = new System.Drawing.Size(63, 20);
            this.textBoxStop.TabIndex = 3;
            this.textBoxStop.Text = "2021";
            this.textBoxStop.TextChanged += new System.EventHandler(this.textBoxStop_TextChanged);
            // 
            // textBoxStartM
            // 
            this.textBoxStartM.Location = new System.Drawing.Point(152, 42);
            this.textBoxStartM.Name = "textBoxStartM";
            this.textBoxStartM.Size = new System.Drawing.Size(100, 20);
            this.textBoxStartM.TabIndex = 4;
            this.textBoxStartM.Text = "01";
            // 
            // textBoxStopM
            // 
            this.textBoxStopM.Location = new System.Drawing.Point(494, 42);
            this.textBoxStopM.Name = "textBoxStopM";
            this.textBoxStopM.Size = new System.Drawing.Size(100, 20);
            this.textBoxStopM.TabIndex = 5;
            this.textBoxStopM.Text = "01";
            this.textBoxStopM.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBoxStartD
            // 
            this.textBoxStartD.Location = new System.Drawing.Point(258, 42);
            this.textBoxStartD.Name = "textBoxStartD";
            this.textBoxStartD.Size = new System.Drawing.Size(100, 20);
            this.textBoxStartD.TabIndex = 6;
            this.textBoxStartD.Text = "01";
            // 
            // textBoxStopD
            // 
            this.textBoxStopD.Location = new System.Drawing.Point(600, 42);
            this.textBoxStopD.Name = "textBoxStopD";
            this.textBoxStopD.Size = new System.Drawing.Size(100, 20);
            this.textBoxStopD.TabIndex = 7;
            this.textBoxStopD.Text = "31";
            // 
            // tbxCSVFileName
            // 
            this.tbxCSVFileName.Location = new System.Drawing.Point(61, 270);
            this.tbxCSVFileName.Name = "tbxCSVFileName";
            this.tbxCSVFileName.Size = new System.Drawing.Size(191, 20);
            this.tbxCSVFileName.TabIndex = 8;
            this.tbxCSVFileName.Text = "FOlot.csv";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(413, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "InsertFOlot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InputCSVFilesLoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxCSVFileName);
            this.Controls.Add(this.textBoxStopD);
            this.Controls.Add(this.textBoxStartD);
            this.Controls.Add(this.textBoxStopM);
            this.Controls.Add(this.textBoxStartM);
            this.Controls.Add(this.textBoxStop);
            this.Controls.Add(this.textBoxStart);
            this.Controls.Add(this.buttonLoop);
            this.Controls.Add(this.btnDelete);
            this.Name = "InputCSVFilesLoop";
            this.Text = "InputCSVFilesLoop";
            this.Load += new System.EventHandler(this.InputCSVFilesLoop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button buttonLoop;
        private System.Windows.Forms.TextBox textBoxStart;
        private System.Windows.Forms.TextBox textBoxStop;
        private System.Windows.Forms.TextBox textBoxStartM;
        private System.Windows.Forms.TextBox textBoxStopM;
        private System.Windows.Forms.TextBox textBoxStartD;
        private System.Windows.Forms.TextBox textBoxStopD;
        private System.Windows.Forms.TextBox tbxCSVFileName;
        private System.Windows.Forms.Button button1;
    }
}