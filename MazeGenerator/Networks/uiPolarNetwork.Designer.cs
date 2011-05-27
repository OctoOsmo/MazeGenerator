namespace MazeGenerator.Networks
{
    partial class uiPolarNetwork
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
            this.numRings = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ringWidth = new System.Windows.Forms.NumericUpDown();
            this.innerRadius = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.spokeWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ringWeighting = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.weavePercent = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numRings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ringWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.innerRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spokeWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ringWeighting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weavePercent)).BeginInit();
            this.SuspendLayout();
            // 
            // numRings
            // 
            this.numRings.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRings.Location = new System.Drawing.Point(106, 11);
            this.numRings.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRings.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRings.Name = "numRings";
            this.numRings.Size = new System.Drawing.Size(120, 20);
            this.numRings.TabIndex = 0;
            this.numRings.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ring Width";
            // 
            // ringWidth
            // 
            this.ringWidth.DecimalPlaces = 2;
            this.ringWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ringWidth.Location = new System.Drawing.Point(106, 63);
            this.ringWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ringWidth.Name = "ringWidth";
            this.ringWidth.Size = new System.Drawing.Size(120, 20);
            this.ringWidth.TabIndex = 3;
            this.ringWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // innerRadius
            // 
            this.innerRadius.DecimalPlaces = 2;
            this.innerRadius.Location = new System.Drawing.Point(106, 37);
            this.innerRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.innerRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.innerRadius.Name = "innerRadius";
            this.innerRadius.Size = new System.Drawing.Size(120, 20);
            this.innerRadius.TabIndex = 4;
            this.innerRadius.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Inner Radius";
            // 
            // spokeWidth
            // 
            this.spokeWidth.DecimalPlaces = 2;
            this.spokeWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spokeWidth.Location = new System.Drawing.Point(106, 89);
            this.spokeWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spokeWidth.Name = "spokeWidth";
            this.spokeWidth.Size = new System.Drawing.Size(120, 20);
            this.spokeWidth.TabIndex = 6;
            this.spokeWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Spoke Width";
            // 
            // ringWeighting
            // 
            this.ringWeighting.DecimalPlaces = 2;
            this.ringWeighting.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ringWeighting.Location = new System.Drawing.Point(106, 116);
            this.ringWeighting.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ringWeighting.Name = "ringWeighting";
            this.ringWeighting.Size = new System.Drawing.Size(120, 20);
            this.ringWeighting.TabIndex = 8;
            this.ringWeighting.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ring Bias";
            // 
            // weavePercent
            // 
            this.weavePercent.Enabled = false;
            this.weavePercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weavePercent.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.weavePercent.Location = new System.Drawing.Point(106, 142);
            this.weavePercent.Name = "weavePercent";
            this.weavePercent.Size = new System.Drawing.Size(120, 20);
            this.weavePercent.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Weave %";
            // 
            // uiPolarNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.weavePercent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ringWeighting);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.spokeWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.innerRadius);
            this.Controls.Add(this.ringWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numRings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "uiPolarNetwork";
            this.Text = "uiPolarNetwork";
            ((System.ComponentModel.ISupportInitialize)(this.numRings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ringWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.innerRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spokeWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ringWeighting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weavePercent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numRings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ringWidth;
        private System.Windows.Forms.NumericUpDown innerRadius;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown spokeWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ringWeighting;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown weavePercent;
        private System.Windows.Forms.Label label6;
    }
}