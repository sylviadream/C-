using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;
using System.Net;
using System.Net.Sockets;
using ChatProject.Chat;
using ChatProject.Authentification;
using ChatProject.Net;


namespace ChatProject
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
          static void Main()
           {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

    
/*
              Chatter bob = new Chatter("Bob");
              Chatter joe = new Chatter("Joe");
              TopicManager gt = new TopicManager();

              gt.createTopic("java");
              gt.createTopic("UML");
              gt.listTopics();
              gt.createTopic("jeux");
              gt.listTopics();
              Chatroom cr;
              cr = gt.JoinTopic("jeux");
              cr.join(bob);
              cr.post("Je suis seul ou quoi ?", bob);
              cr.join(joe);
              cr.post("Tiens, salut Joe !", bob);
              cr.post("Toi aussi tu chat sur les forums de jeux pendant les TP, Bob ?", joe);

*/
            IAuthentificationManager am = new GestAuthentification();

               //users management
  /*             try
               {
                   am.AddUser("bob", "123");
                   Console.Out.WriteLine("Bob has been added !");
                   am.RemoveUser("bob");
                   Console.Out.WriteLine("Bob has been removed !");
                   am.RemoveUser("bob");
                   Console.Out.WriteLine("Bob has been removes twice !");
               }
               catch (UserUnknown e) { e.DisplayError(); }
               catch (UserExits e) { e.DisplayError(); }*/

               //authentification
          /*     try
               {
                   am.AddUser("bob", "123");
                   Console.Out.WriteLine("Bob has been added !");
                   am.Authentify("bob", "123");
                   Console.Out.WriteLine("Authentification OK !");
                   am.Authentify("bob", "456");
                   Console.Out.WriteLine("Invalid password !");
               }
               catch (WrongPassword e) { e.DisplayError(); }
               catch (UserExits e) { e.DisplayError(); }
               catch (UserUnknown e) { e.DisplayError(); }

               //persistance
               try
               {
                   am.Save("users.txt");
                   IAuthentificationManager am1 = new GestAuthentification();
                   am1.Load("users.txt");
                   am1.Authentify("bob", "123");
                   Console.Out.WriteLine("Loading complete !");
               }
               catch (UserUnknown e) { e.DisplayError(); }
               catch (WrongPassword e) { e.DisplayError(); }
               //}
           }

        class BasicTCPServer : TCPServer
        {
            public override void GereClient(TcpClient comm)
            {
                Console.Out.WriteLine(GetMessage());
                SendMessage(new Net.Message(new Header("msg_client", "lol"), "pong from server"));
                Console.Out.WriteLine("Server finished handlig client, quitting");
            }

          /*  static void Main()
            {
                BasicTCPServer serv = new BasicTCPServer();

                try
                {
                    serv.StartServer(1664);
                    Console.Out.WriteLine("Press enter to quit...");
                    Console.In.Read();
                    serv.StopServer();
                }
                catch (Exception e) { Console.Out.WriteLine(e); }

                TCPClient cli = new TCPClient();
                try
                {
                    cli.SetServer(IPAddress.Any, 1664);
                    cli.Connect();
                    cli.SendMessage(new Net.Message(new Header("msg_client", "lol"), "Ping from client !"));
                    Console.Out.WriteLine(cli.GetMessage());
                    cli.Disconnect();
                }
                catch (Exception e) { Console.Out.WriteLine(e); }
            }*/
        }
    }
}