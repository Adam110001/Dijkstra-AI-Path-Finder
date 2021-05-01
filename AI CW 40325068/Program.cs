using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AI_CW_40325068
{
    class Program
    {

        static int Main(string[] args)
        {
            // We need an argument for the file to read
            if (args.Length < 1 )
            {
                return -1;
            }

            // Make sure the input and output filenames are correct
            string inputFile = args[0];
            string outputFile = args[0];
            if (inputFile.ToLower().EndsWith(".cav"))
            {
                outputFile = outputFile.Substring(0, outputFile.Length - 4);
                outputFile += ".csn";
            }
            else
            {
                inputFile += ".cav";
                outputFile += ".csn";
            }
            
            // The input file has to exist
            if (!File.Exists(inputFile))
            {
                return -1;
            }
            
            // Parse the file
            var fileParser = new FileParser(inputFile);
            List<Node> nodeList = fileParser.Parse();

            // Run the dijkstra algorithm
            var dijkstra = new Dijkstra(nodeList);
            List<int> path = dijkstra.FindBestPath();
            
                var fileWriter = new FileWriter(outputFile);

                fileWriter.WritePath(path);

            return 0;
        }
    }
}
