namespace MazeGenerator.Renderers
{
    partial class uiCurveRenderer
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
            this.corridorWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.wallButton = new System.Windows.Forms.Button();
            this.corridorButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.curveTension = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.wallWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nodeSize = new System.Windows.Forms.NumericUpDown();
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.wallPanel = new System.Windows.Forms.Panel();
            this.corridorPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.corridorWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.curveTension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeSize)).BeginInit();
            this.SuspendLayout();
            // 
            // corridorWidth
            // 
            this.corridorWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.corridorWidth.Location = new System.Drawing.Point(113, 116);
            this.corridorWidth.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.corridorWidth.Name = "corridorWidth";
            this.corridorWidth.Size = new System.Drawing.Size(94, 22);
            this.corridorWidth.TabIndex = 0;
            this.corridorWidth.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Corridor Width";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // backgroundButton
            // 
            this.backgroundButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundButton.Location = new System.Drawing.Point(15, 12);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(155, 26);
            this.backgroundButton.TabIndex = 2;
            this.backgroundButton.Text = "Background Color";
            this.backgroundButton.UseVisualStyleBackColor = true;
            this.backgroundButton.Click += new System.EventHandler(this.backgroundButton_Click);
            // 
            // wallButton
            // 
            this.wallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallButton.Location = new System.Drawing.Point(15, 44);
            this.wallButton.Name = "wallButton";
            this.wallButton.Size = new System.Drawing.Size(155, 26);
            this.wallButton.TabIndex = 3;
            this.wallButton.Text = "Wall Color";
            this.wallButton.UseVisualStyleBackColor = true;
            this.wallButton.Click += new System.EventHandler(this.wallButton_Click);
            // 
            // corridorButton
            // 
            this.corridorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.corridorButton.Location = new System.Drawing.Point(15, 76);
            this.corridorButton.Name = "corridorButton";
            this.corridorButton.Size = new System.Drawing.Size(155, 26);
            this.corridorButton.TabIndex = 4;
            this.corridorButton.Text = "Corridor Color";
            this.corridorButton.UseVisualStyleBackColor = true;
            this.corridorButton.Click += new System.EventHandler(this.corridorButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Curve Tension";
            // 
            // curveTension
            // 
            this.curveTension.DecimalPlaces = 2;
            this.curveTension.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curveTension.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.curveTension.Location = new System.Drawing.Point(113, 220);
            this.curveTension.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.curveTension.Name = "curveTension";
            this.curveTension.Size = new System.Drawing.Size(94, 22);
            this.curveTension.TabIndex = 6;
            this.curveTension.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.curveTension.ValueChanged += new System.EventHandler(this.curveTension_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Wall Width";
            // 
            // wallWidth
            // 
            this.wallWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallWidth.Location = new System.Drawing.Point(113, 149);
            this.wallWidth.Name = "wallWidth";
            this.wallWidth.Size = new System.Drawing.Size(94, 22);
            this.wallWidth.TabIndex = 8;
            this.wallWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Node Size";
            // 
            // nodeSize
            // 
            this.nodeSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeSize.Location = new System.Drawing.Point(113, 185);
            this.nodeSize.Name = "nodeSize";
            this.nodeSize.Size = new System.Drawing.Size(94, 22);
            this.nodeSize.TabIndex = 10;
            this.nodeSize.Value = new decimal(new int[] {
            28,
            0,
            0,
            0});
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.backgroundPanel.Location = new System.Drawing.Point(177, 12);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(30, 26);
            this.backgroundPanel.TabIndex = 11;
            // 
            // wallPanel
            // 
            this.wallPanel.BackColor = System.Drawing.Color.Black;
            this.wallPanel.Location = new System.Drawing.Point(177, 44);
            this.wallPanel.Name = "wallPanel";
            this.wallPanel.Size = new System.Drawing.Size(30, 26);
            this.wallPanel.TabIndex = 12;
            // 
            // corridorPanel
            // 
            this.corridorPanel.BackColor = System.Drawing.Color.White;
            this.corridorPanel.Location = new System.Drawing.Point(177, 76);
            this.corridorPanel.Name = "corridorPanel";
            this.corridorPanel.Size = new System.Drawing.Size(30, 26);
            this.corridorPanel.TabIndex = 12;
            // 
            // uiCurveRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.corridorPanel);
            this.Controls.Add(this.wallPanel);
            this.Controls.Add(this.backgroundPanel);
            this.Controls.Add(this.nodeSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.wallWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.curveTension);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.corridorButton);
            this.Controls.Add(this.wallButton);
            this.Controls.Add(this.backgroundButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.corridorWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "uiCurveRenderer";
            this.Text = "uiCurveRenderer";
            ((System.ComponentModel.ISupportInitialize)(this.corridorWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.curveTension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown corridorWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button backgroundButton;
        private System.Windows.Forms.Button wallButton;
        private System.Windows.Forms.Button corridorButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown curveTension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown wallWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nodeSize;
        private System.Windows.Forms.Panel backgroundPanel;
        private System.Windows.Forms.Panel wallPanel;
        private System.Windows.Forms.Panel corridorPanel;
    }
}