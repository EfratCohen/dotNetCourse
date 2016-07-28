using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    
    class LimitedQueue<T>
    {
        
        /// for the need to make sure that readers wont fail to read if there are concurrent writers
        ///actually  - we alow only one reader(Deque) and arbitary[but limited] no' of writers(Enque)
        ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();
        
        Queue<T> _queue = new Queue<T>();
        SemaphoreSlim _semaphore;
        public void Enque(T elment)
        {
            _semaphore.Wait();
            _readerWriterLock.EnterReadLock();
            _queue.Enqueue(elment);
            _readerWriterLock.ExitReadLock();
        }
        /// <summary>
        /// Removes and returns the element of the LimitedQueue<T>
        /// if it is empty return default(T)
        /// </summary>
        /// <returns></returns>
        public T Deque()
        {
            T elment = default(T);
           if (_queue.Count > 0)
            {
                _readerWriterLock.EnterWriteLock();
                elment= _queue.Dequeue();
                _readerWriterLock.ExitWriteLock();
                _semaphore.Release();
            }
            return elment;

        }

        public LimitedQueue(int maxQueueSize)
        {
            _semaphore = new SemaphoreSlim(maxQueueSize);
        }
    }
}
