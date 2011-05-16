namespace MazeGenerator.Renderers
{
    partial class uiPathRenderer
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
            this.label2 = new System.Windows.Forms.Label();
            this.scale = new System.Windows.Forms.NumericUpDown();
            this.corridorPanel = new System.Windows.Forms.Panel();
            this.wallPanel = new System.Windows.Forms.Panel();
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.corridorButton = new System.Windows.Forms.Button();
            this.wallButton = new System.Windows.Forms.Button();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.corridorWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scale)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Corridor Width";
            // 
            // corridorWidth
            // 
            this.corridorWidth.DecimalPlaces = 2;
            this.corridorWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.corridorWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.corridorWidth.Location = new System.Drawing.Point(113, 114);
            this.corridorWidth.Maximum = new decimal(new int[] {
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
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Scale";
            // 
            // scale
            // 
            this.scale.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.scale.Location = new System.Drawing.Point(113, 143);
            this.scale.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.scale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(120, 20);
            this.scale.TabIndex = 3;
            this.scale.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // corridorPanel
            // 
            this.corridorPanel.BackColor = System.Drawing.Color.White;
            this.corridorPanel.Location = new System.Drawing.Point(174, 76);
            this.corridorPanel.Name = "corridorPanel";
            this.corridorPanel.Size = new System.Drawing.Size(30, 26);
            this.corridorPanel.TabIndex = 17;
            // 
            // wallPanel
            // 
            this.wallPanel.BackColor = System.Drawing.Color.Black;
            this.wallPanel.Location = new System.Drawing.Point(174, 44);
            this.wallPanel.Name = "wallPanel";
            this.wallPanel.Size = new System.Drawing.Size(30, 26);
            this.wallPanel.TabIndex = 18;
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BackColor = System.Drawing.Color.LightBlue;
            this.backgroundPanel.Location = new System.Drawing.Point(174, 12);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(30, 26);
            this.backgroundPanel.TabIndex = 16;
            // 
            // corridorButton
            // 
            this.corridorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.corridorButton.Location = new System.Drawing.Point(12, 76);
            this.corridorButton.Name = "corridorButton";
            this.corridorButton.Size = new System.Drawing.Size(155, 26);
            this.corridorButton.TabIndex = 15;
            this.corridorButton.Text = "Corridor Color";
            this.corridorButton.UseVisualStyleBackColor = true;
            this.corridorButton.Click += new System.EventHandler(this.corridorButton_Click);
            // 
            // wallButton
            // 
            this.wallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallButton.Location = new System.Drawing.Point(12, 44);
            this.wallButton.Name = "wallButton";
            this.wallButton.Size = new System.Drawing.Size(155, 26);
            this.wallButton.TabIndex = 14;
            this.wallButton.Text = "Wall Color";
            this.wallButton.UseVisualStyleBackColor = true;
            this.wallButton.Click += new System.EventHandler(this.wallButton_Click);
            // 
            // backgroundButton
            // 
            this.backgroundButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundButton.Location = new System.Drawing.Point(12, 12);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(155, 26);
            this.backgroundButton.TabIndex = 13;
            this.backgroundButton.Text = "Background Color";
            this.backgroundButton.UseVisualStyleBackColor = true;
            this.backgroundButton.Click += new System.EventHandler(this.backgroundButton_Click);
            // 
            // uiPathRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.corridorPanel);
            this.Controls.Add(this.wallPanel);
            this.Controls.Add(this.backgroundPanel);
            this.Controls.Add(this.corridorButton);
            this.Controls.Add(this.wallButton);
            this.Controls.Add(this.backgroundButton);
            this.Controls.Add(this.scale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.corridorWidth);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "uiPathRenderer";
            this.Text = "uiDefaultRenderer";
            ((System.ComponentModel.ISupportInitialize)(this.corridorWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown corridorWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown scale;
        private System.Windows.Forms.Panel corridorPanel;
        private System.Windows.Forms.Panel wallPanel;
        private System.Windows.Forms.Panel backgroundPanel;
        private System.Windows.Forms.Button corridorButton;
        private System.Windows.Forms.Button wallButton;
        private System.Windows.Forms.Button backgroundButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}