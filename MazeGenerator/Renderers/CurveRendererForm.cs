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
    public partial class CurveRendererForm : Form
    {
        private Network network;
        private int corridorWidth;
        private int wallWidth;
        private float tension;
        private int nodeSize;
        private Color colWall;
        private Color colCorridor;
        private Color colBackground;

        public CurveRendererForm(Network n, int CorridorWidth, int WallWidth, int NodeSize, float CurveTension, Color ColorBackground, Color ColorCorridor, Color ColorWall)
        {
            network = n;
            corridorWidth = CorridorWidth;
            wallWidth = WallWidth;
            nodeSize = NodeSize;
            tension = CurveTension;

            colWall = ColorWall;
            colCorridor = ColorCorridor;
            colBackground = ColorBackground;

            InitializeComponent();
        }

        protected void DrawMaze(Graphics g)
        {
            g.Clear(colBackground);

            Pen p;

            if (wallWidth > 0)
            {
                p = new Pen(colWall, corridorWidth + wallWidth);
                DrawNodes(g, p);
            }
            
            p = new Pen(colCorridor, corridorWidth);
            DrawNodes(g, p);            
        }
        
        protected void DrawNodes(Graphics g, Pen p)
        {
            PointF[] renderPoints = new PointF[4];
            Vector2D v;

            foreach(ShapeNode n in network.nodeList)
            {
                PointF centre = n.GetCentre();
                bool bBezierDrawn = false;

                for (int edgeIndex1 = 0; edgeIndex1 < n.points.Count; edgeIndex1++)
                {
                    NodeLink link1 = n.LinkList[edgeIndex1];
                    
                    if (link1 != null && link1.visited == true)
                    {
                        renderPoints[0] = n.GetEdgeCentre(edgeIndex1);

                        v = new Vector2D(renderPoints[0], centre);
                        v.Scale(tension);

                        renderPoints[1] = v.b;

                        renderPoints[0].X *= nodeSize;
                        renderPoints[0].Y *= nodeSize;

                        renderPoints[1].X *= nodeSize;
                        renderPoints[1].Y *= nodeSize;

                        DrawCircle(g, renderPoints[0], p.Width, p.Color);
                        
                        for (int edgeIndex2 = (edgeIndex1 + 1); edgeIndex2 < n.points.Count; edgeIndex2++)
                        {
                            NodeLink link2 = n.LinkList[edgeIndex2];
                            if (link2 != null && link2 != link1 && link2.visited == true)
                            {
                                renderPoints[3] = n.GetEdgeCentre(edgeIndex2);

                                v = new Vector2D(renderPoints[3], centre);
                                v.Scale(tension);

                                renderPoints[3].X *= nodeSize;
                                renderPoints[3].Y *= nodeSize;

                                renderPoints[2] = v.b;
                                renderPoints[2].X *= nodeSize;
                                renderPoints[2].Y *= nodeSize;

                                g.DrawBeziers(p, renderPoints);
                                bBezierDrawn = true;
                            }
                        }

                        if (bBezierDrawn == false)
                        {
                            // A dead end
                            renderPoints[1] = centre;
                            renderPoints[1].X *= nodeSize;
                            renderPoints[1].Y *= nodeSize;

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

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            DrawMaze(g);
        } 
    }
}
