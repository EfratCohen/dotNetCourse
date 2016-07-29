namespace SyncDemo
{
    partial class Form1
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
            this.buttonSTART = new System.Windows.Forms.Button();
            this.outPutTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSTART
            // 
            this.buttonSTART.Location = new System.Drawing.Point(24, 12);
            this.buttonSTART.Name = "buttonSTART";
            this.buttonSTART.Size = new System.Drawing.Size(68, 32);
            this.buttonSTART.TabIndex = 0;
            this.buttonSTART.Text = "START";
            this.buttonSTART.UseVisualStyleBackColor = true;
            this.buttonSTART.Click += new System.EventHandler(this.buttonSTART_Click);
            // 
            // outPutTextBox
            // 
            this.outPutTextBox.Location = new System.Drawing.Point(148, 19);
            this.outPutTextBox.Name = "outPutTextBox";
            this.outPutTextBox.Size = new System.Drawing.Size(100, 20);
            this.outPutTextBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 60);
            this.Controls.Add(this.outPutTextBox);
            this.Controls.Add(this.buttonSTART);
            this.Name = "Form1";
            this.Text = "SyncDemo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSTART;
        private System.Windows.Forms.TextBox outPutTextBox;
    }
}

