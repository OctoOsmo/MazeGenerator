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
    public partial class DefaultRendererForm : Form
    {
        private Network _network;
        private int corridorWidth;

        public DefaultRendererForm(Network n, int CorridorWidth)
        {
            _network = n;
            corridorWidth = CorridorWidth;
            InitializeComponent();
        }

        protected void DrawMaze(Graphics g)
        {
            g.Clear(Color.White);

            Pen p = new Pen(Color.Black, 1f);

            for (int i = 0; i < _network.nodeDict.Count; i++)
            {
                
            }

            foreach (KeyValuePair<Node, List<NodeLink>> kvp in _network.nodeDict)
            {
                ShapeNode s = (ShapeNode)kvp.Key;
                for (int i2 = 0; i2 < s.points.Count; i2++)
                {
                    if (s.LinkList[i2] == null || s.LinkList[i2].visited == false)
                    {
                        PointF p1 = s.points[i2];
                        PointF p2 = s.points[(i2 + 1) % s.points.Count];
                        p1.X *= corridorWidth;
                        p1.Y *= corridorWidth;
                        p2.X *= corridorWidth;
                        p2.Y *= corridorWidth;
                        g.DrawLine(p, p1, p2);
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            DrawMaze(g);
        } 

    }
}
