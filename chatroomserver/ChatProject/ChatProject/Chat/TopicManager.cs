using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProject.Chat
{
    class TopicManager : ITopicsManager
    {
        private List<string> topicsList;

        public TopicManager()
        {
          this.topicsList = new List<string>();
        }

        public void listTopics()
        {
            Console.Out.WriteLine("The openned topics are :");
            foreach(var v in topicsList)
            {
                Console.Out.WriteLine(v);
            }
        }

        public Chatroom JoinTopic(string topic)
        {
            Chatroom cr = new Chatroom(topic);
            return cr;
        }

        public void createTopic(string topic)
        {
            this.topicsList.Add(topic);
        }


    }
}
