using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;

namespace MazeGenerator
{
    interface RenderMaze
    {
        void RenderMaze(Network network);
    }
}