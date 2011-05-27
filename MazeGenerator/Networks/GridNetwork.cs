using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MazeGenerator.Networks
{
    /*public class GridNetworkModule : INetwork
    {
        uiGridNetwork UI;

        public GridNetworkModule()
        {
            UI = new uiGridNetwork();
            mForm = UI;
        }

        public Network INetwork()
        {
            GridNetwork network = new GridNetwork();
            network.Initialize((int)UI.gridWidth.Value, (int)UI.gridHeight.Value, (int)UI.weavePercent.Value);
            return network;
        }
    }*/

    /// <summary>
    /// A grid of unit-sized squares
    /// </summary>
    class GridNetwork : ShapeNetwork
    {
        protected Random _random = new Random();
        float horizontalWeighting;
        float verticalWeighting;

        public virtual void Initialize(int gridWidth, int gridHeight, int weavePercent, float weighting)
        {
            horizontalWeighting = weighting;
            verticalWeighting = 1.0f - weighting;

            // Create grid
            RectNode[,] basicGrid = new RectNode[gridWidth, gridHeight];

            // Create square nodes
            SizeF cellSize = new SizeF(1, 1);
            Point p = new Point();
            for (p.X = 0; p.X < gridWidth; p.X++)
            {
                for (p.Y = 0; p.Y < gridHeight; p.Y++)
                {
                    RectNode node = new RectNode(p, cellSize);
                    nodeDict.Add(node, node.LinkList);
                    basicGrid[p.X, p.Y] = node;
                }
            }

            // Connect nodes
            for (p.X = 1; p.X < gridWidth; p.X++)
            {
                for (p.Y = 0; p.Y < gridHeight; p.Y++)
                {
                    ShapeNode.ConnectEdges(basicGrid[p.X - 1, p.Y], RectNode.RightIndex, basicGrid[p.X, p.Y], RectNode.LeftIndex, horizontalWeighting);
                }
            }

            for (p.X = 0; p.X < gridWidth; p.X++)
            {
                for (p.Y = 1; p.Y < gridHeight; p.Y++)
                {
                    ShapeNode.ConnectEdges(basicGrid[p.X, p.Y - 1], RectNode.BottomIndex, basicGrid[p.X, p.Y], RectNode.TopIndex, verticalWeighting);
                }
            }

            boundingBox.ptMin.X = 0;
            boundingBox.ptMin.Y = 0;
            boundingBox.ptMax.X = gridWidth;
            boundingBox.ptMax.Y = gridHeight;

            // Add Weaves
            int numWeaveNodes = (gridWidth - 2) * (gridHeight - 2);
            if (numWeaveNodes > 0)
            {
                for (p.X = 1; p.X < (gridWidth - 1); p.X++)
                {
                    for (p.Y = 1; p.Y < (gridHeight - 1); p.Y++)
                    {
                        int chance = _random.Next(0, 100);
                        if (chance < weavePercent)
                        {
                            NodeLink link;

                            Node gridNode = basicGrid[p.X, p.Y];
                            Node upperNode = gridNode.LinkList[0].Other(gridNode);
                            Node leftNode = gridNode.LinkList[1].Other(gridNode);
                            Node lowerNode = gridNode.LinkList[2].Other(gridNode);
                            Node rightNode = gridNode.LinkList[3].Other(gridNode);

                            RectNode weaveNode = new RectNode(p, cellSize);
                            nodeDict.Add(weaveNode, weaveNode.LinkList);

                            weaveNode.LinkList[0] = gridNode.LinkList[0];
                            gridNode.LinkList[0] = null;

                            weaveNode.LinkList[2] = gridNode.LinkList[2];
                            gridNode.LinkList[2] = null;

                            link = weaveNode.LinkList[0];
                            if (link.a == gridNode)
                            {
                                link.a = weaveNode;
                            }
                            else
                            {
                                link.b = weaveNode;
                            }

                            link = weaveNode.LinkList[2];
                            if (link.a == gridNode)
                            {
                                link.a = weaveNode;
                            }
                            else
                            {
                                link.b = weaveNode;
                            }

                            link = new NodeLink(upperNode, lowerNode);
                            upperNode.LinkList[2] = link;
                            lowerNode.LinkList[0] = link;
                            link.visited = true;

                            link = new NodeLink(leftNode, rightNode);
                            leftNode.LinkList[3] = link;
                            rightNode.LinkList[1] = link;
                            link.visited = true;

                            gridNode.LinkList[1].visited = true;
                            gridNode.LinkList[3].visited = true;
                            weaveNode.LinkList[0].visited = true;
                            weaveNode.LinkList[2].visited = true;
                        }
                    }
                }
            }

            // Add start and end nodes
            Node startNode = basicGrid[0,0];
            startNode.LinkList[3] = new NodeLink(startNode, null);
            startNode.LinkList[3].visited = true;

            Node endNode = basicGrid[gridWidth - 1, gridHeight - 1];
            endNode.LinkList[1] = new NodeLink(endNode, null);
            endNode.LinkList[1].visited = true;

            // Display some metrics
            System.Diagnostics.Trace.WriteLine("\n\n");
            System.Diagnostics.Trace.WriteLine("GridMaze : Nodes = " + nodeDict.Count);
            System.Diagnostics.Trace.WriteLine("GridMaze : NodeLinks = " + Network.CountNodeLinks(nodeDict));
            System.Diagnostics.Trace.WriteLine("\n\n");
        }

    }

}
