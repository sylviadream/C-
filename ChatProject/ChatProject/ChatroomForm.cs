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
using ChatProject.Net;

namespace ChatProject
{
    public partial class ChatroomForm : Form
    {
        public static int RoomNumber = 10000;

        private Dictionary<string, int> roomlist = new Dictionary<string, int>();
        public ChatroomForm(string username)
        {
            InitializeComponent();

            int n = roomlist.Count;
            this.roomlist.Add("web", 9999);
            this.roomlist.Add("UML", 9998);
            foreach (string key in roomlist.Keys)
            {
                comboBox1.Items.Add(key);
              
            }
            label3.Text = username;
        }
             private void NewChatroom(String RoomName) {
                ChatroomForm.RoomNumber = ChatroomForm.RoomNumber + 1;
                this.roomlist.Add(RoomName, ChatroomForm.RoomNumber+10000);
                comboBox1.Items.Add(RoomName);
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            NewChatroom(textBox1.Text);
        }






      /*  private void button3_Click(object sender, EventArgs e)
        {
            int port = roomlist[comboBox1.Text];


            TCPServer serv = new TCPServer();

            serv.StartServer(port, textBox2.Text);
        }
        */
        private void button1_Click(object sender, EventArgs e)
        {
            int port = roomlist[comboBox1.Text];
            FormClient formclient = new FormClient(label3.Text, comboBox1.Text, textBox2.Text, port);
            formclient.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

