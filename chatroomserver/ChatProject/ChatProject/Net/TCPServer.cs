using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace ChatProject.Net
{
    class TCPServer : ICloneable, IMessageConnection
    {
        private TcpClient commSocket;
      //  private TcpListener waitSock;
        private int port;
        private bool doRun;
        private string mode = "Waitting";
        Socket socServer = null;
        Thread thread = null;
        Socket socConnection = null;


        public TCPServer()
        {
          
        }

  

        public void StartServer(int port, string adr)
        {
            doRun = true;
            this.port = port;

            try
            {
                IPAddress ip = IPAddress.Parse(adr);
                IPEndPoint endPoint = new IPEndPoint(ip, port);

                socServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socServer.Bind(endPoint);
                socServer.Listen(10);
                thread = new Thread(WitchPort);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*
            waitSock = new TcpListener(ip, port);
            waitSock.Start();
            Thread serveur = new Thread(new ThreadStart(Run));
            serveur.Start();
    */
        }

        public void WitchPort()
        {
            //死循环，不停地监听连接过来的
            while (true)
            {
                try
                {
                    //为连接过来的用户创建端口
                    socConnection = socServer.Accept();
                    //socConnection.RemoteEndPoint获取连接过来的主机IP地址
                 //   ShowMag("已连接到···" + socConnection.RemoteEndPoint.ToString());
                   // listBoxCompute.Items.Add(socConnection.RemoteEndPoint.ToString());
                    //为消息发送机制创建线程
                 //   threadMag = new Thread(Receive);
                    //启动消息发送线程
                //    listSock.Add(socConnection);
                //    dictionary.Add(socConnection.RemoteEndPoint.ToString(), threadMag);
                 //   threadMag.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        public void StopServer()
        {
            doRun = false;
            //waitSock.Stop();
        }

        public void Run()
        {
            if (mode == "treatClient")
                GereClient(commSocket);
            else
            {
                while (doRun)
                {
                    try
                    {
                    //    commSocket = waitSock.AcceptTcpClient();
                        TCPServer myClone = (TCPServer)this.Clone();
                        myClone.mode = "treatClient";
                        new Thread(new ThreadStart(myClone.Run)).Start();
                    }
                    catch (Exception e) { Console.Error.WriteLine(e); }
                }
            }
        }

        public int GetPort
        {
            get { return port; }
        }

        public object Clone()
        {
            return this.Clone();
        }

        public void GereClient(TcpClient comm)
        {
         }
        public Message GetMessage()
        {
            return new Message(new Header("msg_client", "lol"), "Accepter !");
        }

        public void SendMessage(Message m)
        {

        }
    }
}
