using System;

namespace PrimesCalculator
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
            this.lowBoundBox = new System.Windows.Forms.TextBox();
            this.highBoundBox = new System.Windows.Forms.TextBox();
            this.Calculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCANCEL = new System.Windows.Forms.Button();
            this.OutPutLabel = new System.Windows.Forms.Label();
            this.OutputFileTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lowBoundBox
            // 
            this.lowBoundBox.Location = new System.Drawing.Point(86, 31);
            this.lowBoundBox.Name = "lowBoundBox";
            this.lowBoundBox.Size = new System.Drawing.Size(42, 20);
            this.lowBoundBox.TabIndex = 1;
            // 
            // highBoundBox
            // 
            this.highBoundBox.Location = new System.Drawing.Point(174, 31);
            this.highBoundBox.Name = "highBoundBox";
            this.highBoundBox.Size = new System.Drawing.Size(43, 20);
            this.highBoundBox.TabIndex = 2;
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(114, 72);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(75, 23);
            this.Calculate.TabIndex = 4;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Low Range\'s Bound";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "High Range\'s Bound";
            // 
            // buttonCANCEL
            // 
            this.buttonCANCEL.Location = new System.Drawing.Point(313, 72);
            this.buttonCANCEL.Name = "buttonCANCEL";
            this.buttonCANCEL.Size = new System.Drawing.Size(58, 23);
            this.buttonCANCEL.TabIndex = 9;
            this.buttonCANCEL.Text = "CANCEL";
            this.buttonCANCEL.UseVisualStyleBackColor = true;
            this.buttonCANCEL.Click += new System.EventHandler(this.buttonCANCEL_Click);
            // 
            // OutPutLabel
            // 
            this.OutPutLabel.AccessibleName = "OutPutLabel";
            this.OutPutLabel.AutoSize = true;
            this.OutPutLabel.Location = new System.Drawing.Point(64, 150);
            this.OutPutLabel.Name = "OutPutLabel";
            this.OutPutLabel.Size = new System.Drawing.Size(69, 13);
            this.OutPutLabel.TabIndex = 10;
            this.OutPutLabel.Text = "OutPut Label";
            // 
            // OutputFileTextBox
            // 
            this.OutputFileTextBox.AccessibleName = "OutputFileTextBox";
            this.OutputFileTextBox.Location = new System.Drawing.Point(89, 188);
            this.OutputFileTextBox.Name = "OutputFileTextBox";
            this.OutputFileTextBox.Size = new System.Drawing.Size(100, 20);
            this.OutputFileTextBox.TabIndex = 11;
            this.OutputFileTextBox.Text = "Output File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Output File";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OutputFileTextBox);
            this.Controls.Add(this.OutPutLabel);
            this.Controls.Add(this.buttonCANCEL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.highBoundBox);
            this.Controls.Add(this.lowBoundBox);
            this.Name = "Form1";
            this.Text = "Primes Calculator";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.TextBox lowBoundBox;
        private System.Windows.Forms.TextBox highBoundBox;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCANCEL;
        private System.Windows.Forms.Label OutPutLabel;
        private System.Windows.Forms.TextBox OutputFileTextBox;
        private System.Windows.Forms.Label label3;
    }
}

