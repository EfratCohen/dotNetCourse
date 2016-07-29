using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    internal class PrimesCalculator
    {
        /// <summary>
        /// check if a number is primeary
        /// </summary>
        /// <param name="number"></param>
        /// <returns>true-if it is prime, false- o.w.</returns>
        bool IsPrime(int number)
        {
            int boundary = (int)Math.Floor(Math.Sqrt(number));

            if (number <= 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        public void CalcPrimes(int lowRangeBound, int highRangeBound, List<int> primes)
        {
            if (lowRangeBound <= highRangeBound) //we calculate only if we get a legal renge
            {
                for (int j = 0; j < (highRangeBound - lowRangeBound + 1); j++)
                {
                    if (IsPrime(lowRangeBound + j))
                    {
                        primes.Add(lowRangeBound + j);
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("highRangeBound", "highRangeBound must be >=lowRangeBound. we don't now how to work with neg' range ");
            }
        }

    }
}
