using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeGenerator
{
    public class NodeLink
    {
        public Node a, b;
        public bool visited;    // Specific to the maze generation algorithm used. Should we abstract this out?
        public float weight;     // Specific to the maze generation algorithm used. Should we abstract this out?

        private NodeLink() { }

        public NodeLink(Node A, Node B)
        {
            a = A;
            b = B;
            visited = false;
            weight = 1;
        }

        ~NodeLink()
        {

        }

        public Node Other(Node n)
        {
            if (n == a)
                return b;
            else
                return a;
        }
    }
}
