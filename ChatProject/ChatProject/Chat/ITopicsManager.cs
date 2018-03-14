using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProject.Chat
{
    interface ITopicsManager
    {
        void listTopics();
        Chatroom JoinTopic(string topic);
        void createTopic(string topic);
    }
}
