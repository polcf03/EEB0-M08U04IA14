using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPserver
{
    class TCPServerComManager
    {
        // Class variables    
        private IPAddress myIp;
        private int myPort;
        private TcpListener server;
        private List<Users> UsersList;
        private bool firstCom;

        // Objects
        private FrameManager myFrameManager = new FrameManager();
        
        // Eventos
        public event EventHandler<ErrorEventArgs> UnexpectedComError;

        // Constructor
        public TCPServerComManager()
        {
            myIp = IPAddress.Loopback;
            myPort = 1;
            UsersList = new List<Users>();
            firstCom = true;
            defaultUsers();
        }

        // Modifier
        public void setIP(IPAddress ip)
        {
            myIp = ip;
        }
        public void setPort(int port)
        {
            myPort = port;
        }

        // Accessor
        public IPAddress getIP()
        {
            return myIp;
        }
        public int getPort()
        {
            return myPort;
        }

        // Server startup
        public void startServer()
        {
            server = new TcpListener(myIp, myPort);
            server.Start();
            ThreadPool.QueueUserWorkItem(newClient);
        }
        private void newClient(Object state)
        {
            string txt;
            TcpClient client;
            NetworkStream nsToRead;
            NetworkStream nsToWrite;
            client = new TcpClient();

            try
            {
                client = server.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(newClient);
                while (true)
                {
                    byte[] toReceive = new byte[100000];
                    nsToRead = client.GetStream();
                    nsToRead.Read(toReceive, 0, toReceive.Length);
                    txt = Encoding.ASCII.GetString(toReceive);
                    myFrameManager.Frame(txt);
                    int i = login();
                    if (firstCom && i >= 0 && UsersList[i].getTcpClient() != client)
                    {
                        UsersList[i].setTcpClient(client);
                    }
                }
            }
            catch (Exception ex)
            {
                if (UsersList.Contains(client))
                {
                    listOfClients.Remove(client);
                }
                riseUnexpectedComError(ex.Message);
            }
            /*
            string txt;
            TcpClient client;
            NetworkStream nsToRead;
            NetworkStream nsToWrite;
            client = new TcpClient();

            try
            {
                client = server.AcceptTcpClient();
                listOfClients.Add(client);
                ThreadPool.QueueUserWorkItem(newClient);
                while (true)
                {
                    byte[] toReceive = new byte[100000];
                    nsToRead = client.GetStream();
                    nsToRead.Read(toReceive, 0, toReceive.Length);
                    txt = Encoding.ASCII.GetString(toReceive);
                    riseDataReceive(txt);
                    foreach (TcpClient clientListed in listOfClients)
                    {
                        if (clientListed != client)
                        {
                            nsToWrite = clientListed.GetStream();
                            nsToWrite.Write(Encoding.ASCII.GetBytes(txt), 0, txt.Length);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (listOfClients.Contains(client))
                {
                    listOfClients.Remove(client);
                }
                riseUnexpectedComError(ex.Message);
            } 
            */
        }

        // Event caller
        private void riseUnexpectedComError(string txtError)
        {
            ErrorEventArgs args = new ErrorEventArgs();
            args.message = txtError;
            onUnexpectedComError(args);
        }

        // Event launcher
        private void onUnexpectedComError(ErrorEventArgs e)
        {
            EventHandler<ErrorEventArgs> handler = UnexpectedComError;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        // Method that inicialize a default list of users
        private void defaultUsers()
        {
            for (int i = 1; i <= 10; i++)
            {
                UsersList.Add(new Users(i, "User" + i.ToString(), 0000 + 1 * i));
            }
        }
        private int login()
        {
            for(int i = 0; i <= UsersList.Count() - 1; i++)
            {
                if(UsersList[i].getName() != myFrameManager.getArg1() && UsersList[i].getPassword() != myFrameManager.getArg2())
                {
                    return i;
                }
                else { return -1; }
            }
            return -1;
        }
    }
}
