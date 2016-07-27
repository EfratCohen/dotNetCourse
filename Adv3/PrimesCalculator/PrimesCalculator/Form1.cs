using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 3.
        /// When the user presses the “Calculate” button,
        /// spawn a new thread or Task 
        /// and calculate the prime numbers within the range indicated by the textboxes.
        /// 
        /// 4.	
        /// When done, 
        /// populate the list box with the numbers. 
        /// Note that you need to access the list box within the UI thread 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Calculate_Click(object sender, EventArgs e)
        {
            int lowRangeBound, highRangeBound ;
            bool isValidInput = GetRangeBounds(out lowRangeBound, out highRangeBound);
            if (isValidInput)
            {
                List<int> primes = new List<int>();
                await PrimeNumbersCalculateAsync(lowRangeBound, highRangeBound, primes);
                listBox1.DataSource = primes;
            }
            else
            {
                MessageBox.Show("Invalid inputs!");
            }          
        }
        /// <summary>
        /// calculate the prime numbers within the range
        /// </summary>
        /// <param name="lowRangeBound"></param>
        /// <param name="highRangeBound"></param>
        /// <returns></returns>
        private async Task PrimeNumbersCalculateAsync(int lowRangeBound, int highRangeBound, List<int> primes)
        {
            PrimearyChecker primeCheck = new PrimearyChecker();
            await Task.Run(() =>
            {
                for (int j = 0; j < (highRangeBound - lowRangeBound + 1); j++)
                {
                    if (primeCheck.isPrime(lowRangeBound + j))
                    {
                        primes.Add(lowRangeBound + j);
                    }
                }
            }
            );
        }
        /// <summary>
        /// get the range indicated by the textboxes
        /// </summary>
        /// <param name="lowRangeBound"></param>
        /// <param name="highRangeBound"></param>
        private bool GetRangeBounds(out int lowRangeBound, out int highRangeBound )
        {
            bool isValidInput = int.TryParse((textBox1 as TextBox).Text, out lowRangeBound);
            isValidInput &= int.TryParse((textBox2 as TextBox).Text, out highRangeBound);
            isValidInput &= lowRangeBound <= highRangeBound;
            return isValidInput;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {      
        }
    }

    namespace Primes
    {
        class Program
        {
            /// <summary>
            /// Accept two numbers from the console. 
            /// Call CalcPrimes with the numbers, and display the results.
            /// </summary>
            /// <param name="args"></param>
            static void pMain(string[] args)
            {
                int lowRangeBound, highRangeBound;
                Console.WriteLine("please enter a positive integer to the range's low bound ");
                GetPositiveIntegr(out lowRangeBound);
                Console.WriteLine("please enter a positive integer to the range's high bound ");
                GetPositiveIntegr(out highRangeBound);
                int[] output = CalcPrimes(lowRangeBound, highRangeBound);
                Console.WriteLine("the prime numbers in [" + lowRangeBound + "," + highRangeBound + "] is:");
                for (int i = 0; i < output.Length; i++)
                {
                    Console.Write(output[i] + " ");
                }
                Console.Write("\n");
            }
            /// <summary>
            ///  get a console input 
            ///  check if it is positive integer
            ///  if yes- put it into the param;
            ///  if no- try again until sucsses
            /// </summary>
            /// <param name="input"></param>
            static void GetPositiveIntegr(out int input)
            {
                string inputString = Console.ReadLine();
                inputString = inputString.Trim();
                while (!(int.TryParse(inputString, out input)))
                {
                    Console.WriteLine("we get wrong input, try again to enter a positive integer");
                    inputString = Console.ReadLine();
                    inputString = inputString.Trim();
                }
            }
            /// <summary>
            /// Calculate all the prime numbers in the range of the numbers passed as arguments. 
            /// Collect all primes in an ArrayList. Return the result.
            /// </summary>
            /// <param name="lowRangeBound"></param>
            /// <param name="highRangeBound">should be bigger then or equal to the first parameter</param>
            /// <returns>integer's array of all the prime numbers in the range of the numbers passed as arguments</returns>
            static int[] CalcPrimes(int lowRangeBound, int highRangeBound)//(hint: you can use ArrayList.CopyTo).
            {
                System.Collections.ArrayList primesInTheRange = new System.Collections.ArrayList();
                int finalSize = 0;
                if (lowRangeBound <= highRangeBound) //we calculate only if we get a legal renge
                {
                    PrimearyChecker primeCheck = new PrimearyChecker();

                    for (int j = 0; j < (highRangeBound - lowRangeBound + 1); j++)
                    {
                        if (primeCheck.isPrime(lowRangeBound + j))
                        {
                            primesInTheRange.Add(lowRangeBound + j);
                        }
                    }

                }
                finalSize = primesInTheRange.Count;
                int[] primes = new int[finalSize];
                primesInTheRange.CopyTo(primes);
                return primes;
            }
        }
        class PrimearyChecker
        {
            /// <summary>
            /// check if a number is primeary
            /// </summary>
            /// <param name="number"></param>
            /// <returns>true-if it is prime, fals- o.w.</returns>
            public bool isPrime(int number)
            {
                int boundary = (int)Math.Floor(Math.Sqrt(number));

                if (number == 1) return false;
                if (number == 2) return true;

                for (int i = 2; i <= boundary; ++i)
                {
                    if (number % i == 0) return false;
                }

                return true;
            }
        }
    }


}

