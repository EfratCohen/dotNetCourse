using System;

namespace PrimesCalculator
{
    internal class PrimearyChecker
    {
          /// <summary>
            /// check if a number is primeary
            /// </summary>
            /// <param name="number"></param>
            /// <returns>true-if it is prime, fals- o.w.</returns>
            public bool isPrime(int number)
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
    }
}
