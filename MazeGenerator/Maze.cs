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
       
        public Image DrawMaze(Color lineColor, int corridorWidth)
        {
            return MazeDrawer.DrawMaze();
        }
    }

    public static class MazeDrawer
    {
        public static Image DrawMaze()
        {
            Image i = new Bitmap(100,100);

            return i;
        }
    }
}
