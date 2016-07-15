using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Program
    {
        /// <summary>
        /// Call the methods from the Main method, passing current assembly 
        ///  pass a reference to some other Assembly to the AnalyzeAssembly method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var otherAssembly = typeof(string).Assembly;
            var myAssembly = Assembly.GetExecutingAssembly();
            var myAssemblyAnalayzer = new AssemblyAnalayzer();
            Assembly[] asembliesForAnalaize = { myAssembly, otherAssembly };
            foreach (var asm in asembliesForAnalaize)
            {
                if (myAssemblyAnalayzer.AnalayzeAssembly(asm))
                {
                    Console.WriteLine("all the attributed types in the assembly we get was approved");
                }
                else
                {
                    Console.WriteLine(" not all the attributed types in the assembly we get was approved");
                }
            }
            
             
        }
    }
}
