using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace MazeGenerator.Networks
{
    /// <summary>
    /// </summary>
    class TriangleNetwork : TesselatingNetwork, INetwork
    {
        protected Random _random = new Random();

        public void Initialize()
        {
            gridSize.Width = 30;
            gridSize.Height = 30;

            grid = new List<Node>[gridSize.Width, gridSize.Height];

            for (int x = 0; x < gridSize.Width; x++)
            {
                for (int y = 0; y < gridSize.Height; y++)
                {
                    grid[x, y] = new List<Node>();
                    PointF offset = new PointF(x, y);
                    AddTriangleGridCell(offset, 1, ref grid[x, y]);
                }
            }

            ConnectGrid();
            CalculateBoundingBox();

            // Add start and end nodes
            Node startNode = grid[0, 0][0];
            startNode.LinkList[2] = new NodeLink(startNode, null);
            startNode.LinkList[2].visited = true;

            Node endNode = grid[gridSize.Width - 1, gridSize.Height - 1][1];
            endNode.LinkList[2] = new NodeLink(endNode, null);
            endNode.LinkList[2].visited = true;


            System.Diagnostics.Trace.WriteLine("\n\n");
            System.Diagnostics.Trace.WriteLine("Nodes = " + nodeDict.Count);
            System.Diagnostics.Trace.WriteLine("NodeLinks = " + Network.CountNodeLinks(nodeDict));
            System.Diagnostics.Trace.WriteLine("\n\n");
        }

        public Network INetwork()
        {
            TriangleNetwork network = new TriangleNetwork();
            network.Initialize();
            return network;
        }

        protected void AddTriangleGridCell(PointF offset, float size, ref List<Node> cellNodeList)
        {
            int oldNodeListCount = nodeDict.Count;

            SizeF cellSize = new SizeF(size, size);
            PointF point = new PointF();

            Point i = new Point(0,0);
            point.X = offset.X + (i.X * size);
            point.Y = offset.Y + (i.Y * size);
            
            // Randomly flip orientation of triangles in a cell
            if(_random.Next(0,2) == 0)
            {
                ShapeNode node = new ShapeNode();
                node.AddPoint(0, point);
                point.X += size;
                point.Y += size;
                node.AddPoint(1, point);
                point.X -= size;
                node.AddPoint(2, point);
                nodeDict.Add(node, node.LinkList);

                node = new ShapeNode();
                point.X += size;
                node.AddPoint(0, point);
                point.X -= size;
                point.Y -= size;
                node.AddPoint(1, point);
                point.X += size;
                node.AddPoint(2, point);
                nodeDict.Add(node, node.LinkList);
            }
            else
            {
                ShapeNode node = new ShapeNode();
                point.X += size;
                node.AddPoint(0, point);
                point.X -= size;
                point.Y += size;
                node.AddPoint(1, point);
                point.Y -= size;
                node.AddPoint(2, point);
                nodeDict.Add(node, node.LinkList);

                node = new ShapeNode();
                point.Y += size;
                node.AddPoint(0, point);
                point.X += size;
                point.Y -= size;
                node.AddPoint(1, point);
                point.Y += size;
                node.AddPoint(2, point);
                nodeDict.Add(node, node.LinkList);
            }

            for (int index = oldNodeListCount; index < nodeDict.Count; index++)
            {
                cellNodeList.Add(nodeDict.ElementAt(index).Key);
            }

        }

    }
}