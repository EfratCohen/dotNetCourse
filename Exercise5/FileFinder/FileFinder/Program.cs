using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        // Use the first parameter from the command  as a directory path, and search for all files that contain a string passed as the second parameter to the command line. 
        static void Main(string[] args)
        {
            if (args.Length >= 2)
            {
                string path = args[0];
                string patteren = args[1];
                var filesToDisplay = new List<FileInfo>();
                var finder = new FileFinder();
                finder.SearchForAllFilesContains(path, patteren, filesToDisplay);
                Console.WriteLine($"we have found {filesToDisplay.Count} files which contains the string {patteren}");
                foreach (var file in filesToDisplay)
                {
                    Console.WriteLine($"{file.Name} with size (in bytes): {file.Length}");
                }
            }
            else
            {
                throw new ArgumentException("args", "the program must have two paremeters from the commend line");
            }

        }
    }
}
