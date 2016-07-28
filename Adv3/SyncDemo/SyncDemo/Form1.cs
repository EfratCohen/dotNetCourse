using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncDemo
{
    /// <summary>
    /// 3.	Create a Mutex object with the name “SyncFileMutex”, starting in the non-signaled state.
    /// 4.	Open or create a file named “data.txt” in the “c:\temp” folder(create the folder using Windows Explorer or in code if it does not exist).
    /// 5.	Create a loop that writes 10000 times a string that includes the process identifier
    /// (look at System.Diagnostics.Process class),
    /// while providing a WaitOne/ReleaseMutex around the code.
    /// 6.	Run two instances of the application simultaneously and check the resulting file.
    /// 7.	Comment out the mutex operations and rerun.
    /// Make sure you understand the results.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Mutex _myMutex;

        private void out_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSTART_Click(object sender, EventArgs e)
        {
            //3.
            _myMutex = new Mutex(false, "SyncFileMutex");
            //4.
            Directory.CreateDirectory(@"C:\temp");
            
            var myFileStream =File.Open(@"C:\temp\data.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            StreamWriter myWriter = new StreamWriter(myFileStream);
            //5.
            string text = $"the writing procees id is {Process.GetCurrentProcess().Id}";
            _myMutex.WaitOne();
            for (int i = 0; i < 10000; i++)
            {
                myWriter.WriteLine(text);
            }
            _myMutex.ReleaseMutex();
            //7.


        }
    }
}

