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

        protected Color colWall;
        protected Color colCorridor;
        protected Color colBackground;

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

            BoxF bb = ((ShapeNetwork)network).BoundingBox;

            bmp = new Bitmap( 1 + ((int)scale.Value * ((int)(Math.Ceiling(bb.Width)))),
                              1 + ((int)scale.Value * ((int)(Math.Ceiling(bb.Height)))));

            DrawMaze(network, Graphics.FromImage(bmp));

            renderBox.Image = bmp;
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
                    vec.Scale((float)corridorWidth.Value);
                    
                    centrePoints[pointIndex].X = vec.b.X * (float)scale.Value;
                    centrePoints[pointIndex].Y = vec.b.Y * (float)scale.Value;
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
                        p1.X *= (float)scale.Value;
                        p1.Y *= (float)scale.Value;
                        p2.X *= (float)scale.Value;
                        p2.Y *= (float)scale.Value;

                        // Scale outer edge by corridor size
                        Vector2D vec = new Vector2D(p1, p2);
                        vec.Scale(0.5f - (0.5f * (float)corridorWidth.Value));
                        PointF outer1 = vec.b;

                        vec.a = p1;
                        vec.b = p2;
                        vec.Scale(0.5f + (0.5f * (float)corridorWidth.Value));
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
