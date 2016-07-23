using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_1
{
    class Program
    {
        /// <summary>
        /// 1.
        ///  Create queries and display results for the following:
        ///  a. Display all the public interface names in the mscorlib assembly and the number of methods in each type. 
        ///  Sort by type name. 
        ///  b. Display all processes running on your system (process name, id and start time), whose thread count is less than 5. 
        ///  Sort by process id. 
        ///  c. (*) Extend (b) by grouping the processes by their base priority. 
        ///  d. Display the total number of threads in the system. 
        ///  2.
        ///  (*) Create an extension method that extends object with a method called CopyTo that copies all public properties from this object to another object passed as argument. Make sure only writable properties are written and readable properties are read. Use LINQ. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var myLinQuser = new LinQDisplayer();
            //a.
            var myPublicInterfaceItrerator = myLinQuser.PublicInterface();
            foreach (var item in myPublicInterfaceItrerator)
            {
                Console.WriteLine(item);
            } 
            //b.
            var myChecker = new Checker();
            var myRunningProcessItrerator = myLinQuser.RunningProcess();
            foreach (var item in myRunningProcessItrerator)
            {
                //item.StartTime
                Console.WriteLine("name:{0,5} id: {1,5} start time: {2,5} ", item.ProcessName, item.Id, myChecker.StartTimeReturnIfCan(item));
            }
            //c.
            var myExtendRunningProcessItrerator = myLinQuser.RunningProcessExtend(myRunningProcessItrerator);
            foreach (var item in myExtendRunningProcessItrerator)
            {
                Console.WriteLine(item);
            }
            //d.
            Console.WriteLine("the total number of threads in the system is {0,5}",myLinQuser.TotalSystemThreadsNumber());
        }
    }
}
