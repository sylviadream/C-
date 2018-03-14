using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProject.Chat
{
    class Chatroom : IChatroom
    {
        private string topic;
        List<IChatter> participants;

        public Chatroom(string topic)
        {
            this.topic = topic;
            this.participants = new List<IChatter>();
        }

        public void post(string msg, IChatter c)
        {
            foreach(var v in participants)
            {
                v.ReceiveAMessage(msg, c);
            }
        }

        public void Quit(IChatter c)
        {
            Console.Out.WriteLine("(Message from Chatroom : " + this.topic + ") " + c.Alias + " has quit the room.");
            this.participants.Remove(c);
        }

        public void join(IChatter c)
        {
            Console.Out.WriteLine("(Message from Chatroom : " + this.topic + ") " + c.Alias + " has join the room.");
            this.participants.Add(c);
        }

        public string Topic
        {
            get { return topic; }
        }
    }
}
