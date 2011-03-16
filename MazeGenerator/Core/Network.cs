using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace MazeGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public class Network
    {
        public List<Node> nodeList; // All nodes in the network

        public Network()
        {
            nodeList = new List<Node>();
        }
    }
}
