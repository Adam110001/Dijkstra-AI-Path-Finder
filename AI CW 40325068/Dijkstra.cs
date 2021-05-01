using System;
using System.Collections.Generic;

namespace AI_CW_40325068
{
    public class Dijkstra
    {
        private readonly List<Node> _nodes;
        
        public Dijkstra(List<Node> nodeList)
        {
            _nodes = nodeList;
        }

        /// <summary>
        /// This is the entry point for the dijkstra algorithm
        /// </summary>
        /// <returns></returns>
        public List<int> FindBestPath()
        {
            // Get the first and final node
            Node targetNode = _nodes[_nodes.Count - 1];
            Node startNode = _nodes[0];
            startNode.Distance = 0;
            startNode.Path.Add(1);

            // The initial frontier is just the starting node
            List<Node> frontier = new List<Node>()
            {
                startNode,
            };
            
            // Continuously check and update frontier, until we've gone through every node. 
            while (true)
            {
                frontier = CheckFrontier(frontier);

                if (frontier.Count == 0)
                {
                    break;
                }
            }
            
            // After going through every node, the path of the target node will be the correct shortest path.
            return targetNode.Path;
        }

        /// <summary>
        /// Visit all frontier nodes and create a new frontier list 
        /// </summary>
        /// <param name="frontier"></param>
        /// <returns></returns>
        private List<Node> CheckFrontier(List<Node> frontier)
        {
            List<Node> newFrontier = new List<Node>();

            // Visit every frontier node, and get the next frontier nodes
            foreach (Node frontNode in frontier)
            {
                VisitNode(frontNode);
                Utils.MergeLists(newFrontier, frontNode.GetUnvisitedConnections());
            }

            return newFrontier;
        }
        
        /// <summary>
        /// Visit a single node
        /// </summary>
        /// <param name="currentNode"></param>
        private void VisitNode(Node currentNode)
        {
            if (currentNode.Visited)
            {
                // It is possible to add a node to the frontier before visiting it...
                return;
            }
          
            // Loop all connections
            foreach (Node node in currentNode.GetUnvisitedConnections())
            {
                // Calculate the new tentative distance for every neighboring node 
                double tentativeDistance = node.GetDistance(currentNode) + currentNode.Distance;
                if (tentativeDistance < node.Distance)
                {
                    // If the new distance is less, replace it and it's path.
                    node.Distance = tentativeDistance;
                    node.ReplacePath(currentNode.Path);
                }
            }

            // We checked all connections, so this node is visited.
            currentNode.Visited = true;
        }
    }
}