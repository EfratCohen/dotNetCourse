using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;


namespace Jobs
{

    class Program
    {
         const int _10M = 10485760*10; 

        static void Main(string[] args)
        {
            /// 6.
            /// In the Main method, create a Job object,
            /// and assign some processes to it 
            /// (Use Process.Start to create some simple processes, such as “notepad” or “calc”).
            /// 
            Job job = new Job();
            Process someProcesses = Process.Start("notepad");
            try
            {
                job.AddProcessToJob(someProcesses.Id);
            }
            catch (InvalidOperationException ex)
            {

                Console.WriteLine(ex.Message);
            }

            /// 7.	
            /// Call Console.ReadLine 
            /// and after the user hits<enter> kill all processes in the job using the Kill instance method.
            Console.WriteLine();
            job.Kill();

            /// B.d.  Create a loop in your main method that creates 20 Job objects
            ///e.See what happens when you run the application with different “sizeInBytes”.
            ///Try 0 MB and 10 MB

            for (int i = 0; i < 20; i++)
            {
                var j = new Job();
            }
            for (int i = 0; i < 20; i++)
            {
                var j = new Job(null, _10M);
            }

            Console.Read();
        }
    }
}
