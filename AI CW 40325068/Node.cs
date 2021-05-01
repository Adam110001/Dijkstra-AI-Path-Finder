using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CW_40325068
{
    public class Node
    {
        public int X { get; }
        public int Y { get; }
        
        public int Index { get; }

        public bool Visited { get; set; } = false;

        public double Distance { get; set; } = double.MaxValue;

        private List<Node> Connections { get; set; } = new List<Node>(); 
        
        public List<int> Path { get; set; } = new List<int>() ;

        public Node(int x, int y, int index)
        {
            Index = index;
            X = x;
            Y = y;
        }
        
        /// <summary>
        /// Add a connection to this node
        /// </summary>
        /// <param name="connection"></param>
        public void AddConnection(Node connection)
        {
            Connections.Add(connection);
        }
        
        /// <summary>
        /// Get every connection that isn't visited yet
        /// </summary>
        /// <returns></returns>
        public List<Node> GetUnvisitedConnections()
        {
            return Connections.FindAll(node => !node.Visited);
        }

        /// <summary>
        /// Get the distance to another node
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double GetDistance(Node other)
        {
            // This coordinates
            double x1 = X;
            double y1 = Y;

            // Other coordinates
            double x2 = other.X;
            double y2 = other.Y;

            // Calculate and return the distance
            return Math.Sqrt(Math.Pow(x2 - x1, 2.0) + Math.Pow(y2 - y1, 2.0));
        }

        /// <summary>
        /// Replace the path to this node
        /// </summary>
        /// <param name="path"></param>
        public void ReplacePath(List<int> path)
        {
            Path = new List<int>(path) { Index };
        }
        
        public override string ToString()
        {
            return $"i: {Index} v: {Visited}";
        }
    }
}
