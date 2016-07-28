using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    /// <summary>
    /// 4.	Build some test code that adds and removes items from the queue from various threads 
    /// (you can use the thread pool or Tasks) randomly 
    /// so that at each point the queue is no larger than the maximum specified at creation time.
    /// </summary>
    public class LimitedQueueChecker
    {
        public void AddRandomly(LimitedQueue<int> myQ, CancellationTokenSource cancel ,ref string addMsg)
        {
            int addingNo=0;
            Random r = new Random();
            while (!cancel.IsCancellationRequested)
            {
                int element =r.Next()%10;
                myQ.Enque(element);
                addingNo++;
                addMsg = $"the last adding was of {element} to {myQ}\n it was adding no' {addingNo}";
                Thread.Sleep(r.Next()%1000);  
            }
        }
        public void RemoveRandoly(LimitedQueue<int> myQ, CancellationTokenSource cancel, ref string rmvMsg)
        {
            int rmvNo=0;
            Random r = new Random();
            while (!cancel.IsCancellationRequested)
            {
                int element = myQ.Deque();
                rmvNo++;
                rmvMsg = $"the last remove was of {element} from {myQ}\n it was remove no' {rmvNo}";
                Thread.Sleep(r.Next()%10000);
            }
        }

    }
}
