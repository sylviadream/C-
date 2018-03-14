using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProject.Authentification
{
    class UserUnknown : AuthentificationException
    {
        public UserUnknown(string login) : base(login)
        {
        
        }

        public string EnvoyerMessage()
        {
            return " user unknown !";
        }

    }
}
