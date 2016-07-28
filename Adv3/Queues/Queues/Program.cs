using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            var canecellation = new CancellationTokenSource();
            var cToken = canecellation.Token;
            string addMsg="", rmvMsg="";
            var mychecker = new LimitedQueueChecker();
            var myLimitedQ = new LimitedQueue<int>(5);
   
                Task.Run(() => mychecker.AddRandomly(myLimitedQ, canecellation, ref addMsg));
                Task.Run(() => mychecker.RemoveRandoly(myLimitedQ, canecellation, ref rmvMsg));
            Console.WriteLine("\n We start runnig the Check App. press any key to see What happend\n # press esc to exit");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                Console.WriteLine(addMsg);
                Console.WriteLine(rmvMsg);
                Console.WriteLine($"the {myLimitedQ} count is {myLimitedQ.Count}");
            }
            canecellation.Cancel();
            Console.WriteLine(" goodbuy :)");
        }
    }
}
