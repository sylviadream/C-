using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;


namespace ChatProject.Net
{
    class TCPClient : IMessageConnection
    {
        private TcpClient sock;
        private IPAddress adr;
        private int port;
        Socket sockConnection = null;
        Thread thred = null;
        public string filePathConst = null;


        public TCPClient()
        {
         //   this.sock = new TcpClient();
        }

        public void SetServer(IPAddress adr, int port)
        {
            this.adr = adr;
            this.port = port;
        }



        public void Connection(string adr,int port)
            {
            try
            {
                sockConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = this.adr;
                IPEndPoint endPoint = new IPEndPoint(ip, this.port);
                sockConnection.Connect(endPoint);

                thred = new Thread(Receive);
                thred.IsBackground = true;//设置当前进程是前台还是后台   默认是前台  前台的话关闭窗体进程还在运作  后台在窗体关闭时就关闭了
                thred.Start();
            }
            catch (Exception ex)
            {
                ShowErr("", ex);
            }
        }

        private void Receive()
        {
            while (true)
            {
                try
                {
                    byte[] by = new byte[1024 * 1024 * 4];
                    int length = sockConnection.Receive(by);
                    switch (by[0])
                    {
                        case 0:
                            //ShowMag(Encoding.UTF8.GetString(by, 1, length)); break;
                        case 1:
                            //FileMassage fileMess = new FileMassage(by, length);
                            //ParameterizedThreadStart para = new ParameterizedThreadStart(FileObject);
                            //threadFile = new Thread(para);
                            //threadFile.Start(fileMess);
                            try
                            {
                                Thread threadRec = new Thread(OpenFile);
                                threadRec.SetApartmentState(ApartmentState.STA);
                                threadRec.IsBackground = true;
                                threadRec.Start();
                                if (filePathConst != null)
                                {
                                    using (FileStream fs = new FileStream(filePathConst, FileMode.Create))
                                    {
                                        byte[] byteFile = new byte[1024 * 1024 * 4];
                                        Buffer.BlockCopy(by, 1, byteFile, 0, length);
                                        fs.Write(byteFile, 0, length - 1);
                                    }
                                }
                                //OpenFileDialog filePath = new OpenFileDialog();
                                //filePath.InitialDirectory = @"G:\TDDOWNLOAD\net\传智播客.Net培训精品就业班2\20110403\Charroom多人聊天";
                                //filePath.ShowDialog();
                                //if (filePath.ShowDialog() == DialogResult.OK)
                                //{
                                //    using (FileStream fs = new FileStream(filePath.FileName, FileMode.Create))
                                //    {
                                //        byte[] byteFile = new byte[1024 * 1024 * 4];
                                //        Buffer.BlockCopy(by, 1, byteFile, 0, length);
                                //        fs.Write(byteFile, 0, length - 1);
                                //    }
                                //}
                            }
                            catch (Exception ex)
                            {
                                ShowErr("接受失败：", ex);
                            }
                            break;
                        case 2: sockConnection.Close(); thred.Abort(); break;
                        case 3: MessageBox.Show("好好听课！！！！！！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); break;
                    }

                }
                catch (Exception ex)
                {

                    ShowErr("", ex);
                }
            }
        }

        public void ShowErr(string mag, Exception ex)
        {
            ShowMag("---------------Start----------------------");
            ShowMag(mag + ":" + ex.Message);
            ShowMag("---------------End  ----------------------");
        }
        public void ShowMag(string mag)
        {
          
            MessageBox.Show(mag + "\r\n");
        }


        public void Disconnect()
        {
            sock.Close();
        }

        public Message GetMessage()
        {
            return new Message(new Header("msg_serveur", "lol"), "Envoyer !");
        }

        public void SendMessage(Message msg)
        {
            
        }

        private void OpenFile()
        {
            OpenFileDialog filePath = new OpenFileDialog();
            filePath.InitialDirectory = @"G:\TDDOWNLOAD\net\传智播客.Net培训精品就业班2\20110403\Charroom多人聊天";
            if (filePath.ShowDialog() == DialogResult.OK)
            {
                //return filePath;
                filePathConst = filePath.FileName;
            }
            //return filePath;
        }
    }
}
