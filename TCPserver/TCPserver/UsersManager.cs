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
        private List<Users> listOfUsers;

        // Constructors
        public UsersManager()
        {
            listOfUsers = new List<Users>();
            default_users();
        }






        // Method that inicialize a default list of users
        private void default_users()
        {
            for(int i = 0; i < 10; i++)
            {
                listOfUsers.Add(new Users(i,"User" + i.ToString(), 0000 + 1 * i));
            }
        }
    }
}
