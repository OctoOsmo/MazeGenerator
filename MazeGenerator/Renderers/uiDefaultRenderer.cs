using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MazeGenerator.Renderers
{
    public partial class uiDefaultRenderer : Form, RenderMaze
    {
        public uiDefaultRenderer()
        {
            InitializeComponent();
        }

        public void RenderMaze(Network network)
        {
            DefaultRendererForm form = new DefaultRendererForm(network, (int)corridorWidth.Value);
            form.ShowDialog();
        }
    }
}
