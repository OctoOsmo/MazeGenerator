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
    public partial class uiPathRenderer : Form, IRenderableMaze
    {

        protected Color     colWall;
        protected Color     colCorridor;
        protected Color     colBackground;
        
        protected float     worldScale;
        protected PointF    worldOffset;

        protected float     corridorWidth;
        protected float     wallWidth;

        Bitmap bmp;

        public uiPathRenderer()
        {
            InitializeComponent();
        }

        public void IRenderableMaze(Network network, PictureBox renderBox)
        {
            if (bmp != null)
            {
                bmp.Dispose();
            }

            colBackground = backgroundPanel.BackColor;
            colCorridor = corridorPanel.BackColor;
            colWall = wallPanel.BackColor;
            worldScale = (float)scaleCtrl.Value;
            
            worldOffset.X = 0.0f;
            worldOffset.Y = 0.0f;

            corridorWidth = (float)corridorWidthCtrl.Value;
            wallWidth = (float)wallWidthCtrl.Value;
            //corrWidth = (float)10.0f;

            if (network is ShapeNetwork)
            {
                RenderShapeNetwork(network);
            }
            else if(network is PolarNetwork)
            {
                RenderPolarNetwork((PolarNetwork)network);
            }
            
            renderBox.Image = bmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="network"></param>
        protected void RenderPolarNetwork(PolarNetwork network)
        {
            worldOffset.X = network.Radius;
            worldOffset.Y = network.Radius;

            bmp = new Bitmap(1 + ((int)(Math.Ceiling(network.Diameter * worldScale))),
                             1 + ((int)(Math.Ceiling(network.Diameter * worldScale))));

            Graphics g = Graphics.FromImage(bmp);
            g.Clear(colBackground);

            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen penWall = new Pen(colWall, worldScale * (corridorWidth + wallWidth));
            Pen penCorridor = new Pen(colCorridor, worldScale * (corridorWidth));
            //SolidBrush br = new SolidBrush(Color.Red);

            List<NodeLink> renderedLinks = new List<NodeLink>();
            
            foreach (Node node in network.nodeDict.Keys)
            {
                PolarNode pn = (PolarNode)node;

                PointF ptA = pn.Point;
                LocalToWorld(ref ptA);
                DrawCircle(g, ptA, worldScale * (((Math.Max(pn.size, corridorWidth) + wallWidth) * 0.5f)), penWall.Color);
            }


            foreach (List<NodeLink> linkList in network.nodeDict.Values)
            {
                foreach (NodeLink link in linkList)
                {
                    if (!renderedLinks.Contains(link))
                    {
                        if (link.visited)
                        {
                            if (link.a != null && link.b != null)
                            {
                                PolarNode nodeA = (PolarNode)link.a;
                                PolarNode nodeB = (PolarNode)link.b;
                                PointF ptA = nodeA.Point;
                                PointF ptB = nodeB.Point;
                                LocalToWorld(ref ptA);
                                LocalToWorld(ref ptB);

                                float minNodeSize = Math.Min(nodeA.size, nodeB.size);

                                penWall.Width = worldScale * (corridorWidth + minNodeSize  + wallWidth);
                                penCorridor.Width = worldScale * (corridorWidth + minNodeSize);
                                g.DrawLine(penWall, ptA, ptB);
                                g.DrawLine(penCorridor, ptA, ptB);

                                renderedLinks.Add(link);
                            }
                        }

                        
                    }
                }

            }

            // Clean up any path overlap
            foreach (NodeLink link in renderedLinks)
            {
                PolarNode nodeA = (PolarNode)link.a;
                PolarNode nodeB = (PolarNode)link.b;
                PointF ptA = nodeA.Point;
                PointF ptB = nodeB.Point;

                Vector2D vA = new Vector2D(ptA, ptB);
                vA = vA.Normalized();
                vA.Scale(((Math.Max(nodeA.size, corridorWidth)) * 0.5f) + wallWidth);

                Vector2D vB = new Vector2D(ptB, ptA);
                vB = vB.Normalized();
                vB.Scale(((Math.Max(nodeB.size, corridorWidth)) * 0.5f) + wallWidth);

                PointF ptA2 = nodeA.Point;
                ptA2.X += vA.b.X;
                ptA2.Y += vA.b.Y;

                PointF ptB2 = nodeB.Point;
                ptB2.X += vB.b.X;
                ptB2.Y += vB.b.Y;

                LocalToWorld(ref ptA);
                LocalToWorld(ref ptA2);
                LocalToWorld(ref ptB);
                LocalToWorld(ref ptB2);

                float minNodeSize = Math.Min(nodeA.size, nodeB.size);

                penCorridor.Width = worldScale * (corridorWidth + minNodeSize);
                g.DrawLine(penCorridor, ptA, ptA2);                
                g.DrawLine(penCorridor, ptB, ptB2);
            }

            //penCorridor.Color = Color.Red; // for debug - Highlights all rendered nodes
            foreach (Node node in network.nodeDict.Keys)
            {
                PolarNode pn = (PolarNode)node;

                PointF ptA = pn.Point;
                LocalToWorld(ref ptA);
                DrawCircle(g, ptA, worldScale * (Math.Max(pn.size, corridorWidth) * 0.5f), penCorridor.Color);
            }

        }

        protected void LocalToWorld(ref PointF pt)
        {
            pt.X += worldOffset.X;
            pt.Y += worldOffset.Y;
            pt.X *= worldScale;
            pt.Y *= worldScale;
        }

        protected void DrawCircle(Graphics g, PointF position, float radius, Color color)
        {
            RectangleF rect = new RectangleF(position.X - radius, position.Y - radius, radius * 2.0f, radius * 2.0f);
            SolidBrush br = new SolidBrush(color);

            g.FillEllipse(br, rect);
        }

        protected void RenderShapeNetwork(Network network)
        {
            BoxF bb = ((ShapeNetwork)network).BoundingBox;

            bmp = new Bitmap(1 + ((int)scaleCtrl.Value * ((int)(Math.Ceiling(bb.Width)))),
                              1 + ((int)scaleCtrl.Value * ((int)(Math.Ceiling(bb.Height)))));

            DrawMaze(network, Graphics.FromImage(bmp));
        }

        protected void DrawMaze(Network _network, Graphics g)
        {
            g.Clear(colBackground);

            Pen p = new Pen(colWall, 1f);
            SolidBrush brush = new SolidBrush(colCorridor);
            SolidBrush brushDebug = new SolidBrush(Color.LightGray);
            foreach (Node n in _network.nodeDict.Keys)
            {
                ShapeNode s = (ShapeNode)n;
                PointF centre = s.GetCentre();

                // Create centre area and region fill it.
                PointF[] centrePoints = s.points.ToArray();

                for (int pointIndex = 0; pointIndex < s.points.Count; pointIndex++)
                {
                    Vector2D vec = new Vector2D(centre, s.points[pointIndex]);
                    vec.Scale((float)corridorWidthCtrl.Value);
                    
                    centrePoints[pointIndex].X = vec.b.X * (float)scaleCtrl.Value;
                    centrePoints[pointIndex].Y = vec.b.Y * (float)scaleCtrl.Value;
                }

                g.FillPolygon(/*brushDebug*/brush, centrePoints);
                
                // Render edges
                for (int pointIndex = 0; pointIndex < s.points.Count; pointIndex++)
                {
                    int nextIndex = (pointIndex + 1) % s.points.Count;

                    PointF centre1 = centrePoints[pointIndex];
                    PointF centre2 = centrePoints[nextIndex];

                    if (s.LinkList[pointIndex] == null || s.LinkList[pointIndex].visited == false)
                    {
                        // Edge unvisited
                        // Draw a line along edge of centre area
                        g.DrawLine(p, centre1, centre2);
                    }
                    else
                    {
                        // Calculate outer edge (in screen space)
                        PointF p1 = s.points[pointIndex];
                        PointF p2 = s.points[nextIndex];
                        p1.X *= (float)scaleCtrl.Value;
                        p1.Y *= (float)scaleCtrl.Value;
                        p2.X *= (float)scaleCtrl.Value;
                        p2.Y *= (float)scaleCtrl.Value;

                        // worldScale outer edge by corridor size
                        Vector2D vec = new Vector2D(p1, p2);
                        vec.Scale(0.5f - (0.5f * (float)corridorWidthCtrl.Value));
                        PointF outer1 = vec.b;

                        vec.a = p1;
                        vec.b = p2;
                        vec.Scale(0.5f + (0.5f * (float)corridorWidthCtrl.Value));
                        PointF outer2 = vec.b;

                        // Fill region between outer and inner edge
                        PointF[] poly = { outer1, centre1, centre2, outer2 };
                        g.FillPolygon(brush, poly);

                        // Draw lines from outer edge points -> centre edge points.
                        g.DrawLine(p, outer1, centre1);
                        g.DrawLine(p, outer2, centre2);                                                
                    }
                }
            }
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
