using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProject.Authentification
{
    class UserExits : AuthentificationException
    {
        public UserExits(string login) : base(login)
        {
            this.message = " has already been added !";
        }
    }
}
