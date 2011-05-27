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

            if (network is ShapeNetwork)
            {
                RenderShapeNetwork((ShapeNetwork)network, renderBox);
            }
            else if (network is PolarNetwork)
            {
                RenderPolarNetwork((PolarNetwork)network, renderBox);
            }

        }

        void RenderPolarNetwork(PolarNetwork network, PictureBox renderBox)
        {
            float scale = 10;
            bmp = new Bitmap(1 + ((int)(Math.Ceiling(network.Diameter * scale))),
                             1 + ((int)(Math.Ceiling(network.Diameter * scale))));

            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen p = new Pen(Color.Black, (float)corridorWidth.Value);
            SolidBrush br = new SolidBrush(Color.Red);

            foreach (List<NodeLink> linkList in network.nodeDict.Values)
            {
                foreach (NodeLink link in linkList)
                {
                    if (link.visited)
                    {
                        if (link.a != null && link.b != null)
                        {
                            PolarNode nodeA = (PolarNode)link.a;
                            PolarNode nodeB = (PolarNode)link.b;
                            PointF ptA = nodeA.Point;
                            ptA.X += network.Radius;
                            ptA.Y += network.Radius;
                            ptA.X *= scale;
                            ptA.Y *= scale;

                            PointF ptB = nodeB.Point;
                            ptB.X += network.Radius;
                            ptB.Y += network.Radius;
                            ptB.X *= scale;
                            ptB.Y *= scale;

                            g.DrawLine(p, ptA, ptB);
                            DrawCircle(g, ptA, p.Width, p.Color);
                            DrawCircle(g, ptB, p.Width, p.Color);
                        }
                    }
                }
            }

            renderBox.Image = bmp;
        }

        protected void DrawCircle(Graphics g, PointF position, float width, Color color)
        {
            RectangleF rect = new RectangleF(position.X - (width * 0.5f), position.Y - (width * 0.5f), width, width);
            SolidBrush br = new SolidBrush(color);

            g.FillEllipse(br, rect);
        }

        void RenderShapeNetwork(ShapeNetwork network, PictureBox renderBox)
        {
            BoxF bb = network.BoundingBox;

            bmp = new Bitmap(1 + ((int)corridorWidth.Value * ((int)(Math.Ceiling(bb.Width)))),
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
