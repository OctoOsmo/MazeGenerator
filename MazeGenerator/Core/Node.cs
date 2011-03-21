using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeGenerator
{
    public class Node
    {
        private List<NodeLink> linkList = new List<NodeLink>();

        public List<NodeLink> LinkList
        {
            get { return linkList; }
            set { linkList = value; }
        }

        public bool visited; // Specific to the maze generation algorithm used. Should we abstract this out?
    }
}
