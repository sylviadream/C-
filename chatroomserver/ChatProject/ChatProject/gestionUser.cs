using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatProject.Authentification;

namespace ChatProject
{
    public partial class GestionUser : Form
    {
        public GestionUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestAuthentification gesAu = new GestAuthentification();

            try
            {
                gesAu.Load("users.txt");
                gesAu.AddUser(textBox1.Text, textBox2.Text);
                gesAu.Save("users.txt");
            }
            catch (WrongPassword err) { MessageBox.Show(err.EnvoyerMessage()); }
            catch (UserUnknown err) { MessageBox.Show(err.EnvoyerMessage()); }

            Form chatroom = new ChatroomForm(textBox1.Text);
            chatroom.Show();
            this.Hide();
        }
    }
}
