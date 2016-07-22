using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_1
{
    class Checker
    {
        public DateTime StartTimeReturnIfCan(Process p)
        {
            try
            {
                return p.StartTime;
            }
            catch (Exception ex)
            {
                Console.WriteLine("we get {0,5} exeption while the process StartTime get ", ex.GetType());
                return new DateTime();
            }
        }
    }
}
