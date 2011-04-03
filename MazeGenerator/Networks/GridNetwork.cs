using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace MazeGenerator
{
    /// <summary>
    /// A grid of unit-sized squares
    /// </summary>
    class SimpleGridNetwork : ShapeNetwork
    {
        public virtual void Initialize(int gridWidth, int gridHeight)
        {
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
                    ShapeNode.ConnectEdges(basicGrid[p.X - 1, p.Y], RectNode.RightIndex, basicGrid[p.X, p.Y], RectNode.LeftIndex);
                }
            }

            for (p.X = 0; p.X < gridWidth; p.X++)
            {
                for (p.Y = 1; p.Y < gridHeight; p.Y++)
                {
                    ShapeNode.ConnectEdges(basicGrid[p.X, p.Y - 1], RectNode.BottomIndex, basicGrid[p.X, p.Y], RectNode.TopIndex);
                }
            }

            CalculateWeightsByArea();

            boundingBox.ptMin.X = 0;
            boundingBox.ptMin.Y = 0;
            boundingBox.ptMax.X = gridWidth;
            boundingBox.ptMax.Y = gridHeight;

            System.Diagnostics.Trace.WriteLine("\n\n");
            System.Diagnostics.Trace.WriteLine("GridMaze : Nodes = " + nodeDict.Count);
            System.Diagnostics.Trace.WriteLine("GridMaze : NodeLinks = " + Network.CountNodeLinks(nodeDict));
            System.Diagnostics.Trace.WriteLine("\n\n");
        }

    }

    /// <summary>
    /// A grid of tesselating shapes
    /// </summary>
    class GridNetwork : ShapeNetwork
    {
        protected List<Node>[,] grid; // Store the nodes in a grid so we can connect them up more efficiently
        protected Size gridSize;

        protected void AddGridCell(PointF offset, int rows, float size, ref List<Node> cellNodeList)
        {
            // As oher AddGridCell method but also returns a list of all the nodes added
            int oldNodeListCount = nodeDict.Count;

            AddGridCell(offset, rows, size);
            for (int index = oldNodeListCount; index < nodeDict.Count; index++)
            {
                cellNodeList.Add(nodeDict.ElementAt(index).Key);
            }            
        }

        protected void AddGridCell(PointF offset, int subdivisions, float size)
        {
            // Adds a grid cell to the _network at position 'offset'
            // 'subdivisions' denotes how many RectNodes the cell is composed of. (1 = 1, 2 = 2x2, 3 = 3x3, etc)
            // Note size is currently the size of each RectNode added to the cell - it would be better if size reflected the entire dimensions of the new grid cell.
            SizeF cellSize = new SizeF(size, size);
            PointF point = new PointF();

            Point i = new Point();
            for (i.X = 0; i.X < subdivisions; i.X++)
            {
                for (i.Y = 0; i.Y < subdivisions; i.Y++)
                {
                    point.X = offset.X + (i.X * size);
                    point.Y = offset.Y + (i.Y * size);                    
                    RectNode node = new RectNode(point, cellSize);
                    nodeDict.Add(node, node.LinkList);                    
                }
            }
        }

        protected void ConnectGrid()
        {
            Point p = new Point();

            for (p.X = 0; p.X < gridSize.Width; p.X++)
            {
                for (p.Y = 0; p.Y < gridSize.Height; p.Y++)
                {
                    if (p.X > 0)
                    {
                        ConnectCells(grid[p.X, p.Y], grid[p.X - 1, p.Y]);
                    }

                    if (p.Y > 0)
                    {
                        ConnectCells(grid[p.X, p.Y], grid[p.X, p.Y - 1]);
                    }
                }
            }
        }

        protected void ConnectCells(List<Node> nodeList1, List<Node> nodeList2)
        {
            List<Node> nodes = new List<Node>();

            foreach (Node n1 in nodeList1)
            {
                nodes.Add(n1);
            }

            foreach (Node n2 in nodeList2)
            {
                nodes.Add(n2);
            }

            ConnectShapes(nodes);
        }
    }
}