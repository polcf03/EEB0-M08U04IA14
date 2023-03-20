using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace TCPserver
{
    class Users
    {
        // class variables;
        private int id;
        private string name;
        private string agvref;
        private string password;
        private bool online;
        private TcpClient tcpClient;

        // Construtores
        public Users()
        {
            id = 0;
            name = "";
            agvref = "";
            password = "";
            online = false;
        }
        public Users(int Id, string User,  string Password)
        {
            id = Id;
            name = User;
            agvref = "";
            password = Password;
            online = false;
        }

        // Global Modifier
        public void setUser(int Id, string User, string strref, string Password, bool state)
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
        public void setPassword(string str) { password = str; }
        public void setOnline(bool ste) { online = ste; }
        public void setTcpClient(TcpClient Client) { tcpClient = Client; }

        // Modifiers
        public int getId() { return id; }
        public string getName() { return name; }
        public string getAgvref() { return agvref; }
        public string getPassword() { return password; }
        public bool getOnline() { return online; }
        public TcpClient getTcpClient() { return tcpClient; }
        
    }
}
