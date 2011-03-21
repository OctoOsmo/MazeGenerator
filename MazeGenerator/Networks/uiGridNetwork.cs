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
            network.Initialize((int)gridWidth.Value, (int)gridHeight.Value);
            return network;
        }
    }
}
