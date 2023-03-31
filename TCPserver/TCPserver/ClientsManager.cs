using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Drawing;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;

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

        // Class methods
        private void DefaultUsers()
        {
            for (int i = 0; i < 10; i++)
            {
                UsersList.Add(new Users(i, "Us_User" + i.ToString(), "000" + (1 * i).ToString()));
            }
        }
        private void newUser(string name,string password)
        {
            UsersList.Add(new Users(UsersList.Count,"Us_"+ name, password));
        }      
       
        // Methods
        public bool UserInOnlineUsers(Users user)
        {
            return OnlineUsersList.Contains(user);
        }
        public bool UserInUsersusers(Users user)
        {
            return UsersList.Contains(user);
        }

        // AgvRefs methods
        public int takeAgvFromAgvList()
        {
            int Ref;
            Ref = AgvRefs[0];
            AgvRefs.RemoveAt(0);
            return Ref;
        } 
        public void leaveAgvToAgvList(int Ref)
        {
            AgvRefs.Add(Ref);
        }



        // List accessors
        public Users getUserFromOnlineUsers(int index)
        {
            return OnlineUsersList[index];
        }
        public Users getUsersFromUsers(int index)
        {
            return UsersList[index];
        }
        public int getUsersSize()
        {
            return UsersList.Count();
        }
        public int getOnlineUsersSize()
        {
            return OnlineUsersList.Count;
        }
        public List<Users> getOnlineUsersList()
        {
            return OnlineUsersList;
        }
        // List modifiers
        public void AddUserInOnlineUsers(Users user)
        {
            OnlineUsersList.Add(user);
        }
        private void AddUserInUsers(Users user)
        {
            UsersList.Add(user);
        }
        public void RemoveUserFromOnlineUsers(Users user)
        {
            OnlineUsersList.Remove(user);
        }
        public void RemoveUserFromUsers(Users user)
        {
            UsersList.Remove(user);
        }


        // Online users accessors
        public int getOnlineUsersId(int index) 
        { 
            return OnlineUsersList[index].getId(); 
        }
        public string getOnlineUsersName(int index)
        {
            return OnlineUsersList[index].getName();
        }
        public int getOnlineUsersAgvId(int index)
        {
            return OnlineUsersList[index].getAgvId();
        }
        public string getOnlineUsersPassword(int index)
        {
            return OnlineUsersList[index].getPassword();
        }
        public TcpClient getOnlineUsersClient(int index)
        {
            return OnlineUsersList[index].getTcpClient();
        }
        // Users accessors 
        public int getUsersId(int index)
        {
            return UsersList[index].getId();
        }
        public string getUsersName(int index)
        {
            return UsersList[index].getName();
        }
        public int getUsersAgvId(int index)
        {
            return UsersList[index].getAgvId();
        }
        public string getUsersPassword(int index)
        {
            return UsersList[index].getPassword();
        }
        public TcpClient getUsersTcpclient(int index)
        {
            return UsersList[index].getTcpClient();
        }
        

        // Online users modifiers
        public void setOnlineUsersId(int index, int id)
        {
            OnlineUsersList[index].setId(id);
        }
        public void setOnlineUsersName(int index, string name)
        {
            OnlineUsersList[index].setName(name);
        }
        public void setOnlineUsersAgvId(int index, int Agvref)
        {
            OnlineUsersList[index].setAgvId(Agvref);
        }
        public void setOnlineUsersPassword(int index, string password)
        {
            OnlineUsersList[index].setPassword(password);
        }
        public void setOnlineUsersClient(int index, TcpClient client)
        {
            OnlineUsersList[index].setTcpClient(client);
        }
        // Users modifiers
        public void setUsersId(int index, int id)
        {
            UsersList[index].setId(id);
        }
        public void setUsersName(int index, string name)
        {
            UsersList[index].setName(name);
        }
        public void setUsersAgvId(int index, int Agvref)
        {
            UsersList[index].setAgvId(Agvref);
        }
        public void setUsersPassword(int index, string password)
        {
            UsersList[index].setPassword(password);
        }
        public void setUsersClient(int index, TcpClient client)
        {
            UsersList[index].setTcpClient(client);
        }
        

        // Online users list INDEX accessors
        public int getIndexOnlineUsersById(int id)
        {
            int i = 0;
            bool notFound = true;
            while (notFound && i < OnlineUsersList.Count)
            {
                if (OnlineUsersList[i].getId() == id)
                {
                    notFound = false;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }
        public int getIndexOnlineUsersByName(string name)
        {
            int i = 0;
            bool notFound = true;
            while (notFound && i < OnlineUsersList.Count)
            {
                if (OnlineUsersList[i].getName() == name)
                {
                    notFound = false;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }
        public int getIndexOnlineUsersByAgvId(int Agvref) 
        {
            int i = 0;
            bool notFound = true;
            while (notFound && i < OnlineUsersList.Count)
            {
                if (OnlineUsersList[i].getAgvId() == Agvref)
                {
                    notFound = false;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }
        public int getIndexOnlineUsersByPassword(string password)
        {
            int i = 0;
            bool notFound = true;
            while (notFound && i < OnlineUsersList.Count)
            {
                if (OnlineUsersList[i].getPassword() == password)
                {
                    notFound = false;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }
        public int getIndexOnlineUsersByClient(TcpClient client)
        {
            int i = 0;
            bool notFound = true;
            while (notFound && i < OnlineUsersList.Count)
            {
                if (OnlineUsersList[i].getTcpClient() == client)
                {
                    notFound = false;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }
        // Users list INDEX accessors
        public int getIndexUsersById(int id)
        {
            int i = 0;
            bool notFound = true;
            while (notFound && i < UsersList.Count)
            {
                if (UsersList[i].getId() == id)
                {
                    notFound = false;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }
        public int getIndexUsersByName(string name)
        {
            int i = 0;
            bool notFound = true;
            while (notFound && i < UsersList.Count)
            {
                if (UsersList[i].getName() == name)
                {
                    notFound = false;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }
        public int getIndexUsersByAgvId(int Agvref)
        {
            int i = 0;
            bool notFound = true;
            while (notFound && i < UsersList.Count)
            {
                if (UsersList[i].getAgvId() == Agvref)
                {
                    notFound = false;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }
        public int getIndexUsersByPassword(string password)
        {
            int i = 0;
            bool notFound = true;
            while (notFound && i < UsersList.Count)
            {
                if (UsersList[i].getPassword() == password)
                {
                    notFound = false;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }
        public int getIndexUsersByClient(TcpClient client)
        {
            int i = 0;
            bool notFound = true;
            while (notFound && i < UsersList.Count)
            {
                if (UsersList[i].getTcpClient() == client)
                {
                    notFound = false;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }

    }
}