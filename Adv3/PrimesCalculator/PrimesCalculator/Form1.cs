using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void Form_Load(object sender, EventArgs e)
        {

        }

        CancellationTokenSource _CancellationTokenSource;

        private async void Calculate_Click(object sender, EventArgs e)
        {
            int lowRangeBound, highRangeBound ;

            bool isValidInput = GetRangeBounds(out lowRangeBound, out highRangeBound);

            if (isValidInput)
            {

                _CancellationTokenSource = new CancellationTokenSource();

                var cacellationToken = _CancellationTokenSource.Token;


               int noOfPrimesInTheRange =await CountPrimesAsync(lowRangeBound, highRangeBound,cacellationToken);

                string outPutText = $"The number of prime-numbers in the range [{lowRangeBound},{highRangeBound}]  is  {noOfPrimesInTheRange}.";

                OutPutLabel.Text = outPutText;

                string outputFilePath = OutputFileTextBox.Text;

                if (Path.IsPathRooted(outputFilePath)&& outputFilePath.EndsWith(".txt"))
                {
                    using (StreamWriter writer =new StreamWriter(outputFilePath))
                    {
                        writer.Write(outPutText);
                    }
                }
                else
                {
                    MessageBox.Show("\tInvalid input!\n The entered Output File path wrong, \n\tS We dont write to it.");
                }
            }
            else
            {
                MessageBox.Show("\tInvalid inputs!\n Please enter two intergers, one higher then the other.");
            }          
        }
        /// <summary>
        /// calculate the nomber of prime numbers within the range
        /// </summary>
        /// <param name="lowRangeBound"></param>
        /// <param name="highRangeBound"></param>
        /// <returns></returns>
        private async Task<int> CountPrimesAsync(int lowRangeBound, int highRangeBound,CancellationToken token)
        {
            int noOfPrimesInTheRange = 0;

            PrimearyChecker primeCheck = new PrimearyChecker();

            return await Task<int>.Run(() =>
            {
                for (int j = 0; j < (highRangeBound - lowRangeBound + 1); j++)
                {
                    if (primeCheck.isPrime(lowRangeBound + j))
                    {
                        noOfPrimesInTheRange++;
                    }
                    #region I have added this because i wasn't fast inugh to cacncle or stop the caculateing before it ended.
                    //Thread.Sleep(1000);
                    #endregion

                    if (token.IsCancellationRequested)
                    {
                        return noOfPrimesInTheRange;
                    }
                }
                return noOfPrimesInTheRange;
            } );
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

        /// <summary>
        /// Use a CancellationToken to signal the cancellation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCANCEL_Click(object sender, EventArgs e)
        {
            _CancellationTokenSource.Cancel();
        }
    }
}

