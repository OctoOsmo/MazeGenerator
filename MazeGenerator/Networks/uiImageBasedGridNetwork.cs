using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MazeGenerator.Networks
{
    public partial class uiImageBasedGridNetwork : Form, GenerateNetwork
    {
        public uiImageBasedGridNetwork()
        {
            InitializeComponent();
        }

        public Network GenerateNetwork()
        {
            ImageBasedGridNetwork network = new ImageBasedGridNetwork();
            network.Initialize(filename.Text, (int)subdivisions.Value);
            return network;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename.Text = openFileDialog1.FileName;
            }
        }
    }
}
