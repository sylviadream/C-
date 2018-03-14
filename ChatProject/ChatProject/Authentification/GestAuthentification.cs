using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace ChatProject.Authentification
{
    [Serializable]
    class GestAuthentification : IAuthentificationManager
    {
        private List<User> users;

        public GestAuthentification()
        {
            this.users = new List<User>();
        }

        public void AddUser(string login, string password)
        {
            foreach (var v in users)
            {
                if (v.Login == login)
                    throw new UserExits(login);
            }
            this.users.Add(new User(login, password));
        }

        public void RemoveUser(string login)
        {
            bool remove = false;

            foreach (var v in users)
            {
                if (v.Login == login)
                {
                    users.Remove(v);
                    remove = true;
                    break;
                }
            }

            if (!remove)
                throw new UserUnknown(login);
        }

        public void Authentify(string login, string password)
        {
            bool find = false;
            foreach(var v in users)
            {
                if (v.Login == login)
                {
                    find = true;
                    if (v.Password != password)
                        throw new WrongPassword(login);
                }
            }
            if (!find)
                throw new UserUnknown(login);
        }

        public void Load(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                this.users = (List<User>)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            }
            fs.Close();
        }

        public void Save(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, users);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
            }
            fs.Close();
        }
    }
}
