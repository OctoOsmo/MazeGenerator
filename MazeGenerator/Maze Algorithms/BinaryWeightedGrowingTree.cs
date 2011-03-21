using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;

namespace MazeGenerator
{
    class BinaryWeightedGrowingTree : MazeAlgorithm
    {
        protected Random _random = new Random();
        protected List<NodeLink> weightedLinks = new List<NodeLink>();
        protected List<NodeLink> unweightedLinks = new List<NodeLink>();

        public BinaryWeightedGrowingTree()
        {            
        }

        protected void VisitNode(Node n)
        {
            if (n.visited)
            {
                return;
            }

            foreach (NodeLink link in n.LinkList)
            {
                if (link != null && !link.visited)
                {
                    if (!link.Other(n).visited)
                    {
                        if (link.weight == 0)
                        {
                            unweightedLinks.Add(link);
                        }
                        else
                        {
                            weightedLinks.Add(link);
                        }
                    }
                }
            }

            n.visited = true;
        }

        public TimeSpan Generate(Network network/*, ref BackgroundWorker baw*/)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            try
            {
                Node n = network.nodeList.First();
                VisitNode(n);

                while (weightedLinks.Count > 0 || unweightedLinks.Count > 0)
                {
                    int linkIndex;
                    NodeLink link;

                    // Get a weighted link
                    if (weightedLinks.Count > 0) // always pick a weighted link over an unweighted one
                    {
                        linkIndex = _random.Next(weightedLinks.Count);
                        link = weightedLinks[linkIndex];
                        weightedLinks.RemoveAt(linkIndex);

                        if (link.a.visited && link.b.visited)
                        {
                            // do not use link                            
                            continue;
                        }
                    }
                    else if (unweightedLinks.Count > 0)
                    {
                        linkIndex = _random.Next(unweightedLinks.Count);
                        link = unweightedLinks[linkIndex];
                        unweightedLinks.RemoveAt(linkIndex);

                        if (link.a.visited && link.b.visited)
                        {
                            // do not use link                            
                            continue;
                        }
                    }
                    else
                    {
                        break;
                    }

                    link.visited = true;

                    if (link.a.visited == false)
                    {
                        VisitNode(link.a);
                        link.a.visited = true;
                    }
                    else if (link.b.visited == false)
                    {
                        VisitNode(link.b);
                        link.b.visited = true;
                    }
                }
            }
            catch
            {
            }

            time.Stop();

            return time.Elapsed;
        }
    }    
}