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
        private List<TcpClient> listOfClients;

        // Objects
        private FrameManager myFrameManager = new FrameManager();
        private UsersManager myUsersManager = new UsersManager();
        
        // Eventos
        public event EventHandler<ErrorEventArgs> UnexpectedComError;
        public event EventHandler<DataReceivedEventArgs> DataReceived;

        // Constructor
        public TCPServerComManager()
        {
            myIp = IPAddress.Loopback;
            myPort = 1;
            listOfClients = new List<TcpClient>();
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
                listOfClients.Add(client);
                ThreadPool.QueueUserWorkItem(newClient);
                while (true)
                {
                    byte[] toReceive = new byte[100000];
                    nsToRead = client.GetStream();
                    nsToRead.Read(toReceive, 0, toReceive.Length);
                    txt = Encoding.ASCII.GetString(toReceive);
                    myFrameManager.Frame(txt);

                    // riseDataReceive(txt);
                    foreach (TcpClient clientListed in listOfClients)
                    {
                        if (clientListed == client)
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

        // 
        private void riseUnexpectedComError(string txtError)
        {
            ErrorEventArgs args = new ErrorEventArgs();
            args.message = txtError;
            onUnexpectedComError(args);
        }
        private void riseDataReceive(string infoReceived)
        {
            DataReceivedEventArgs args = new DataReceivedEventArgs();
            args.txtReceived = infoReceived;
            onDataReceived(args);
        }

        // Event launcher
        private void onDataReceived(DataReceivedEventArgs e)
        {
            EventHandler<DataReceivedEventArgs> handler = DataReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }
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
