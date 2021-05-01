using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AI_CW_40325068
{
    public class FileParser
    {
        private string Filename { get; }

        public FileParser(string filename)
        {
            Filename = filename;
        }

        /// <summary>
        /// Parse a .cav input file
        /// </summary>
        /// <returns></returns>
        public List<Node> Parse()
        {
            // Resulting list
            List<Node> nodeList = new List<Node>();
            
            // Read and split the file
            string text = File.ReadAllText(Filename);
            string[] textSeparation = text.Split(',');

            // Initial values  
            int initialValue = int.Parse(textSeparation[0]);
            int coordinateLength = initialValue * 2;


            // Parse x and y coordinates, and create the nodes with the proper index
            int nodeIndex = 0;
            for (int i = 1; i < coordinateLength + 1; i += 2)
            {
                int xIntValue = int.Parse(textSeparation[i]);
                int yIntValue = int.Parse(textSeparation[i + 1]);

                nodeList.Add(new Node(xIntValue, yIntValue, ++nodeIndex));
            }

            // Parse connections
            for (int i = 0; i < nodeList.Count(); i++)
            {
                Node currentNode = nodeList[i];

                int sectionStart = (coordinateLength + 1) + i * initialValue;
                int endOfSection = sectionStart + initialValue;

                for (int j = sectionStart; j < endOfSection; j++)
                {
                    string connection = textSeparation[j];

                    if (connection.Equals("1"))
                    {
                        Node currentComparision = nodeList[j - sectionStart];

                        currentComparision.AddConnection(currentNode);
                    }
                }
            }

            return nodeList;
        }
    }
}