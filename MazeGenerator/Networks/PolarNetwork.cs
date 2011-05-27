using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MazeGenerator.Networks
{
    class PolarNode : Node
    {
        private PolarNode()
        {
        }

        public PolarNode(float Radius, float Angle)
        {
            radius = Radius;
            angle = Angle;
        }

        public PointF Point
        {
            get 
            { 
                PointF p = new PointF();
                p.X = (float)Math.Sin(angle) * radius;
                p.Y = (float)Math.Cos(angle) * radius;

                return p;
            }
        }

        public float radius;
        public float angle;
        public float size;
    }

    public class PolarNetwork : Network
    {
        float networkRadius = 1.0f;
        float spokeWeight;
        float ringWeight;
        float ringWidth;
        float weavePercent;

        public float Radius
        {
            get { return networkRadius; }
        }

        public float Diameter
        {
            get { return networkRadius * 2.0f; }
        }

        public void Initialize(int numRings, float startRadius, float inRingWidth, float spokeWidth, float weighting, float inWeavePercent)
        {
            ringWidth = inRingWidth;
            ringWeight = weighting;
            spokeWeight = 1.0f - weighting;
            weavePercent = inWeavePercent;

            networkRadius = (startRadius + ((numRings + 1) * ringWidth));

            // Add centre node
            PolarNode centreNode = new PolarNode(0.0f, 0.0f);
            centreNode.size = startRadius * 2.0f;
            nodeDict.Add(centreNode, centreNode.LinkList);

            List<Node> ringList = new List<Node>();
            List<Node> oldRingList = null; 

            CreateRing(startRadius + ringWidth, spokeWidth, ringList, null);

            // Special case on first ring
            if (ringList.Count > 0)
            {
                NodeLink link = new NodeLink(centreNode, ringList[0]);
                link.weight = spokeWeight;
                centreNode.LinkList.Add(link);
                ringList[0].LinkList.Add(link);
            }
            oldRingList = ringList;


            // Create all other rings
            for (int i = 1; i < numRings; i++)
            {
                ringList = new List<Node>();
                CreateRing(startRadius + (ringWidth * (float)(i + 1)), spokeWidth, ringList, oldRingList);
                oldRingList = ringList;
            }

            /*
            if (weavePercent > 0.0f)
            {
                Random random = new Random();

                List<PolarNode> weaveNodes = new List<PolarNode>();

                // Identify all weave nodes
                foreach (Node node in nodeDict.Keys)
                {
                    PolarNode pn = (PolarNode)node;
                    if (pn.LinkList.Count == 4)
                    {
                        //TODO: And all links dont connect to null
                        weaveNodes.Add(pn);
                    }
                }

                int numWeaves = (int)(((float)weaveNodes.Count) * weavePercent * 0.01f);

                while ((numWeaves > 0) && (weaveNodes.Count > 0))
                {
                    numWeaves--;
                    float angleThreshold = (float)Math.PI * 0.5f;

                    //Remove a random node from the weave list
                    int index = random.Next(0, weaveNodes.Count);
                    PolarNode pn = weaveNodes[index];
                    weaveNodes.RemoveAt(index);

                    // First 2 links are orbital links
                    // Skip doing this weave if the angle is > threshold
                    float angle1 = ((PolarNode)pn.LinkList[0].Other(pn)).angle;
                    float angle2 = ((PolarNode)pn.LinkList[1].Other(pn)).angle;

                    if (Math.Abs(angle2 - angle1) > angleThreshold)
                    {
                        continue;
                    }

                    // Collapse orbital links
                    PolarNode orbitA = (PolarNode)pn.LinkList[0].Other(pn);
                    PolarNode orbitB = (PolarNode)pn.LinkList[1].Other(pn);
                    pn.LinkList[0].Replace(pn, orbitB);

                    // Find the link on orbitB that links to pn
                    if (orbitB.LinkList[0].Other(orbitB) == pn)
                    {
                        orbitB.LinkList[0] = pn.LinkList[0];
                    }
                    else
                    {
                        orbitB.LinkList[1] = pn.LinkList[0];
                    }

                    // Second 2 links are spoke links
                    PolarNode spokeA = (PolarNode)pn.LinkList[2].Other(pn);
                    PolarNode spokeB = (PolarNode)pn.LinkList[3].Other(pn);
                    pn.LinkList[2].Replace(pn, spokeB);

                    if (spokeB.LinkList[2].Other(spokeB) == pn)
                    {
                        spokeB.LinkList[2] = pn.LinkList[2];
                    }
                    else
                    {
                        spokeB.LinkList[3] = pn.LinkList[2];
                    }

                    pn.LinkList.Clear();
                    // Remove pn from network
                    nodeDict.Remove(pn);

                    
                }
            }*/

            /*
            // Bias the link weights based on horizontal & vertical orientation
            foreach (List<NodeLink> linkList in nodeDict.Values)
            {
                foreach (NodeLink l1 in linkList)
                {
                    if (l1.a != null && l1.b != null)
                    {
                        PolarNode pn1 = (PolarNode)l1.a;
                        PolarNode pn2 = (PolarNode)l1.b;

                        Vector2D vec = new Vector2D(pn1.Point, pn2.Point);
                        vec = vec.Normalized();

                        l1.weight = (ringWeight * Math.Abs(vec.b.X - vec.a.X)) + (spokeWeight * (Math.Abs(vec.b.Y - vec.a.Y)));
                        l1.weight = l1.weight * l1.weight * l1.weight;                        
                    }
                }
            }*/
             
        }

        void CreateRing(float radius, float corridorWidth, List<Node> ring, List<Node> innerRing)
        {
            float circ = radius * 2.0f * (float)Math.PI;

            uint divs = 0;

            if (circ > corridorWidth)
            {
                // Calculate how many fixed position nodes we can put on this ring
                divs = 1;
                while ((circ / ((float)(divs * 2))) > corridorWidth)
                {
                    divs *= 2;
                }

                System.Diagnostics.Trace.WriteLine("\n" + circ + " = " + divs);        

                // Add nodes to ring
                for (uint i = 0; i < divs; i++)
                {
                    float angle = (((float) i) * (float)Math.PI * 2.0f )/ (float)divs;
                    PolarNode pn = new PolarNode(radius, angle);
                    pn.size = 0.0f; // ringWidth;
                    ring.Add(pn);
                    nodeDict.Add(pn, pn.LinkList);
                }

                // Connect nodes together on ring
                for(int index = 0; index < ring.Count; index++)
                {
                    int index2 = (index + 1) % ring.Count;
                    NodeLink link = new NodeLink(ring[index], ring[index2]);
                    link.weight = ringWeight;
                    ring[index].LinkList.Add(link);
                    ring[index2].LinkList.Add(link);                        
                }

                // Connect nodes to inner ring
                // Note: The number of nodes between the 2 rings may be different.
                if (innerRing != null)
                {
                    int step = 1;
                    while (divs > innerRing.Count)
                    {
                        step++;
                        divs /= 2;
                    }

                    int outerIndex = 0;
                    for (int innerIndex = 0; innerIndex < innerRing.Count; innerIndex++, outerIndex += step)
                    {
                        NodeLink link = new NodeLink(ring[outerIndex], innerRing[innerIndex]);
                        link.weight = spokeWeight;
                        ring[outerIndex].LinkList.Add(link);
                        innerRing[innerIndex].LinkList.Add(link);                        
                    }
                }
            }                        
        }
    }
}
