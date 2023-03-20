using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCPserver
{
    internal class UsersManager
    {
        // Class variables
        private List<Users> UsersList;

        // Constructors
        public UsersManager()
        {
            UsersList = new List<Users>();
            default_users();
        }

        // Method that inicialize a default list of users
        private void default_users()
        {
            for(int i = 1; i <= 10; i++)
            {
                UsersList.Add(new Users(i, "User" + i.ToString(), 0000 + 1 * i));
            }
        }
        // Methods
        public void AddNewUsers(string name, int password)
        {
            new Users(listOfUsers.Count() + 1, name, password);
        }
        
        // Accessors
        public string getName(int id) { return UsersList[id].getName(); }
        public string getAgvref(int id) { return UsersList[id].getAgvref(); }
        public int getPassword(int id) { return UsersList[id].getPassword(); }
        public bool getOnline(int id) { return UsersList[id].getOnline(); }

        // Modifiers
        public void setName(string str) { name = str; }
        public void setAgvref(string str) { agvref = str; }
        public void setPassword(int a) { password = a; }
        public void setOnline(bool ste) { online = ste; }
        
    }
}
