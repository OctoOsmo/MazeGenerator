namespace MazeGenerator.Networks
{
    partial class uiGridNetwork
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
            this.gridWidth = new System.Windows.Forms.NumericUpDown();
            this.gridHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // gridWidth
            // 
            this.gridWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridWidth.Location = new System.Drawing.Point(95, 12);
            this.gridWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.gridWidth.Name = "gridWidth";
            this.gridWidth.Size = new System.Drawing.Size(120, 29);
            this.gridWidth.TabIndex = 0;
            this.gridWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // gridHeight
            // 
            this.gridHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridHeight.Location = new System.Drawing.Point(95, 47);
            this.gridHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.gridHeight.Name = "gridHeight";
            this.gridHeight.Size = new System.Drawing.Size(120, 29);
            this.gridHeight.TabIndex = 1;
            this.gridHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height";
            // 
            // uiGridNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridHeight);
            this.Controls.Add(this.gridWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "uiGridNetwork";
            this.Text = "uiGridNetwork";
            ((System.ComponentModel.ISupportInitialize)(this.gridWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown gridWidth;
        private System.Windows.Forms.NumericUpDown gridHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}