using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonConsoleUI
{
     class ProgramHelper
    {
        public bool ToContinue(string inputMessage)
        {
            if (inputMessage == "esc")
            {
                Console.WriteLine("goodbuy :)");
                return false;
            }
            else
            {
                return true;
            }
        
        }
    }
}
