using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personel
{
    class Program
    {
        static void Main(string[] args)
        {
           
            using (FileStream stm = new FileStream("names.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Console.WriteLine("Printing the whole names.txt file we prepered for ReadsAllData use:");
                var reader = new FileReader();
                var stringsToPrint = reader.ReadsAllData(stm);
                foreach (var str in stringsToPrint)
                {
                    Console.WriteLine(str);

                }
            }
        }
    }
}
