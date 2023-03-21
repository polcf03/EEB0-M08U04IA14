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
        //private List<Users> UsersList;

        // Objects
        private FrameManager myFrameManager = new FrameManager();
        
        // Eventos
        public event EventHandler<ErrorEventArgs> UnexpectedComError;

        // Constructor
        public TCPServerComManager()
        {
            myIp = IPAddress.Loopback;
            myPort = 1;
            //UsersList = new List<Users>();
            //defaultUsers();
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
            string txt,txt2;
            TcpClient client;
            NetworkStream nsToRead;
            NetworkStream nsToWrite;
            client = new TcpClient();
            try
            {
                client = server.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(newClient);
                txt = myFrameManager.Order("LOG","","","");
                nsToWrite = client.GetStream();
                nsToWrite.Write(Encoding.ASCII.GetBytes(txt), 0, txt.Length);
                nsToRead = client.GetStream();

                while (true)
                {
                    byte[] toReceive = new byte[100000];
                    
                    nsToRead.Read(toReceive, 0, toReceive.Length);
                    txt = Encoding.ASCII.GetString(toReceive);
                    myFrameManager.Frame(txt);
                }
            }
            catch (Exception ex)
            {
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
    }
}
