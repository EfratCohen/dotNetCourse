using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Primes
{
    class Program
    {
        /// <summary>
        /// 3.	
        /// Call CalcPrimes from the Main method and compare its performance with a sequential implementation,
        /// by creating a ParallelOptions instance and setting its MaxDegreeOfParallelism property to the passed number.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int first = 0, last = 700, maxParallelDegree = 4;
            var outputList = new List<int>(); 
            var sincCalc = new PrimesCalculator();
            var watch = new Stopwatch();
            for (int i = 1; i < 17; i++)
            {
                watch.Restart();
                CalcPrimes(first, last, maxParallelDegree);
                watch.Stop();
                Console.WriteLine($"the parllel calc took {watch.ElapsedTicks} Ticks, with {i} maxParlleldeg");
             }
            watch.Restart();
            sincCalc.CalcPrimes(first, last, outputList);
            watch.Stop();
            Console.WriteLine($"the sinc calc took {watch.ElapsedTicks}  Ticks");
        }
        /// <summary>
        /// 2.	
        /// Create a static method called CalcPrimes
        /// that accepts a first and last number and a maximum degree of parallelism (an integer)
        /// and returns a list of prime numbers in that range.
        /// Use the Parallel class. 
        /// Make sure you add items to the collection in a thread-safe way. 
        /// Use a lambda expression to execute the body of the parallel loop
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="maxParallelDegree"></param>
        /// <returns></returns>
        static List<int> CalcPrimes(int first, int last, int maxParallelDegree)
        {
            var primesInRange = new List<int>();
            var primesRange = new List<int>[maxParallelDegree];
            for (int i = 0; i < maxParallelDegree; i++)
            {
                primesRange[i] = new List<int>();
            }
            int range = (int)Math.Floor((double)(((last - first) / maxParallelDegree)));
            var primeCalc = new PrimesCalculator();
            var option = new ParallelOptions();
            option.MaxDegreeOfParallelism = maxParallelDegree;            
            Parallel.For(0, maxParallelDegree - 1, option, (i) => 
            {
                primeCalc.CalcPrimes((int)(first + i *range) ,(int)( first + (i + 1) * range), primesRange[i]);
            }
            );    
            for (int i = 0; i < maxParallelDegree; i++)
            {
                if(primesRange[i]!=null)
                {
                    primesInRange.AddRange(primesRange[i]);
                }
            }
            return primesInRange;
        }
    }
}
