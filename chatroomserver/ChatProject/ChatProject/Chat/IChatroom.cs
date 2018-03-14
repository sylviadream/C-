using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProject.Chat
{
    interface IChatroom
    {
        void post(string msg, IChatter c);
        void Quit(IChatter c);
        void join(IChatter c);
        string Topic { get; }
    }
}