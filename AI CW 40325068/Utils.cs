using System.Collections.Generic;
using System.Linq;

namespace AI_CW_40325068
{
    public static class Utils
    {
        /// <summary>
        /// Merge a list of nodes into another, without merging duplicates
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static List<Node> MergeLists(List<Node> to, List<Node> from)
        {
            // Loop every node to add
            from.ForEach(target =>
            {
                // Only add the node if it isn't already present
                if (to.All(node => node.Index != target.Index))
                {
                   to.Add(target); 
                }
            });
            return to;
        }
    }
}