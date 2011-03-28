using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace MazeGenerator
{
    class ShapeNetwork : Network
    {
        protected void CalculateWeightsByArea()
        {
            // Currently only supports binary weightings.

            foreach (KeyValuePair<Node, List<NodeLink>> kvp in nodeDict)
            {
                foreach (NodeLink link in kvp.Value)
                {
                    if (link != null)
                    {
                        if (((RectNode)link.a).Area == ((RectNode)link.b).Area)
                        {
                            link.weight = 1.0f;
                        }
                        else
                        {
                            link.weight = 0.0f;
                        }
                    }
                }
            }
        }

        protected void ConnectEdge(ShapeNode n, ref int index, List<Node> nl)
        {
            // Attempts to connect an edge(index) on a ShapeNode(n) against all edges in a list of Nodes(nl)
            // Subdivides matching edges accordingly if the intersection is less than the entire length of one of the edges.
            // Note: Subdivision code is fairly basic at the moment. Some edge cases are not covered.

            if (n.LinkList[index] != null)
            {
                return;
            }

            Vector2D edge = n.GetEdge(index);
            Vector2D norm1 = edge.Normalized();

            foreach (ShapeNode n2 in nl)
            {
                if (n2 != n)
                {
                    for (int index2 = 0; index2 < n2.points.Count; index2++)
                    {
                        Vector2D edge2 = n2.GetAntiClockwiseEdge(index2);
                        Vector2D norm2 = edge2.Normalized();

                        if (edge.a == edge2.a && norm1 == norm2)
                        {
                            NodeLink nodeLink = ShapeNode.ConnectEdges(n, index, n2, index2);

                            if (edge.Length() > edge2.Length())
                            {
                                n.AddPoint(index + 1, edge2.b);
                                index--;
                            }

                            if (edge2.Length() > edge.Length())
                            {
                                n2.AddPoint(index2 + 1, edge.b);
                                n2.LinkList[index2 + 1] = n2.LinkList[index2];
                                n2.LinkList[index2] = null;
                                ConnectEdge(n2, ref index2, nl);
                            }

                            return;
                        }
                    }
                }
            }

        }

        protected void ConnectShapes(List<Node> nl)
        {
            foreach (ShapeNode n in nl)
            {
                // For each edge
                for (int index = 0; index < n.points.Count; index++)
                {
                    ConnectEdge(n, ref index, nl);
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class ShapeNode : Node
    {
        public List<PointF> points = new List<PointF>(); // Ordered clockwise

        public Vector2D GetEdge(int index)
        {
            PointF p1 = points[index];
            PointF p2 = points[(index + 1) % points.Count];
            return new Vector2D(p1, p2);
        }

        public PointF GetEdgeCentre(int index)
        {
            Vector2D v = GetEdge(index);
            PointF point = new PointF((v.a.X + v.b.X) * 0.5f, (v.a.Y + v.b.Y) * 0.5f);
            return point;
        }

        public Vector2D GetAntiClockwiseEdge(int index)
        {            
            PointF p1 = points[index];
            PointF p2 = points[(index + 1) % points.Count];
            return new Vector2D(p2, p1);
        }

        public PointF GetCentre()
        {
            PointF result;

            if (points.Count == 3)
            {
                result = new PointF();
                result = points[0];

                result.X += points[1].X;
                result.Y += points[1].Y;

                result.X += points[2].X;
                result.Y += points[2].Y;

                result.X /= 3;
                result.Y /= 3;
            }
            else
            {
                PointF ptMin = points[0];
                PointF ptMax = points[0];

                foreach (PointF point in points)
                {
                    ptMin.X = Math.Min(ptMin.X, point.X);
                    ptMin.Y = Math.Min(ptMin.Y, point.Y);
                    ptMax.X = Math.Max(ptMax.X, point.X);
                    ptMax.Y = Math.Max(ptMax.Y, point.Y);
                }

                result = new PointF((ptMin.X + ptMax.X) * 0.5f, (ptMin.Y + ptMax.Y) * 0.5f);
            }

            return result;
        }

        public void AddPoint(int index, PointF p)
        {
            points.Insert(index, p);
            LinkList.Insert(index, null);
        }

        public int FindPointIndex(PointF p)
        {
            return points.FindIndex
                (
                    delegate(PointF p2)
                    {
                        return p2 == p;
                    }
                );
        }

        static public NodeLink ConnectEdges(ShapeNode node1, int index1, ShapeNode node2, int index2)
        {
            NodeLink result;

            if (node1.LinkList[index1] != null)
            {
                result = node1.LinkList[index1];
            }
            else
            {
                NodeLink newLink = new NodeLink(node1, node2);

                /*
                string s;
                s = "(" + ((RectNode)node1).rect.Left + ", " + ((RectNode)node1).rect.Top + ")";
                s += "(" + ((RectNode)node1).rect.Right + ", " + ((RectNode)node1).rect.Bottom + ")";
                s += " - ";
                s += "(" + ((RectNode)node2).rect.Left + ", " + ((RectNode)node2).rect.Top + ")";
                s += "(" + ((RectNode)node2).rect.Right + ", " + ((RectNode)node2).rect.Bottom + ")";

                System.Diagnostics.Trace.WriteLine(" : New Link", s);
                */

                node1.LinkList[index1] = newLink;
                node2.LinkList[index2] = newLink;

                result = newLink;
            }

            return result;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class RectNode : ShapeNode
    {
        public RectangleF rect;

        public float Area
        {
            get
            {
                return rect.Width * rect.Height;
            }
        }

        private RectNode() { }

        public RectNode(PointF point, SizeF size)
        {
            rect = new RectangleF(point, size);

            points.Add(point);
            points.Add(new PointF(point.X + size.Width, point.Y));
            points.Add(new PointF(point.X + size.Width, point.Y + size.Height));
            points.Add(new PointF(point.X, point.Y + size.Height));

            foreach (PointF p in points)
            {
                LinkList.Add(null);
            }
        }
    }
}