using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Custom_AwaiterConsoleApplication
{
    public static class Program
    {
        static void Main(string[] args)
        {
            intAwaitExample();
            Console.WriteLine("Main Continue 1");

            #region This will work only on a computer- with notpad process

            var proc = Process.Start("notepad");
            Console.WriteLine($"We have created new proc with id {proc.Id} for example");
            procAwaitExample(proc);
            Console.WriteLine("Main Continue 2");
            proc.Kill();
            Console.WriteLine("we have killed the example proc");
            Console.WriteLine("Main Continue 3");

            #endregion


            Console.WriteLine("Press any key to continue ...");
            Console.Read();
        }

        public static async void intAwaitExample()
        {
            Console.WriteLine("before await 7 milisc");
            await 7;
            Console.WriteLine("after await 7 milisc");
        }
        /// <summary>
        /// 1.	
        /// Create an awaiter that will allow awaiting on a integer.
        /// The integer represents the amount of miliseconds to delay.
        /// </summary>
        /// <param name="milisecondsDelayAmount"></param>
        /// <returns></returns>
        public static TaskAwaiter GetAwaiter(this int milisecondsDelayAmount)
        {
            return Task.Delay(milisecondsDelayAmount).GetAwaiter();
        }

        public static async void  procAwaitExample(Process proc)
        {           
            Console.WriteLine("before proc await ");
            await proc;
            Console.WriteLine("after proc await");
        }
        /// <summary>
        /// 2.	
        /// Create a custom awaiter that will allow awaiting on a process
        /// and continue when the process exit
        /// </summary>
        /// <param name="processForAwait"></param>
        /// <returns></returns>
        public static TaskAwaiter GetAwaiter(this Process processForAwait)
        {
            return Task.Run(() => processForAwait.WaitForExit()).GetAwaiter();
        }

    }
}
