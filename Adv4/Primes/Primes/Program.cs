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
        ///1.	Continue from the previous exercise.

        

        static void Main(string[] args)
        {
            #region lab1 
            int first = 0, last = 700, maxParallelDegree = 4;
            var outputList = new List<int>();     
            var sincCalc = new PrimesCalculator();
            var watch = new Stopwatch();
            for (int i = 1; i < 17; i++)
            {
                watch.Restart();
                Lab1CalcPrimes(first, last, maxParallelDegree);
                watch.Stop();
                Console.WriteLine($"the parllel calc took {watch.ElapsedTicks} Ticks, with {i} maxParlleldeg");
             }
            watch.Restart();
            sincCalc.CalcPrimes(first, last, outputList);
            watch.Stop();
            Console.WriteLine($"the sinc calc took {watch.ElapsedTicks}  Ticks");
            #endregion
            #region lab2
            last = 30000000;
            outputList=CalcPrimes(first, last);
            Console.WriteLine($"{outputList.Count} is how many numbers returned before being cancelled");
            #endregion


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
        static List<int> Lab1CalcPrimes(int first, int last, int maxParallelDegree)
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


        ///1.	Continue from the previous exercise.
        ///2.	Change the signature of CalcPrimes to accept two integers and nothing else. Remove the ParallelOptions object and use the default degree of parallelism.
        ///3.	We want to cancel the operation randomly.Add a Random instance in the CalcPrimes method before the parallel loop starts.
        ///4.	The lambda expression should accept a ParallelLoopState variable as well as the loop index.Look at the other overloads of Parallel.For.
        ///5.	In the lambda expression, call Random.Next with 10000000 as argument, and check for the return of zero. If it is, call the Stop method of ParallelLoopState.
        ///6.	Call CalcPrimes from Main with the last number as 30000000 and display how many numbers returned before being cancelled.
        static List<int> CalcPrimes(int first, int last)
        {
            int maxParallelDegree = 7;
            var primesInRange = new List<int>();
            var primesRange = new List<int>[maxParallelDegree];
            for (int i = 0; i < maxParallelDegree; i++)
            {
                primesRange[i] = new List<int>();
            }
            int range = (int)Math.Floor((double)(((last - first) / maxParallelDegree)));
            var primeCalc = new PrimesCalculator();

            var rand = new Random();

            Parallel.For(0, maxParallelDegree - 1, (i, state) =>
            {
                if (rand.Next(10000000) == 0)
                {
                    state.Stop();
                }
                else
                {
                    primeCalc.CalcPrimes((int)(first + i * range), (int)(first + (i + 1) * range), primesRange[i]);
                }
            }
            );


            for (int i = 0; i < maxParallelDegree; i++)
            {
                if (primesRange[i] != null)
                {
                    primesInRange.AddRange(primesRange[i]);
                }
            }
            return primesInRange;
        }
    }
}
