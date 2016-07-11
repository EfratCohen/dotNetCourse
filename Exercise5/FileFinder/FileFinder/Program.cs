using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        // Use the first parameter from the command line as a directory path, and search for all files that contain a string passed as the second parameter to the command line. 
        static void Main(string[] args)
        {
            if (args.Length >= 2)
            {
                string path = args[0];
                string patteren = args[1];
                var finder = new FileFinder();
                var fileNamesToPrint = finder.SearchForAllFilesContains(path, patteren);
                foreach (var fileName in fileNamesToPrint)
                {
                    Console.WriteLine(fileName);

                }
            }
            else
            {
                throw new ArgumentException("args", "the program must have tow paremeters from the commend ");
            }

        }
    }
}
