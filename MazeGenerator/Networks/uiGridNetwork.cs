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
    public partial class uiGridNetwork : Form, INetwork
    {
        public uiGridNetwork()
        {
            InitializeComponent();
        }

        public Network INetwork()
        {
            GridNetwork network = new GridNetwork();
            network.Initialize((int)gridWidth.Value, (int)gridHeight.Value, (int)weavePercent.Value, (float)horizontalWeighting.Value);
            return network;
        }

        private void gridWidth_ValueChanged(object sender, EventArgs e)
        {
            //Dirty = true;
        }

        private void gridHeight_ValueChanged(object sender, EventArgs e)
        {
            //Dirty = true;
        }
    }
}
