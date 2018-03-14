using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatProject.Authentification
{
    class AuthentificationException : Exception
    {
        protected string message;

        public AuthentificationException(string login)
        {
            this.message = " : Exception par défaut !";
        }

        public void DisplayError()
        {
            Console.Out.WriteLine(base.Message + message);
        }
    }
     
 } 

