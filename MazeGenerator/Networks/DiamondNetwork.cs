﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace MazeGenerator.Networks
{
    /// <summary>
    /// A _network of tesselating diamonds.
    /// </summary>
    class DiamondNetwork : TesselatingNetwork, INetwork
    {
        //protected Random _random = new Random();
        private PointF[,] d = new PointF[6, 4];

        public void Initialize()
        {
            d[0, 0] = new PointF(0, 0.5f);
            d[0, 1] = new PointF(0.5f, 0);
            d[0, 2] = new PointF(1, 0.5f);
            d[0, 3] = new PointF(0.5f, 1);

            d[1, 0] = new PointF(0, 0.5f);
            d[1, 1] = new PointF(0.5f, 1);
            d[1, 2] = new PointF(0.5f, 2);
            d[1, 3] = new PointF(0, 1.5f);

            d[2, 0] = new PointF(0.5f, 1);
            d[2, 1] = new PointF(1, 0.5f);
            d[2, 2] = new PointF(1, 1.5f);
            d[2, 3] = new PointF(0.5f, 2);

            d[3, 0] = new PointF(0.5f, 2);
            d[3, 1] = new PointF(1, 1.5f);
            d[3, 2] = new PointF(1.5f, 2);
            d[3, 3] = new PointF(1, 2.5f);

            d[4, 0] = new PointF(0, 2.5f);
            d[4, 1] = new PointF(0.5f, 2);
            d[4, 2] = new PointF(0.5f, 3);
            d[4, 3] = new PointF(0, 3.5f);

            d[5, 0] = new PointF(0.5f, 2);
            d[5, 1] = new PointF(1, 2.5f);
            d[5, 2] = new PointF(1, 3.5f);
            d[5, 3] = new PointF(0.5f, 3);

            gridSize.Width = 30;
            gridSize.Height = 20;

            grid = new List<Node>[gridSize.Width, gridSize.Height];

            for (int x = 0; x < gridSize.Width; x++)
            {
                for (int y = 0; y < gridSize.Height; y++)
                {
                    grid[x, y] = new List<Node>();
                    PointF offset = new PointF(x, y);
                    AddDiamondGridCell(offset, 1, ref grid[x, y]);

                }
            }

            ConnectGrid();
            CalculateBoundingBox();

            // Add start and end nodes
            Node startNode = grid[0, 0][0];
            startNode.LinkList[0] = new NodeLink(startNode, null);
            startNode.LinkList[0].visited = true;

            Node endNode = grid[gridSize.Width - 1, gridSize.Height - 1][5];
            endNode.LinkList[2] = new NodeLink(endNode, null);
            endNode.LinkList[2].visited = true;


            System.Diagnostics.Trace.WriteLine("\n\n");
            System.Diagnostics.Trace.WriteLine("Nodes = " + nodeDict.Count);
            System.Diagnostics.Trace.WriteLine("NodeLinks = " + Network.CountNodeLinks(nodeDict));
            System.Diagnostics.Trace.WriteLine("\n\n");
        }

        public Network INetwork()
        {
            DiamondNetwork network = new DiamondNetwork();
            network.Initialize();
            return network;
        }

        protected void AddDiamondGridCell(PointF offset, float size, ref List<Node> cellNodeList)
        {
            int oldNodeListCount = nodeDict.Count;

            SizeF cellSize = new SizeF(size, size);
            PointF point = new PointF();
            
            //Point i = new Point(0,0);
            point.X = offset.X * 1;
            point.Y = offset.Y * 3;
            
            for(int id = 0; id < 6; id++)            
            {
                ShapeNode node = new ShapeNode();

                for(int ip = 0; ip < 4; ip++)
                {
                    point.X = (offset.X * 2) + (d[id,ip].X * 2);
                    point.Y = (offset.Y * 3) + d[id,ip].Y;

                    node.AddPoint(ip, point);
                }

                nodeDict.Add(node, node.LinkList);
            }
            
            for (int index = oldNodeListCount; index < nodeDict.Count; index++)
            {
                cellNodeList.Add(nodeDict.ElementAt(index).Key);
            }

        }

    }
}