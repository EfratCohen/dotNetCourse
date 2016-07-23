using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_1
{
    /// <summary>
    /// Create queries and display results for the following:
    ///  a. Display all the public interface names in the mscorlib assembly and the number of methods in each type. 
    ///  Sort by type name. 
    ///  b. Display all processes running on your system (process name, id and start time), whose thread count is less than 5. 
    ///  Sort by process id. 
    ///  c. (*) Extend (b) by grouping the processes by their base priority. 
    ///  d. Display the total number of threads in the system. 
    /// </summary>
    class LinQDisplayer
    {
        /// <summary>
        ///  return all the public interface names in the mscorlib assembly and the number of methods in each type. 
        ///  Sort by type name. for their Display in the main.
        /// </summary>
        public IEnumerable<Type> PublicInterface()
        {

            var mscrlibAssembly = typeof(string).Assembly;
            return (mscrlibAssembly.GetTypes().Where(x => (x.IsInterface && x.IsPublic)).OrderBy(o => o.Name));
        }
        //<summary>
        // return all processes running on your system (process name, id and start time), whose thread count is less than 5. 
        // Sort by process id. for their Display in the main.
        //</summary>
        public IEnumerable<Process> RunningProcess()
        {
            return Process.GetProcesses().Where(p => (p.Threads.Count < 5)).OrderBy(p => p.Id);
        }
        public IEnumerable<IGrouping<int, Process>> RunningProcessExtend(IEnumerable<Process> procces)
        {
            return procces.GroupBy(p => p.BasePriority);
        }
        //d.
        public int TotalSystemThreadsNumber()
        {
            return Process.GetProcesses().Select(p => (p.Threads.Count)).Sum();
        }
    }
}
