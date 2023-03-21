using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        // Method that inicialize a default list of users
        private void defaultUsers()
        {
            for (int i = 1; i <= 10; i++)
            {
                UsersList.Add(new Users(i, "User" + i.ToString(), "000" + (1 * i).ToString()));
            }
        }

        // Method that returns a bool is Users log is okay
        private bool login(string name, string password)
        {
            int i = 0;
            bool Pass = false;
            while (i <= UsersList.Count() - 1)
            {
                if (UsersList[i].getName() == name && UsersList[i].getPassword() == password)
                {
                    Pass = true;
                }
            }
            return Pass;
        }
    }
}
