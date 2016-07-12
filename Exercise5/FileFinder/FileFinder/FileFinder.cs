using System;using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class FileFinder
    {
        public void  SearchForAllFilesContains(string path, string pattren, List<FileInfo> filesContainList)
        {
            
            var recentDirectoryInf = new DirectoryInfo(path);
            var files = recentDirectoryInf.GetFiles();
            foreach (var file in files)
                if (File.ReadAllText(file.FullName).Contains(pattren))
                {
                    filesContainList.Add(file);
                }
            //Scan recursively
            DirectoryInfo[] currentSubDirectories = recentDirectoryInf.GetDirectories();
            if (currentSubDirectories == null || currentSubDirectories.Length < 1)
            {
                return;
            }   
            foreach (DirectoryInfo subDirectoryInf in currentSubDirectories)
                SearchForAllFilesContains(subDirectoryInf.FullName, pattren, filesContainList);
        }
    }
}

