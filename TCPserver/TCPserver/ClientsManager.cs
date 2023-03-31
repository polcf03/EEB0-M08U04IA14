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
        public List<int> AgvRefs;

        // Constructor
        public ClientsManager()
        {
            UsersList = new List<Users>();
            OnlineUsersList = new List<Users>();
            AgvRefs= new List<int>() {1,2,3,4,5,6,7,8,9,10};
            DefaultUsers();
        }

        // New Users methods // Method that inicialize a default list of users
        private void DefaultUsers()
        {
            for (int i = 0; i < 11; i++)
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
        public void remmoveUserConection(int id)
        {
            UsersList[id].setTcpClient(null);
            OnlineUsersList.Remove(UsersList[id]);
            AgvRefs.Add(UsersList[id].getAgvId());
            UsersList[id].setAgvId(0);
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
                        OnlineUsersList.Add(UsersList[i]);
                        UsersList[i].setAgvId(AgvRefs[0]);
                        AgvRefs.RemoveAt(0);                        
                    }
                    else
                    {
                        i = -1;
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
        public string getPassword(int id) { return UsersList[id].getPassword(); }
        public TcpClient getTcpClient(int id) { return UsersList[id].getTcpClient(); }
        public int getAgvId(int id) { return UsersList[id].getAgvId(); }

        public bool getOnline(int id) { return OnlineUsersList.Contains(UsersList[id]); }
        public void removeallplayers()
        {
            while(OnlineUsersList.Count != 0)
            {
                OnlineUsersList[0].setTcpClient(null);
                AgvRefs.Add(OnlineUsersList[0].getAgvId());
                OnlineUsersList[0].setAgvId(0);
                OnlineUsersList.Remove(OnlineUsersList[0]);
            }
        }
        public void removeoneplayer(int id)
        {

            UsersList[id].setTcpClient(null);
            AgvRefs.Add(UsersList[id].getAgvId());
            UsersList[id].setAgvId(0);  
            OnlineUsersList.Remove(UsersList[1]);
        }
        public List<Users> getOnlineUsers()
        {
            return OnlineUsersList;
        }
    }
}