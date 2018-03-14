using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProject.Chat
{
    interface IChatter
    {
        void ReceiveAMessage(string msg, IChatter c);
        string Alias { get; }
    }
}
