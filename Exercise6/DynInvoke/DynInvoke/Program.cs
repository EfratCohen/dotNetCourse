using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class Program
    {
        /// <summary>
        /// create an instance for A, B and C 
        /// call InvokeHello with each object and some string. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)

        {
            try
            {
                var classAinstance = new A();
                Console.WriteLine(InvokeHello(classAinstance, "Efrat"));
                var classBinstance = new B();
                Console.WriteLine(InvokeHello(classBinstance, "Efrat"));
                var classCinstance = new C();
                Console.WriteLine(InvokeHello(classCinstance, "Efrat"));
            }
            catch (TargetInvocationException tiExeption)
            {
                Console.WriteLine($"InvokeHello method faild ! while runnig it got a {tiExeption.InnerException.GetType()}\n with message {tiExeption.InnerException.Message}"); 
            }
           
        }
        /// <summary>
        ///  looking for the “Hello” method in the Object obj
        ///  and dynamically invoke it with the string argument provided. 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="str"></param>
        static string InvokeHello(Object obj, String str)
        {
            try
            {
                object[] param = { str };
                Type thisType = obj.GetType();
                MethodInfo theMethod = thisType.GetMethod("Hello");
                return (string)theMethod.Invoke(obj, param);
            }
            catch (Exception ex)
            {
                throw new TargetInvocationException(ex);
            }
            

        }
    }
}
