using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs
{
    /// <summary>
    /// 8.	Part B:
    ///a.Let’s assume the Native Job is holding a lot of native memory
    ///b.Add a call in the Job ctor to GC.AddMemoryPressure(sizeInByte) 
    ///and display a message that the Job was created
    ///c.Add a call in the finalizer to GC.RemoveMemoryPressure(sizeInBytes)
    ///and display a message that the Job was released
    ///d.Create a loop in your main method that creates 20 Job objects
    ///e.See what happens when you run the application with different “sizeInBytes”.
    ///Try 0 MB and 10 MB
    /// </summary>
    public class Job : IDisposable
    {
        #region fields

        private bool _disposed;

        private IntPtr _hJob;

        private List<Process> _processes;

        #endregion

        #region ctors

        /// <summary>
        /// 3.	Implement the constructor of the Job class,
        /// that accepts a string called “name”:
        /// a.   Call NativeJob.CreateJobObject passing IntPtr.Zero and the name argument.
        ///      Store the returning handle in _hJob.
        /// b.   If the handle is zero (IntPtr.Zero), throw an InvalidOperationException.
        /// c.   Create the _processes object.
        /// </summary>
        /// <param name="name"></param>
        public Job(string name, int sizeInByte)
        {
            _hJob = NativeJob.CreateJobObject(IntPtr.Zero, name);
            if (_hJob == IntPtr.Zero)
            {
                throw new InvalidOperationException();
            }
            _processes = new List<Process>();

            GC.AddMemoryPressure(sizeInByte);
        }

        public Job()
            : this(null, 0)
        {
        }

        #endregion

        private void CheckIfDisposed()
        {

        }

        protected void AddProcessToJob(IntPtr hProcess)
        {
            CheckIfDisposed();

            if (!NativeJob.AssignProcessToJobObject(_hJob, hProcess))
                throw new InvalidOperationException("Failed to add process to job");
        }

        public void AddProcessToJob(int pid)
        {
            AddProcessToJob(Process.GetProcessById(pid));
        }

        public void AddProcessToJob(Process proc)
        {
            Debug.Assert(proc != null);
            AddProcessToJob(proc.Handle);
            _processes.Add(proc);
        }

        /// <summary>
        /// 5.	Implement the Kill method by calling NativeJob.TerminateJobObject.
        /// </summary>
		public void Kill()
        {
            NativeJob.TerminateJobObject(_hJob, 0);

        }

        /// <summary>
        /// 4.	Implement the IDisposable interface on the Job class.
        ///        Use the following guidelines:
        ///     a.
        ///     Make use of the Dispose pattern, i.e.create a Dispose(bool) method as discussed in the course.
        ///     b.
        ///     Make sure calling Dispose multiple times is harmless,
        ///     while calling anything substantial if the object is disposed throws a ObjectDisposedException.
        /// </summary>

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                foreach (var proc in _processes)
                {
                    proc.Dispose();
                }
            }
            NativeJob.CloseHandle(_hJob);
            _disposed = true;
        }

        ~Job()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
