using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personel
{
    class FileReader
    {
        /// Write a method that reads all data from the file(you can use a StreamReader)
        /// and places it in a List of strings.
        public List<string> ReadsAllData(FileStream stm)
        {
            var fileData = new List<string>();
            string dataLine = "";
            if (stm != null)
            {
                StreamReader reader = new StreamReader(stm);

                dataLine= reader.ReadLine();
                while (dataLine != null)
                {
                    fileData.Add(dataLine);
                    dataLine = reader.ReadLine();

                }
                reader.Close();
            }
            else
            {
                throw new ArgumentNullException("stm", "ReadsAllData needs a valid FileStream to read from at invokation");
            }
            
            return fileData;
        }
 
    }
}