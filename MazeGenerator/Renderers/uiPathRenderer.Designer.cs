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
            this.corridorWidthCtrl = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.scaleCtrl = new System.Windows.Forms.NumericUpDown();
            this.corridorPanel = new System.Windows.Forms.Panel();
            this.wallPanel = new System.Windows.Forms.Panel();
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.corridorButton = new System.Windows.Forms.Button();
            this.wallButton = new System.Windows.Forms.Button();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.wallWidthCtrl = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.corridorWidthCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallWidthCtrl)).BeginInit();
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
            // corridorWidthCtrl
            // 
            this.corridorWidthCtrl.DecimalPlaces = 2;
            this.corridorWidthCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.corridorWidthCtrl.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.corridorWidthCtrl.Location = new System.Drawing.Point(113, 114);
            this.corridorWidthCtrl.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.corridorWidthCtrl.Name = "corridorWidthCtrl";
            this.corridorWidthCtrl.Size = new System.Drawing.Size(120, 22);
            this.corridorWidthCtrl.TabIndex = 1;
            this.corridorWidthCtrl.Value = new decimal(new int[] {
            55,
            0,
            0,
            131072});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Scale";
            // 
            // scaleCtrl
            // 
            this.scaleCtrl.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.scaleCtrl.Location = new System.Drawing.Point(113, 169);
            this.scaleCtrl.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.scaleCtrl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleCtrl.Name = "scaleCtrl";
            this.scaleCtrl.Size = new System.Drawing.Size(120, 20);
            this.scaleCtrl.TabIndex = 3;
            this.scaleCtrl.Value = new decimal(new int[] {
            15,
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
            // wallWidthCtrl
            // 
            this.wallWidthCtrl.DecimalPlaces = 2;
            this.wallWidthCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallWidthCtrl.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.wallWidthCtrl.Location = new System.Drawing.Point(113, 141);
            this.wallWidthCtrl.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.wallWidthCtrl.Name = "wallWidthCtrl";
            this.wallWidthCtrl.Size = new System.Drawing.Size(120, 22);
            this.wallWidthCtrl.TabIndex = 20;
            this.wallWidthCtrl.Value = new decimal(new int[] {
            18,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Wall Width";
            // 
            // uiPathRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.wallWidthCtrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.corridorPanel);
            this.Controls.Add(this.wallPanel);
            this.Controls.Add(this.backgroundPanel);
            this.Controls.Add(this.corridorButton);
            this.Controls.Add(this.wallButton);
            this.Controls.Add(this.backgroundButton);
            this.Controls.Add(this.scaleCtrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.corridorWidthCtrl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "uiPathRenderer";
            this.Text = "uiDefaultRenderer";
            ((System.ComponentModel.ISupportInitialize)(this.corridorWidthCtrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleCtrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallWidthCtrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown corridorWidthCtrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown scaleCtrl;
        private System.Windows.Forms.Panel corridorPanel;
        private System.Windows.Forms.Panel wallPanel;
        private System.Windows.Forms.Panel backgroundPanel;
        private System.Windows.Forms.Button corridorButton;
        private System.Windows.Forms.Button wallButton;
        private System.Windows.Forms.Button backgroundButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown wallWidthCtrl;
        private System.Windows.Forms.Label label3;
    }
}