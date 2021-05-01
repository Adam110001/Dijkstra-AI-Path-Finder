using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AI_CW_40325068
{
    public class FileWriter
    {
        private readonly string _filename;
        
        public FileWriter(string filename)
        {
            _filename = filename;
        }

        /// <summary>
        /// Write a .csn output path to a file
        /// </summary>
        /// <param name="path"></param>
        public void WritePath(List<int> path)
        {
            string output = "0";

            if (path.Count > 0)
            {
                output = string.Join(" ", path.ToArray());
            }

            File.WriteAllText(_filename, output);
        }
    }
}