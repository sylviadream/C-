using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace ChatProject.Net
{
    [Serializable]
    class Message
    {
        public Header head;
        public string data;

        public Message(Header head, string data)
        {
            this.head = head;
            this.data = data;
        }

        public override string ToString()
        {
            return data;
        }
    }
}
