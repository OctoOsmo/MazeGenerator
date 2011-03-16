using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeGenerator
{
    interface IRenderableMaze
    {
        void RenderMaze(Network network);
    }
}
