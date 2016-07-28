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
            this.primesListBox = new System.Windows.Forms.ListBox();
            this.Calculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSTOP = new System.Windows.Forms.Button();
            this.buttonCANCEL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lowBoundBox
            // 
            this.lowBoundBox.Location = new System.Drawing.Point(86, 31);
            this.lowBoundBox.Name = "lowBoundBox";
            this.lowBoundBox.Size = new System.Drawing.Size(42, 20);
            this.lowBoundBox.TabIndex = 1;
            this.lowBoundBox.TextChanged += new System.EventHandler(textBox1_TextChanged);
            // 
            // highBoundBox
            // 
            this.highBoundBox.Location = new System.Drawing.Point(174, 31);
            this.highBoundBox.Name = "highBoundBox";
            this.highBoundBox.Size = new System.Drawing.Size(43, 20);
            this.highBoundBox.TabIndex = 2;
            this.highBoundBox.TextChanged += new System.EventHandler(textBox2_TextChanged);
            // 
            // primesListBox
            // 
            this.primesListBox.FormattingEnabled = true;
            this.primesListBox.Location = new System.Drawing.Point(86, 136);
            this.primesListBox.Name = "primesListBox";
            this.primesListBox.Size = new System.Drawing.Size(120, 95);
            this.primesListBox.TabIndex = 3;
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(114, 72);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(75, 23);
            this.Calculate.TabIndex = 4;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(Calculate_Click);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Prime numbers in the range";
            this.label3.Click += new System.EventHandler(label3_Click);
            // 
            // button1
            // 
            this.buttonSTOP.Location = new System.Drawing.Point(12, 58);
            this.buttonSTOP.Name = "button1";
            this.buttonSTOP.Size = new System.Drawing.Size(58, 23);
            this.buttonSTOP.TabIndex = 8;
            this.buttonSTOP.Text = "STOP";
            this.buttonSTOP.UseVisualStyleBackColor = true;
            this.buttonSTOP.Click += new System.EventHandler(buttonSTOP_Click);
            // 
            // button2
            // 
            this.buttonCANCEL.Location = new System.Drawing.Point(12, 87);
            this.buttonCANCEL.Name = "button2";
            this.buttonCANCEL.Size = new System.Drawing.Size(58, 23);
            this.buttonCANCEL.TabIndex = 9;
            this.buttonCANCEL.Text = "CANCEL";
            this.buttonCANCEL.UseVisualStyleBackColor = true;
            this.buttonCANCEL.Click += new System.EventHandler(this.buttonCANCEL_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonCANCEL);
            this.Controls.Add(this.buttonSTOP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.primesListBox);
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
        private System.Windows.Forms.ListBox primesListBox;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSTOP;
        private System.Windows.Forms.Button buttonCANCEL;
    }
}

