﻿namespace ReverseRepresentation
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
            this.Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(304, 367);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(100, 37);
            this.Start.TabIndex = 2;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.OnStartClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(158, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 68);
            this.label1.TabIndex = 3;
            this.label1.Text = "Метод обратных итераций для уравнения:  z^2 + c. \r\n\r\n\r\n\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 603);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Reverse";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button Start;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}