
namespace InputCsvDisplayChartForms
{
    partial class BhavCopyForm
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
            this.buttonDownloadBhavCopy = new System.Windows.Forms.Button();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonDownloadBhavCopy
            // 
            this.buttonDownloadBhavCopy.Location = new System.Drawing.Point(601, 119);
            this.buttonDownloadBhavCopy.Name = "buttonDownloadBhavCopy";
            this.buttonDownloadBhavCopy.Size = new System.Drawing.Size(91, 23);
            this.buttonDownloadBhavCopy.TabIndex = 0;
            this.buttonDownloadBhavCopy.Text = "DOWNLOAD";
            this.buttonDownloadBhavCopy.UseVisualStyleBackColor = true;
            this.buttonDownloadBhavCopy.Click += new System.EventHandler(this.buttonDownloadBhavCopy_Click);
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(52, 119);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(100, 20);
            this.textBoxFrom.TabIndex = 1;
            this.textBoxFrom.TextChanged += new System.EventHandler(this.textBoxFrom_TextChanged);
            // 
            // textBoxTo
            // 
            this.textBoxTo.Location = new System.Drawing.Point(351, 119);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(100, 20);
            this.textBoxTo.TabIndex = 2;
            this.textBoxTo.TextChanged += new System.EventHandler(this.textBoxTo_TextChanged);
            // 
            // BhavCopyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxTo);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.buttonDownloadBhavCopy);
            this.Name = "BhavCopyForm";
            this.Text = "BhavCopyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDownloadBhavCopy;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.TextBox textBoxTo;
    }
}