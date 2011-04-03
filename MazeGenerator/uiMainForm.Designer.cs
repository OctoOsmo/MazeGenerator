namespace MazeGenerator
{
    partial class uiMainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.NetworkPage = new System.Windows.Forms.TabPage();
            this.AlgorithmPage = new System.Windows.Forms.TabPage();
            this.SolverPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.RendererPage = new System.Windows.Forms.TabPage();
            this.GoButton = new System.Windows.Forms.Button();
            this.renderBox = new System.Windows.Forms.PictureBox();
            this.saveImageButton = new System.Windows.Forms.Button();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.networkPanel = new MazeGenerator.ComboPanel();
            this.mazeAlgorithmPanel = new MazeGenerator.ComboPanel();
            this.rendererPanel = new MazeGenerator.ComboPanel();
            this.tabControl.SuspendLayout();
            this.NetworkPage.SuspendLayout();
            this.AlgorithmPage.SuspendLayout();
            this.SolverPage.SuspendLayout();
            this.RendererPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.renderBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl.Controls.Add(this.NetworkPage);
            this.tabControl.Controls.Add(this.AlgorithmPage);
            this.tabControl.Controls.Add(this.SolverPage);
            this.tabControl.Controls.Add(this.RendererPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(315, 349);
            this.tabControl.TabIndex = 0;
            // 
            // NetworkPage
            // 
            this.NetworkPage.BackColor = System.Drawing.Color.Transparent;
            this.NetworkPage.Controls.Add(this.networkPanel);
            this.NetworkPage.Location = new System.Drawing.Point(4, 22);
            this.NetworkPage.Name = "NetworkPage";
            this.NetworkPage.Padding = new System.Windows.Forms.Padding(3);
            this.NetworkPage.Size = new System.Drawing.Size(307, 323);
            this.NetworkPage.TabIndex = 0;
            this.NetworkPage.Text = "Network";
            // 
            // AlgorithmPage
            // 
            this.AlgorithmPage.Controls.Add(this.mazeAlgorithmPanel);
            this.AlgorithmPage.Location = new System.Drawing.Point(4, 22);
            this.AlgorithmPage.Name = "AlgorithmPage";
            this.AlgorithmPage.Padding = new System.Windows.Forms.Padding(3);
            this.AlgorithmPage.Size = new System.Drawing.Size(307, 232);
            this.AlgorithmPage.TabIndex = 1;
            this.AlgorithmPage.Text = "Maze Algorithm";
            this.AlgorithmPage.UseVisualStyleBackColor = true;
            // 
            // SolverPage
            // 
            this.SolverPage.Controls.Add(this.label1);
            this.SolverPage.Location = new System.Drawing.Point(4, 22);
            this.SolverPage.Name = "SolverPage";
            this.SolverPage.Padding = new System.Windows.Forms.Padding(3);
            this.SolverPage.Size = new System.Drawing.Size(307, 232);
            this.SolverPage.TabIndex = 3;
            this.SolverPage.Text = "Maze Solver";
            this.SolverPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TODO";
            // 
            // RendererPage
            // 
            this.RendererPage.Controls.Add(this.rendererPanel);
            this.RendererPage.Location = new System.Drawing.Point(4, 22);
            this.RendererPage.Name = "RendererPage";
            this.RendererPage.Padding = new System.Windows.Forms.Padding(3);
            this.RendererPage.Size = new System.Drawing.Size(307, 232);
            this.RendererPage.TabIndex = 4;
            this.RendererPage.Text = "Renderer";
            this.RendererPage.UseVisualStyleBackColor = true;
            // 
            // GoButton
            // 
            this.GoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoButton.Location = new System.Drawing.Point(613, 367);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(91, 34);
            this.GoButton.TabIndex = 1;
            this.GoButton.Text = "Go!";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // renderBox
            // 
            this.renderBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.renderBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.renderBox.Location = new System.Drawing.Point(330, 13);
            this.renderBox.Name = "renderBox";
            this.renderBox.Size = new System.Drawing.Size(374, 348);
            this.renderBox.TabIndex = 2;
            this.renderBox.TabStop = false;
            this.renderBox.Click += new System.EventHandler(this.renderBox_Click);
            // 
            // saveImageButton
            // 
            this.saveImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveImageButton.BackgroundImage = global::MazeGenerator.Properties.Resources.save;
            this.saveImageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveImageButton.Location = new System.Drawing.Point(570, 367);
            this.saveImageButton.Name = "saveImageButton";
            this.saveImageButton.Size = new System.Drawing.Size(33, 34);
            this.saveImageButton.TabIndex = 3;
            this.saveImageButton.UseVisualStyleBackColor = true;
            this.saveImageButton.Click += new System.EventHandler(this.saveImageButton_Click);
            // 
            // networkPanel
            // 
            this.networkPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkPanel.Location = new System.Drawing.Point(3, 3);
            this.networkPanel.Name = "networkPanel";
            this.networkPanel.Padding = new System.Windows.Forms.Padding(4);
            this.networkPanel.Size = new System.Drawing.Size(301, 317);
            this.networkPanel.TabIndex = 0;
            // 
            // mazeAlgorithmPanel
            // 
            this.mazeAlgorithmPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mazeAlgorithmPanel.Location = new System.Drawing.Point(3, 3);
            this.mazeAlgorithmPanel.Name = "mazeAlgorithmPanel";
            this.mazeAlgorithmPanel.Padding = new System.Windows.Forms.Padding(4);
            this.mazeAlgorithmPanel.Size = new System.Drawing.Size(301, 226);
            this.mazeAlgorithmPanel.TabIndex = 0;
            // 
            // rendererPanel
            // 
            this.rendererPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rendererPanel.Location = new System.Drawing.Point(3, 3);
            this.rendererPanel.Name = "rendererPanel";
            this.rendererPanel.Padding = new System.Windows.Forms.Padding(4);
            this.rendererPanel.Size = new System.Drawing.Size(301, 226);
            this.rendererPanel.TabIndex = 0;
            // 
            // uiMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 409);
            this.Controls.Add(this.saveImageButton);
            this.Controls.Add(this.renderBox);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "uiMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Maze Generator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.uiMainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.NetworkPage.ResumeLayout(false);
            this.AlgorithmPage.ResumeLayout(false);
            this.SolverPage.ResumeLayout(false);
            this.SolverPage.PerformLayout();
            this.RendererPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.renderBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage NetworkPage;
        private System.Windows.Forms.TabPage AlgorithmPage;
        private System.Windows.Forms.TabPage SolverPage;
        private System.Windows.Forms.TabPage RendererPage;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Label label1;
        private ComboPanel mazeAlgorithmPanel;
        private ComboPanel rendererPanel;
        private ComboPanel networkPanel;
        private System.Windows.Forms.PictureBox renderBox;
        private System.Windows.Forms.Button saveImageButton;
        private System.Windows.Forms.SaveFileDialog saveImageDialog;
    }
}

