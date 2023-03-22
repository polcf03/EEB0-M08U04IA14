using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace TCPserver
{
    class ClientsManager
    {
        // Class variables 
        private List<Users> UsersList;

        // Constructor
        public ClientsManager()
        {
            UsersList = new List<Users>();
        }

        // New Users methods //
        // Method that inicialize a default list of users
        private void defaultUsers()
        {
            for (int i = 1; i <= 10; i++)
            {
                UsersList.Add(new Users(i, "User" + i.ToString(), "000" + (1 * i).ToString()));
            }
        }
        // New user
        private void newUser(string name,string password)
        {
            UsersList.Add(new Users(UsersList.Count,"Us_"+ name, password));
        }

        // Methods that removes account or conexion from account
        private void removeAccount(int id)
        {
            UsersList.RemoveAt(id);
        }
        private void remmoveUserConection(int id)
        {
            UsersList[id].setTcpClient(null);
            UsersList[id].setOnline(false);
        }

        // Method that returns a bool is Users log is okay
        public bool login(TcpClient client, string name, string password)
        {
            int i = 0;
            bool Pass = false;
            while (i <= UsersList.Count() - 1 && UsersList[i].getName() != name && UsersList[i].getPassword() != password)
            {
                if (UsersList[i].getTcpClient() != client && UsersList[i].getName() == name && UsersList[i].getPassword() == password)
                {
                    Pass = true;
                }
            }
            UsersList[i].setOnline(true);
            return Pass;
        }

        // Users accessors //
        // Accessors
        public string getName(int id) { return UsersList[id].getName(); }
        public string getAgvref(int id) { return UsersList[id].getAgvref(); }
        public string getPassword(int id) { return UsersList[id].getPassword(); }
        public bool getOnline(int id) { return UsersList[id].getOnline(); }
        public TcpClient getTcpClient(int id) { return UsersList[id].getTcpClient(); }
    }
}
