using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPserver
{
    class Users
    {
        private int UserNum;
        private string UserName;
        private int UserPassword;

        public Users()
        {
            UserNum = 0;
            UserName = "";
            UserPassword = 0;
        }
        public Users(int num, string User, int Password)
        {
            UserNum = num;
            UserName = User;
            UserPassword = Password;
        }
    }
}
