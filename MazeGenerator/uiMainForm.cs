﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using MazeGenerator.Networks;
using MazeGenerator.Renderers;

namespace MazeGenerator
{
    public partial class uiMainForm : Form
    {
        Maze maze;
        BackgroundWorker bw;
        TimeSpan time;

        public uiMainForm()
        {
            InitializeComponent();
            
            networkPanel.AddComboItem("Grid", new uiGridNetwork());
            networkPanel.AddComboItem("Image-based Grid", new uiImageBasedGridNetwork());
            networkPanel.AddComboItem("Triangles", new TriangleNetwork());
            networkPanel.AddComboItem("Diamonds", new DiamondNetwork());

            mazeAlgorithmPanel.AddComboItem("Growing Tree", new GrowingTree());
            mazeAlgorithmPanel.AddComboItem("Binary Weighted Growing Tree", new BinaryWeightedGrowingTree());

            rendererPanel.AddComboItem("Default", new uiDefaultRenderer());

            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //uiProgressLabel.Text = "Saving...";

            maze = e.Result as Maze;            
            //((GrowingTreeMaze)maze).DrawMaze(Color.Black, Convert.ToInt32(uiCorridorWidthNum.Value)).Save(uiSaveMazeDialog.FileName, ImageFormat.Bmp);

            //uiProgressLabel.Text = String.Format("Done in {0}", time.ToString());
            //uiGenerateButton.Enabled = true;
            //uiProgressBar.Value = 0;
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //uiProgressBar.Value = e.ProgressPercentage;
            //uiProgressBar.Update();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {            
            Maze m = e.Argument as Maze;
            time = m.Generate(ref bw);
            e.Result = m;
        }

        private void uiMainForm_Load(object sender, EventArgs e)
        {

        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            if (networkPanel.SelectedItem is GenerateNetwork
                && mazeAlgorithmPanel.SelectedItem is MazeAlgorithm
                && rendererPanel.SelectedItem is RenderMaze)
            {
                Network n = ((GenerateNetwork)networkPanel.SelectedItem).GenerateNetwork();                
                
                ((MazeAlgorithm)mazeAlgorithmPanel.SelectedItem).Generate(n);

                ((RenderMaze)rendererPanel.SelectedItem).RenderMaze(n);
            }
        }

    }
}
