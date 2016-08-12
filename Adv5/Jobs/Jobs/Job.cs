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
        ///c.   Add a call in the finalizer to GC.RemoveMemoryPressure(sizeInBytes)
        ///    and display a message that the Job was released

    /// </summary>
    public class Job : IDisposable
    {
        #region fields

        private bool _disposed;

        private IntPtr _hJob;

        private List<Process> _processes;

        private int _sizeInByte;

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

            _sizeInByte=sizeInByte;

            if (_sizeInByte > 0)
            {
                GC.AddMemoryPressure(sizeInByte);
            }
            
            Console.WriteLine($"A Job with the name {name} has created with ask for {sizeInByte} (sizeInByte) memory from the GC ");
        }

        public Job()
            : this(null, 0)
        {
        }

        #endregion

        private void CheckIfDisposed()
        {
            if (_disposed)
            {
                throw new InvalidOperationException("Failed to add process to disposed job");
            }
        }

        protected void AddProcessToJob(IntPtr hProcess)
        {
            
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

		public void Kill()
        {
            NativeJob.TerminateJobObject(_hJob, 0);

        }

        #region Dispose pattern

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

            if (_sizeInByte > 0)
            {
                GC.RemoveMemoryPressure(_sizeInByte);
            }
            Console.WriteLine("Job was released");

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        ~Job()
        {
            Dispose(false);

        }
    }
}
