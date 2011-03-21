using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeGenerator
{
    public class NodeLink
    {
        static private int count = 0;   // An internal counter of how many instances of NodeLink exist.

        static public int Count
        {
            get
            {
                return count;
            }
        }

        public Node a, b;
        public bool visited;    // Specific to the maze generation algorithm used. Should we abstract this out?
        public float weight;     // Specific to the maze generation algorithm used. Should we abstract this out?

        private NodeLink() { }

        public NodeLink(Node A, Node B)
        {
            count++;

            a = A;
            b = B;
            visited = false;
            weight = 1;
        }

        ~NodeLink()
        {
            count--;
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
