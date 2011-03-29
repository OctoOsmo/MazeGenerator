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
        //public List<Node> nodeDict = new List<Node>(); // All nodes in the _network
        public Dictionary<Node, List<NodeLink>> nodeDict = new Dictionary<Node, List<NodeLink>>();

        public static int CountNodeLinks(Dictionary<Node, List<NodeLink>> nodeDictionary)
        {
            return (int)nodeDictionary.Sum(n => { return (decimal)n.Value.Count; });
        }

        public Network()
        {
        }
    }
}
