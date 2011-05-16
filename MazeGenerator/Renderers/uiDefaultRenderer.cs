using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MazeGenerator.Networks;

namespace MazeGenerator.Renderers
{
    public partial class uiDefaultRenderer : Form, IRenderableMaze
    {
        Bitmap bmp;

        public uiDefaultRenderer()
        {
            InitializeComponent();
        }

        public void IRenderableMaze(Network network, PictureBox renderBox)
        {
            if (bmp != null)
            {
                bmp.Dispose();
            }

            BoxF bb = ((ShapeNetwork)network).BoundingBox;

            bmp = new Bitmap( 1 + ((int)corridorWidth.Value * ((int)(Math.Ceiling(bb.Width)))),
                              1 + ((int)corridorWidth.Value * ((int)(Math.Ceiling(bb.Height)))));

            DrawMaze(network, Graphics.FromImage(bmp));

            renderBox.Image = bmp;
        }

        protected void DrawMaze(Network _network, Graphics g)
        {
            g.Clear(Color.White);

            Pen p = new Pen(Color.Black, 1f);

            foreach (Node n in _network.nodeDict.Keys)
            {
                ShapeNode s = (ShapeNode)n;
                for (int i2 = 0; i2 < s.points.Count; i2++)
                {
                    if (s.LinkList[i2] == null || s.LinkList[i2].visited == false)
                    {
                        PointF p1 = s.points[i2];
                        PointF p2 = s.points[(i2 + 1) % s.points.Count];
                        p1.X *= (int)corridorWidth.Value;
                        p1.Y *= (int)corridorWidth.Value;
                        p2.X *= (int)corridorWidth.Value;
                        p2.Y *= (int)corridorWidth.Value;
                        g.DrawLine(p, p1, p2);
                    }
                }
            }
        }

    }
}
