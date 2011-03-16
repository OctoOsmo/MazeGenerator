using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeGenerator
{
    public class Node
    {
        public List<NodeLink> linkList = new List<NodeLink>();

        public bool visited; // Specific to the maze generation algorithm used. Should we abstract this out?
    }
}
