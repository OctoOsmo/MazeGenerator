﻿namespace MazeGenerator.Renderers
{
    partial class uiDefaultRenderer
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
            this.label1 = new System.Windows.Forms.Label();
            this.corridorWidth = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.corridorWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Corridor Width";
            // 
            // corridorWidth
            // 
            this.corridorWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.corridorWidth.Location = new System.Drawing.Point(113, 13);
            this.corridorWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.corridorWidth.Name = "corridorWidth";
            this.corridorWidth.Size = new System.Drawing.Size(120, 22);
            this.corridorWidth.TabIndex = 1;
            this.corridorWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // uiDefaultRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.corridorWidth);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "uiDefaultRenderer";
            this.Text = "uiDefaultRenderer";
            ((System.ComponentModel.ISupportInitialize)(this.corridorWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown corridorWidth;
    }
}