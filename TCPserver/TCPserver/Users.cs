using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Drawing;

namespace TCPserver
{
    class Users
    {
        // class variables;
        private int id;
        private string name;
        private int agvId;
        private string password;
        private TcpClient tcpClient;

        // Construtores
        public Users()
        {
            id = 0;
            name = "";
            password = "";
        }
        public Users(int Id, string Name, string Password)
        {
            id = Id;
            name = Name;
            password = Password;
        }


        // Global Modifier
        public void setUser(int Id, string User, string Password, bool state)
        {
            id = Id;
            name = User;
            password = Password;
        }

        // Accessors
        public void setId(int a) { id = a; }
        public void setName(string str) { name = str; }
        public void setAgvId(int a) { agvId = a; }
        public void setPassword(string str) { password = str; }
        public void setTcpClient(TcpClient Client) { tcpClient = Client; }

        // Modifiers
        public int getId() { return id; }
        public string getName() { return name; }
        public int getAgvId() { return agvId; }
        public string getPassword() { return password; }
        public TcpClient getTcpClient() { return tcpClient; }
        
    }
}
