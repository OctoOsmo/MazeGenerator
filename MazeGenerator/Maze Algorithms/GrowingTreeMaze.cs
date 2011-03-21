using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;

namespace MazeGenerator
{
    class GrowingTree : MazeAlgorithm
    {
        protected Random _random = new Random();
        protected List<Node> nodeReferences = new List<Node>();

        public GrowingTree() 
        {            
        }

        public TimeSpan Generate(Network network/*, ref BackgroundWorker baw*/)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            try
            {
                nodeReferences.Add(network.nodeList.First());

                while (nodeReferences.Count != 0)
                {
                    //List<Direction> directions = UtilityFunctions.RandomSortList<Direction>(_directions, ref _random);

                    Node nodeRef = nodeReferences[nodeReferences.Count - 1];
                    nodeRef.visited = true;

                    bool unvisitedNeighbourFound = false;

                    List<NodeLink> srcList = new List<NodeLink>(nodeRef.LinkList);
                    List<NodeLink> randList = new List<NodeLink>(nodeRef.LinkList.Count);
                    while (srcList.Count > 0)
                    {
                        int index = _random.Next(0, srcList.Count);
                        randList.Add(srcList[index]);
                        srcList.RemoveAt(index);
                    }

                    foreach (NodeLink l in randList)
                    {
                        if(l != null && l.Other(nodeRef).visited == false)
                        {
                            l.visited = true;

                            /*num++;
                            // TODO: Move reporting of progress into if loop so that progress is reported only when the number of completed cells changes.
                            decimal pp = (num / (Width * Height)) * 100;
                            int percentProgress = (int)Math.Round(pp, 0, MidpointRounding.AwayFromZero);
                            baw.ReportProgress(percentProgress);
                            */

                            nodeReferences.Add(l.Other(nodeRef));

                            unvisitedNeighbourFound = true;

                            break;
                        }
                    }

                    if (!unvisitedNeighbourFound)
                    {
                        nodeReferences.RemoveAt(nodeReferences.Count - 1);
                    }
                }
            }
            catch
            {
            }

            time.Stop();

            return time.Elapsed;
        }
    }

    /*
    class GrowingTreeMaze : Maze
    {
        private List<CellReference> _cellReferences = new List<CellReference>();

        /// <summary>
        /// Initializes a Growing Tree Maze with the specified width and height. The starting point x and y-coordinates are set to 0.
        /// </summary>
        /// <param name="width">Width (number of columns) of the maze.</param>
        /// <param name="height">Height (number of rows) of the maze.</param>
        public GrowingTreeMaze(int width, int height) : base(width, height) { }

        /// <summary>
        /// Initializes a Growing Tree Maze with the specified starting point x and y-coordinates, width and height.
        /// </summary>
        /// <param name="cx">X-coordinate for the starting point of the algorithm.</param>
        /// <param name="cy">Y-coordinate for the starting point of the algorithm.</param>
        /// <param name="width">Width (number of columns) of the maze.</param>
        /// <param name="height">Height (number of rows) of the maze.</param>
        public GrowingTreeMaze(int cx, int cy, int width, int height) : base(cx, cy, width, height) { }

        /// <summary>
        /// Generates the maze.
        /// </summary>
        /// <returns>TimeSpan taken to generate the maze including grid initialization.</returns>
        public TimeSpan Generate(ref BackgroundWorker baw)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            _random = new Random();

       
            
            _grid = new int[Height, Width];
            InitializeGrid();

            _cellReferences.Add(new CellReference(CX, CY));

            decimal num = 0;

            while (_cellReferences.Count != 0)
            {
                List<Direction> directions = UtilityFunctions.RandomSortList<Direction>(_directions, ref _random);

                CellReference cellRef = _cellReferences[_cellReferences.Count - 1];

                bool unvisitedNeighbourFound = false;

                foreach (Direction dir in directions)
                {
                    int nx = cellRef.X + UtilityFunctions.GetTranslationInX(dir);
                    int ny = cellRef.Y + UtilityFunctions.GetTranslationInY(dir);

                    if (nx >= 0 && nx < Width && ny >= 0 && ny < Height && _grid[ny, nx] == 0)
                    {
                        _grid[cellRef.Y, cellRef.X] |= (byte)dir;
                        _grid[ny, nx] |= (byte)UtilityFunctions.GetOppositeDirection(dir);

                        num++;
                        // TODO: Move reporting of progress into if loop so that progress is reported only when the number of completed cells changes.
                        decimal pp = (num / (Width * Height)) * 100;
                        int percentProgress = (int)Math.Round(pp, 0, MidpointRounding.AwayFromZero);
                        //baw.ReportProgress(percentProgress);


                        _cellReferences.Add(new CellReference(nx, ny));

                        unvisitedNeighbourFound = true;

                        break;
                    }
                }

                if (!unvisitedNeighbourFound) _cellReferences.RemoveAt(_cellReferences.Count - 1);
            }
            
            time.Stop();

            _valueChanged = false;

            return time.Elapsed;
        }

        //public new TimeSpan Solve(int startX, int startY, int finishX, int finishY)
        //{
        //    Stopwatch time = new Stopwatch();
        //    time.Start();

        //    _solution = new byte[Height, Width];
        //    InitializeSolution();

        //    for (int y = 0; y < Height; y++)
        //    {
        //        for (int x = 0; x < Width; x++)
        //        {
        //            if (_grid[y, x] == 2 || _grid[y, x] == 4 || _grid[y, x] == 8 || _grid[y, x] == 16)
        //            {
        //                _solution[y, x]++;
        //            }
        //        }
        //    }

        //    time.Stop();
        //    return time.Elapsed;
        //}

        public struct CellReference
        {
            private int _x;
            private int _y;

            public int X
            {
                get { return _x; }
            }

            public int Y
            {
                get { return _y; }
            }

            public CellReference(int x, int y)
            {
                _x = x;
                _y = y;
            }
        }
    }
      */
}
