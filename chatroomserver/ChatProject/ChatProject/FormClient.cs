using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using  ChatProject.Net;
using System.Threading;
using System.IO;
using System.Net;
namespace ChatProject
{
    public partial class FormClient : Form
    {
        string adr;
        int port;
        Thread thred = null;
        Socket sockConnection = null;
        public string filePathConst = null;
    

        public FormClient(string username, string roomroom, string adress, int port)
        {
           InitializeComponent();
           TextBox.CheckForIllegalCrossThreadCalls = false;
           label5.Text = username;
           label1.Text = roomroom;
            this.adr = adress;
            this.port = port;        
        }

   

        private void Connection()

        {

            try
            {
                sockConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(this.adr);
                IPEndPoint endPoint = new IPEndPoint(ip, this.port);
                sockConnection.Connect(endPoint);
                ShowMag("reussir");

                thred = new Thread(Receive);
                thred.IsBackground = true;
                thred.Start();

            }
            catch (Exception ex)
            {
                ShowErr("", ex);
            }


        }



        private void button3_Click(object sender, EventArgs e)
        {
            Connection();
       
        }
        public void ShowErr(string mag, Exception ex)
        {
            ShowMag("---------------Start----------------------");
            ShowMag(mag + ":" + ex.Message);
            ShowMag("---------------End  ----------------------");
        }
        public void ShowMag(string mag)
        {
            textBox2.AppendText(mag + "\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Send();
             // ShowMag(textBox3.Text);
     
            textBox3.Text = "";
        }
        private void Send()
        {

            try
            {
                byte[] by = Encoding.UTF8.GetBytes(label5.Text+":"+textBox3.Text);
                sockConnection.Send(by);
            }
            catch (Exception ex)
            {

                ShowErr("fail to send", ex);
            }
        
        }

      

        private void Receive()
        {
             while (true)
                {
                    try
                    {
             
                        byte[] arrMsgRec = new byte[1024 * 1024 * 2];
                    
                        int length = sockConnection.Receive(arrMsgRec);
                       
                        string strMsgRec = System.Text.Encoding.UTF8.GetString(arrMsgRec, 0, length);
                  
                        ShowMag( strMsgRec);
                    }
                    catch (Exception e)
                    {
                        ShowMag("-----Jéjà deconneté ！-----");
                        sockConnection.Close();
                  
                        Thread.CurrentThread.Abort();
                    }
                }
        }

    }
    
}
