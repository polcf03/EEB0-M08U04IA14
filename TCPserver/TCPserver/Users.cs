using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPserver
{
    class Users
    {
        // class variables;
        private int UserNum;
        private string UserName;
        private int UserPassword;

        // Construtores
        public Users()
        {
            UserNum = 0;
            UserName = "";
            UserPassword = 0;
        }

        // Set User
        public void User(int num, string User, int Password)
        {
            UserNum = num;
            UserName = User;
            UserPassword = Password;
        }

        // Reset
        public void User()
        {
            UserNum = 0;
            UserName = "";
            UserPassword = 0;
        }


    }
}
