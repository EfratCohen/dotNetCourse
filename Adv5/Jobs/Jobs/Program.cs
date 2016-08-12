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

        static void Main(string[] args)
        {
            /// 6.
            /// In the Main method, create a Job object,
            /// and assign some processes to it 
            /// (Use Process.Start to create some simple processes, such as “notepad” or “calc”).
            /// 
            Job job = new Job();
            Process someProcesses = Process.Start("notepad");
            job.AddProcessToJob(someProcesses.Id);

            /// 7.	
            /// Call Console.ReadLine 
            /// and after the user hits<enter> kill all processes in the job using the Kill instance method.
            Console.WriteLine();
            job.Kill();

        }
    }
}
