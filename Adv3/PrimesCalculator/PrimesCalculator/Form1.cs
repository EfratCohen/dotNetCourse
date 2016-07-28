using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class Form1 : Form
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

        AutoResetEvent _autoResetEvent;
        CancellationTokenSource _CancellationTokenSource;

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
                #region for 7.2
                _autoResetEvent = new AutoResetEvent(false); //a.
                _CancellationTokenSource = new CancellationTokenSource(); //b.
                var cacellationToken = _CancellationTokenSource.Token;
                #endregion
                List<int> primes = new List<int>();
                await PrimeNumbersCalculateAsync(lowRangeBound, highRangeBound, primes,cacellationToken);
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
        private async Task PrimeNumbersCalculateAsync(int lowRangeBound, int highRangeBound, List<int> primes,CancellationToken token)
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
                    #region I have added this because i wasn't fast inugh to cacncle or stop the caculateing before it ended.
                    Thread.Sleep(1000);
                    #endregion
                    #region for 7.2
                    //a.
                    bool isSTOPSignald= _autoResetEvent.WaitOne(0);
                    if(isSTOPSignald)
                    {
                        return;
                    }
                    //b.
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    #endregion
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
        /// <summary>
        /// 7.2.b.	Use a CancellationToken to signal the cancellation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCANCEL_Click(object sender, EventArgs e)
        {
            _CancellationTokenSource.Cancel();
        }
        /// <summary>
        /// 7.2.a.	Use an Event object to signal the thread to “bail out” early. 
        /// by call WaitHandle.WaitOne with a timeout of zero to just “check” if the object is signalled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSTOP_Click(object sender, EventArgs e)
        {
            _autoResetEvent.Set();
        }
    }
}

