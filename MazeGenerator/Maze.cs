using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace MazeGenerator
{
    /// <summary>
    /// Base class used for maze generation which specific maze generation algorithm classes inherit.
    /// </summary>
    public class Maze
    {
        protected Random _random;
        public Network network;

        public virtual TimeSpan Generate(ref BackgroundWorker baw)
        {
            return TimeSpan.MinValue;
        }
       
        /// <summary>
        /// Draw the maze using the specified line and corridor thickness.
        /// </summary>
        /// <remarks>
        /// If the maze grid is null, this function will call Generate() first.
        /// </remarks>
        /// <param name="lineColor">Color of the walls of the maze.</param>
        /// <param name="lineThickness">Thickness of the walls of the maze.</param>
        /// <param name="corridorWidth">Width of the corridor passages.</param>
        /// <returns>Generated Maze as Image.</returns>
        public Image DrawMaze(Color lineColor, int corridorWidth)
        {
            return MazeDrawer.DrawMaze(/*_grid, null, Width, Height, lineColor, corridorWidth*/);
        }

        //public Image DrawSolution(Color lineColor, int corridorWidth)
        //{
        //    if (_grid == null || !_solved)
        //    {
        //        Solve();
        //    }

        //    return MazeDrawer.DrawMaze(_grid, _solution, Width, Height, lineColor, corridorWidth);
        //}
    }

    public static class MazeDrawer
    {
        public static Image DrawMaze(/*int[,] grid, byte[,] solution, int width, int height, Color lineColor, int corridorWidth*/)
        {
            Image i = new Bitmap(100,100);

            /*
            // TODO: Add parameter to define background color and then add code to throw error if lineColor == backgroundColor
            if (lineColor == Color.White || lineColor == Color.Green)
            {
                throw new ArgumentException("lineColor can not be Color.White as the background is Color.White or Color.Green as the solution is marked as Color.Green");
            }
            //if (lineThickness > corridorWidth) throw new ArgumentException("lineThickness > corridorWidth");

            int normalizedCorridorWidth = corridorWidth + 1;
            Pen p = new Pen(lineColor, 1f);
            //int offset = (int)p.Width / 2;

            Image i = new Bitmap((width * normalizedCorridorWidth) + (int)p.Width, (height * normalizedCorridorWidth) + (int)p.Width);
            using (Graphics g = Graphics.FromImage(i))
            {
                // Paint the background white, otherwise the returned image is a solid black rectangle.
                g.Clear(Color.White);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        //if (solution != null)
                        //{
                        //    // Temp color red deadends
                        //    if (solution[y, x] == 1)
                        //    {
                        //        g.FillRectangle(Brushes.Red, new Rectangle(x * normalizedCorridorWidth, y * normalizedCorridorWidth, normalizedCorridorWidth, normalizedCorridorWidth));
                        //    }
                        //}

                        // If there is no passage going North from the current square, draw a wall.
                        if (((Direction)grid[y, x] & Direction.North) != Direction.North)
                        {
                            g.DrawLine(p,
                                       new Point(x * normalizedCorridorWidth, y * normalizedCorridorWidth),
                                       new Point((x + 1) * normalizedCorridorWidth, y * normalizedCorridorWidth));
                        }

                        // If there is no passage going East from the current square, draw a wall.
                        if (((Direction)grid[y, x] & Direction.East) != Direction.East)
                        {
                            g.DrawLine(p,
                                       new Point((x + 1) * normalizedCorridorWidth, y * normalizedCorridorWidth),
                                       new Point((x + 1) * normalizedCorridorWidth, (y + 1) * normalizedCorridorWidth));
                        }

                        // If there is no passage going South from the current square, draw a wall.
                        if (((Direction)grid[y, x] & Direction.South) != Direction.South)
                        {
                            g.DrawLine(p,
                                       new Point(x * normalizedCorridorWidth, (y + 1) * normalizedCorridorWidth),
                                       new Point((x + 1) * normalizedCorridorWidth, (y + 1) * normalizedCorridorWidth));
                        }

                        // If there is no passage going West from the current square, draw a wall.
                        if (((Direction)grid[y, x] & Direction.West) != Direction.West)
                        {
                            g.DrawLine(p,
                                       new Point(x * normalizedCorridorWidth, y * normalizedCorridorWidth),
                                       new Point(x * normalizedCorridorWidth, (y + 1) * normalizedCorridorWidth));
                        }
                    }
                }
            }
            */
            return i;
        }
    }
}
