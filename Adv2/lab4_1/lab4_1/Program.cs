namespace lab4_1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
            foreach (var publicInterface in myPublicInterfaceItrerator)
            {
                Console.WriteLine(publicInterface);
            }
            //b.
            var myChecker = new Checker();
            var myRunningProcessItrerator = myLinQuser.RunningProcess();
            foreach (var process in myRunningProcessItrerator)
            {
                Console.WriteLine($"name:{process.ProcessName} id: {process.Id} start time: {myChecker.StartTimeReturnIfCan(process)}");
            }
            //c.
            var myExtendRunningProcessItrerator = myLinQuser.RunningProcessExtend(myRunningProcessItrerator);
            foreach (var proccesGroup in myExtendRunningProcessItrerator)
            {
                foreach (var process in proccesGroup)
                {
                    Console.WriteLine($"name:{process.ProcessName} id: {process.Id} start time: {myChecker.StartTimeReturnIfCan(process)}");
                }
                //d.
                Console.WriteLine("the total number of threads in the system is {0,5}", myLinQuser.TotalSystemThreadsNumber());
            }
            //2.
            var myOtherChecker = new Checker("XX", 7, "YYY");
            Console.WriteLine($" myChecker {myChecker} \n myOtherChecker {myOtherChecker}");
            myOtherChecker.CopyTo(myChecker);
            Console.WriteLine($"After copy: \n myChecker {myChecker} \n myOtherChecker {myOtherChecker}");    
        }
    }
}
