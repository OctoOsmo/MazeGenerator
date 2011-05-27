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
    public partial class uiPolarNetwork : Form, INetwork
    {
        public uiPolarNetwork()
        {
            InitializeComponent();
        }

        public Network INetwork()
        {
            PolarNetwork network = new PolarNetwork();
            network.Initialize( (int)numRings.Value, 
                                (float)innerRadius.Value, 
                                (float)ringWidth.Value, 
                                (float)spokeWidth.Value, 
                                (float)ringWeighting.Value, 
                                (float)weavePercent.Value);
            return network;
        }

    }
}
