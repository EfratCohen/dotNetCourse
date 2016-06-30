using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailArrivedEventArgs : EventArgs
    {

        public String Title { get; }
        public String Body { get; }
        public MailArrivedEventArgs(String title, String body)
        {
            Title = title;
            Body = body;
        }
        public MailArrivedEventArgs(String title) : this(title, "no body") { }
    }
}
