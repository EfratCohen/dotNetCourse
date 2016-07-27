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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
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
                primesListBox.DataSource = primes;
            }
            else
            {
                MessageBox.Show("\tInvalid inputs!\n Please enter two intergers, one higher then the other.");
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
            bool isValidInput = int.TryParse((lowBoundBox as TextBox).Text, out lowRangeBound);
            isValidInput &= int.TryParse((highBoundBox as TextBox).Text, out highRangeBound);
            isValidInput &= lowRangeBound <= highRangeBound;
            return isValidInput;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

