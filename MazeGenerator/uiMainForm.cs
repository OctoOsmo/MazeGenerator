using System;
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
            rendererPanel.AddComboItem("Curves", new uiCurveRenderer());

            rendererPanel.SelectItem(0);
            //networkPanel.SelectItem(3);

            renderBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;            

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
            if (networkPanel.SelectedItem is INetwork
                && mazeAlgorithmPanel.SelectedItem is MazeAlgorithm
                && rendererPanel.SelectedItem is IRenderableMaze)
            {
                Network n = ((INetwork)networkPanel.SelectedItem).INetwork();                
                
                ((MazeAlgorithm)mazeAlgorithmPanel.SelectedItem).Generate(n);

                ((IRenderableMaze)rendererPanel.SelectedItem).IRenderableMaze(n, renderBox);       
                
            }
        }

        private void renderBox_Click(object sender, EventArgs e)
        {

        }

        private void saveImageButton_Click(object sender, EventArgs e)
        {
            if (renderBox.Image is Bitmap)
            {
                List<ImageFormat> formats = new List<ImageFormat>();
                formats.Add(ImageFormat.Png);
                formats.Add(ImageFormat.Jpeg);
                formats.Add(ImageFormat.Bmp);

                saveImageDialog.Title = "Save Maze";
                saveImageDialog.Filter = "PNG Image|*.png|JPG Image|*.jpg|BMP Image|*.bmp";
                saveImageDialog.FilterIndex = 1;
                saveImageDialog.DefaultExt = "png";
                saveImageDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (saveImageDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Bitmap bitmap = (Bitmap)renderBox.Image;
                    bitmap.Save(saveImageDialog.FileName, formats[saveImageDialog.FilterIndex - 1]);                    
                }
            }
        }

    }
}
