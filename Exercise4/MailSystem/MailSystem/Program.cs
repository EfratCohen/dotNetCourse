using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class Program
    {
        /// <summary>
        /// create an instance of MailManager and connect to the MailArrived event
        /// in the handler, output the title and body to the console.
        /// Call the SimulateMailArrived to check the event connection. 
        /// Create a System.Threading.Timer, and in the timer callback call SimulateMailArrived every 1 second (=1000 milisc). 
        /// Call Thread.Sleep in the main thread to keep the application alive, or call Console.ReadLine.  
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var mailManger = new MailManager();
            mailManger.MailArrived += new EventHandler<MailArrivedEventArgs>((object sendr, MailArrivedEventArgs mailArgs)=>
        {
            Console.WriteLine($"New mail arrived!\n Title: {mailArgs.Title}\n body:\n{mailArgs.Body}");
        });
            mailManger.SimulateMailArrived();
            var timer = new System.Threading.Timer( state=> 
            {
                Console.WriteLine();
                mailManger.SimulateMailArrived();
            },null,0, 1000);
            Console.ReadLine();
            timer.GetType(); //use the timer after the readline command so the Gc won't distroy it
            Console.WriteLine(" we got the expected results :)");
        }

    }
 
}
