using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;
        /// <summary>
        /// raise the event
        /// </summary>
        /// <param name="mailArrivedArgs"></param>
        protected virtual void OnMailArrived(MailArrivedEventArgs mailArrivedArgs)
        {
            if(MailArrived!= null)
            {
                MailArrived(this, mailArrivedArgs);
            }
            
        }
        /// <summary>
        /// calls OnMailArrived with some dummy data
        /// </summary>
        public void SimulateMailArrived()
        {
            var mailArrivedArgs = new MailArrivedEventArgs("A message to the Checker", "Dear Checker, I wish to get a good remaks in this lab please."); 
            OnMailArrived(mailArrivedArgs);
        }
    }
}
