using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProject.Authentification
{
    class WrongPassword : AuthentificationException
    {
        public WrongPassword(string login) : base(login)
        {
 
        }
        public string EnvoyerMessage() {
            return " Has provided an invalid password !";
        }
    }
}
