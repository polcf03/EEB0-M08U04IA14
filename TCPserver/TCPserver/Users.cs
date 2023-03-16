using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TCPserver
{
    class Users
    {
        // class variables;
        private int userId;
        private string userName;
        private int agvId;
        private int userPassword;
        private bool online;

        // Construtores
        public Users()
        {
            userId = 0;
            userName = "";
            agvId = 0;
            userPassword = 0;
            online = false;
        }
        public Users(int num, string User, int id, int Password, bool onlineuser)
        {
            userId = num;
            userName = User;
            agvId = id;
            userPassword = Password;
            online = onlineuser;
        }

        // Modifier
        public void setUser(int a , string str, int b, int c, bool state)
        {
            userId = a;
            userName = str;
            agvId = b;
            userPassword = c;
            online = state;
        }

        // Accessors and modifier
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int AgvId { get; set; }
        public int UserPassword { get; set; }
        public bool Online { get; set; }
        
    }
}
