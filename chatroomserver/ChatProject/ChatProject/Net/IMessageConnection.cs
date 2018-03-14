using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProject.Net
{
    interface IMessageConnection
    {
        Message GetMessage();
        void SendMessage(Message m);
    }
}
