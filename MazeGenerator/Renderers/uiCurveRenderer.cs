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
    public partial class uiCurveRenderer : Form, IRenderableMaze
    {
        public uiCurveRenderer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void IRenderableMaze(Network network)
        {
            CurveRendererForm form = new CurveRendererForm( network, 
                                                            (int)corridorWidth.Value, 
                                                            (int)wallWidth.Value, 
                                                            (int)nodeSize.Value, 
                                                            (float)curveTension.Value, 
                                                            backgroundPanel.BackColor, 
                                                            corridorPanel.BackColor, 
                                                            wallPanel.BackColor);
            form.ShowDialog();
        }

        private void curveTension_ValueChanged(object sender, EventArgs e)
        {

        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                backgroundPanel.BackColor = colorDialog1.Color;                
            }
        }

        private void wallButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                wallPanel.BackColor = colorDialog1.Color;
            }
        }

        private void corridorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                corridorPanel.BackColor = colorDialog1.Color;
            }
        }
    }
}
