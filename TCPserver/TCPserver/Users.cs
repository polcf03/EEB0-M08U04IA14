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
        private int id;
        private string name;
        private string agvref;
        private int password;
        private bool online;

        // Construtores
        public Users()
        {
            id = 0;
            name = "";
            agvref = "";
            password = 0;
            online = false;
        }
        public Users(int Id, string User, string strref, int Password, bool onlineuser)
        {
            id = Id;
            name = User;
            agvref = strref;
            password = Password;
            online = onlineuser;
        }
        public Users(int Id, string User,  int Password)
        {
            id = Id;
            name = User;
            agvref = "";
            password = Password;
            online = false;
        }

        // Modifier
        public void setUser(int Id, string User, string strref, int Password, bool state)
        {
            id = Id;
            name = User;
            agvref = strref;
            password = Password;
            online = state;
        }

        // Accessors
        public void setId(int a) { id = a; }
        public void setName(string str) { name = str; }
        public void setAgvref(string str) { agvref = str; }
        public void setPassword(int a) { password = a; }
        public void setOnline(bool ste) { online = ste; }

        // Modifiers
        public int getId() { return id; }
        public string getName() { return name; }
        public string getAgvref() { return agvref; }
        public int getPassword() { return password; }
        public bool getOnline() { return online; }
        
    }
}
