using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Drawing;

namespace TCPserver
{
    class ClientsManager
    {
        // Class variables 
        private List<Users> UsersList;
        private List<Users> OnlineUsersList;
        private List<Color> AGVcolors;

        // Constructor
        public ClientsManager()
        {
            UsersList = new List<Users>();
            AGVcolors = new List<Color>() { Color.White, Color.Black, Color.Gray, Color.Green, Color.Red, Color.Blue, Color.Yellow, Color.Orange, Color.Pink, Color.Purple };
            OnlineUsersList = new List<Users>();
            DefaultUsers();
        }

        // New Users methods // Method that inicialize a default list of users
        private void DefaultUsers()
        {
            for (int i = 0; i < 10; i++)
            {
                UsersList.Add(new Users(i, "Us_User" + i.ToString(), "000" + (1 * i).ToString()));
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
            UsersList[id].setTcpClient(null);
            OnlineUsersList.Remove(UsersList[id]);
        }
        private void remmoveUserConection(int id)
        {
            UsersList[id].setTcpClient(null);
            OnlineUsersList.Remove(UsersList[id]);
        }

        // Method that returns a bool is Users log is okay
        public int login(TcpClient client, string name, string password)
        {
            int i = 0;
            bool notFound = true;
            while (notFound && i < UsersList.Count )
            {
                if(UsersList[i].getName() == name)
                {
                    notFound = false;
                    if (UsersList[i].getPassword() == password && UsersList[i].getTcpClient() == null)
                    {
                        UsersList[i].setTcpClient(client); 
                        if(OnlineUsersList.Count <= 10)
                        {
                            OnlineUsersList.Add(UsersList[i]);
                            UsersList[i].setAgvref(AGVcolors[0]);
                            AGVcolors.RemoveAt(0);
                        }
                        else
                        {
                            i = -1;
                        }
                    }
                }
                else
                {
                    i++;
                }
            }
            if(i >= UsersList.Count)
            {   
                i = -1;
            }
            return i;
        }

        // Users accessors //
        // Accessors
        public string getName(int id) { return UsersList[id].getName(); }
        public Color getAgvref(int id) { return UsersList[id].getAgvref(); }
        public string getPassword(int id) { return UsersList[id].getPassword(); }
        public TcpClient getTcpClient(int id) { return UsersList[id].getTcpClient(); }

        public bool getOnline(int id) { return OnlineUsersList.Contains(UsersList[id]); }
    }
}