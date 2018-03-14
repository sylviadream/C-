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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please entre your name！");
                textBox1.Focus();
                return;
            }

            IAuthentificationManager am = new GestAuthentification();
            am.Load("users.txt");

            try
            {        
                am.Authentify(textBox1.Text, textBox2.Text);
                Form chatroomForm = new ChatroomForm(textBox1.Text);

                chatroomForm.Show();
                this.Hide();

            }
            catch (WrongPassword err) { MessageBox.Show(err.EnvoyerMessage());  }
            catch (UserUnknown err) { MessageBox.Show(err.EnvoyerMessage()); }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form gestionuser = new GestionUser();
            gestionuser.Show();
            this.Hide();
        }
    }
    }

