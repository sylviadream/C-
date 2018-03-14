using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProject.Authentification
{
    interface IAuthentificationManager
    {
        void AddUser(string login, string password);
        void RemoveUser(string login);
        void Authentify(string login, string password);
        void Load(string path);
        void Save(string path);
    }
}
