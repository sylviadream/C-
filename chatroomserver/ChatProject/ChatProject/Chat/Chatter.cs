using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProject.Chat
{
    class Chatter : IChatter
    {
        private string alias;

        public Chatter(string pseudo)
        {
            this.alias = pseudo;
        }

        public void ReceiveAMessage(string msg, IChatter c)
        {
            Console.Out.WriteLine("(At " + this.alias + ") : " + c.Alias + " $> " + msg);
        }

        public string Alias
        {
            get { return this.alias; }
        }
    }
}
