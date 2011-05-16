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
    public partial class uiCurveRenderer : Form, IRenderableMaze
    {
        protected Bitmap    bmp;
        protected Network   network;
        protected Color     colWall;
        protected Color     colCorridor;
        protected Color     colBackground;

        public uiCurveRenderer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void IRenderableMaze(Network network, PictureBox renderBox)
        {
            if (bmp != null)
            {
                bmp.Dispose();
            }

            this.network = network;
            colBackground = backgroundPanel.BackColor;
            colCorridor = corridorPanel.BackColor;
            colWall = wallPanel.BackColor;            

            BoxF bb = ((ShapeNetwork)network).BoundingBox;

            bmp = new Bitmap(1 + (/*(int)corridorWidth.Value **/ (int)nodeSize.Value * ((int)(Math.Ceiling(bb.Width)))),
                              1 + (/*(int)corridorWidth.Value **/ (int)nodeSize.Value * ((int)(Math.Ceiling(bb.Height)))));

            DrawMaze(Graphics.FromImage(bmp));

            renderBox.Image = bmp;

            /*CurveRendererForm form = new CurveRendererForm( network, 
                                                            (int)corridorWidth.Value, 
                                                            (int)wallWidth.Value, 
                                                            (int)nodeSize.Value, 
                                                            (float)curveTension.Value, 
                                                            backgroundPanel.BackColor, 
                                                            corridorPanel.BackColor, 
                                                            wallPanel.BackColor);
            form.ShowDialog();*/
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

        protected void DrawMaze(Graphics g)
        {
            g.Clear(colBackground);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen p;

            if ((int)wallWidth.Value > 0)
            {
                p = new Pen(colWall, (int)corridorWidth.Value + (int)wallWidth.Value);
                DrawNodes(g, p);
            }

            p = new Pen(colCorridor, (int)corridorWidth.Value);
            DrawNodes(g, p);
        }

        protected void DrawNodes(Graphics g, Pen p)
        {
            PointF[] renderPoints = new PointF[4];
            Vector2D v;

            foreach (KeyValuePair<Node, List<NodeLink>> kvp in network.nodeDict)
            {
                ShapeNode n = kvp.Key as ShapeNode;

                PointF centre = n.GetCentre();
                bool bBezierDrawn = false;

                for (int edgeIndex1 = 0; edgeIndex1 < n.points.Count; edgeIndex1++)
                {
                    NodeLink link1 = n.LinkList[edgeIndex1];

                    if (link1 != null && link1.visited == true)
                    {
                        renderPoints[0] = n.GetEdgeCentre(edgeIndex1);

                        v = new Vector2D(renderPoints[0], centre);
                        v.Scale((float)curveTension.Value);

                        renderPoints[1] = v.b;

                        renderPoints[0].X *= (int)nodeSize.Value;
                        renderPoints[0].Y *= (int)nodeSize.Value;

                        renderPoints[1].X *= (int)nodeSize.Value;
                        renderPoints[1].Y *= (int)nodeSize.Value;

                        DrawCircle(g, renderPoints[0], p.Width, p.Color);

                        for (int edgeIndex2 = (edgeIndex1 + 1); edgeIndex2 < n.points.Count; edgeIndex2++)
                        {
                            NodeLink link2 = n.LinkList[edgeIndex2];
                            if (link2 != null && link2 != link1 && link2.visited == true)
                            {
                                renderPoints[3] = n.GetEdgeCentre(edgeIndex2);

                                v = new Vector2D(renderPoints[3], centre);
                                v.Scale((float)curveTension.Value);

                                renderPoints[3].X *= (int)nodeSize.Value;
                                renderPoints[3].Y *= (int)nodeSize.Value;

                                renderPoints[2] = v.b;
                                renderPoints[2].X *= (int)nodeSize.Value;
                                renderPoints[2].Y *= (int)nodeSize.Value;

                                g.DrawBeziers(p, renderPoints);
                                bBezierDrawn = true;
                            }
                        }

                        if (bBezierDrawn == false)
                        {
                            // A dead end
                            renderPoints[1] = centre;
                            renderPoints[1].X *= (int)nodeSize.Value;
                            renderPoints[1].Y *= (int)nodeSize.Value;

                            g.DrawLine(p, renderPoints[0], renderPoints[1]);
                            DrawCircle(g, renderPoints[1], p.Width, p.Color);
                        }
                    }
                }
            }
        }

        protected void DrawCircle(Graphics g, PointF position, float width, Color color)
        {
            RectangleF rect = new RectangleF(position.X - (width * 0.5f), position.Y - (width * 0.5f), width, width);
            SolidBrush br = new SolidBrush(color);

            g.FillEllipse(br, rect);
        }

    }
}
