using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace TCPserver
{
    class TCPServerComManager
    {
        // Class variables    
        private IPAddress myIp;
        private int myPort;
        private TcpListener server;

        // Objects
        private FrameManager myFrameManager = new FrameManager();
        private ClientsManager myClientsManager = new ClientsManager();

        // Eventos
        public event EventHandler<ErrorEventArgs> UnexpectedComError;
        public event EventHandler<CommandEventArgs> Command;
        public event EventHandler<CommandEventArgs> Agv;

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

        // Methods // Server startup
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
            client = new TcpClient();
            try
            {
                client = server.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(newClient);
                int i = login(client);
                if(i >= 0)
                {

                }
                while(myClientsManager.getOnline(i))
                {
                    // Read
                    byte[] toReceive = new byte[100000];
                    nsToRead = client.GetStream();
                    nsToRead.Read(toReceive, 0, toReceive.Length);
                    txt = Encoding.ASCII.GetString(toReceive);

                    // Process
                    ReadFromClient(txt);

                }
            }
            catch (Exception ex)
            {

            }
        }

        // Methods // Read orders
        private int login(TcpClient client)
        {
            NetworkStream nsToRead;
            string txt; 
            byte[] received = new byte[100000];
            nsToRead = client.GetStream();
            nsToRead.Read(received, 0, received.Length);
            txt = Encoding.ASCII.GetString(received); 
            myFrameManager.Frame(txt);
            return myClientsManager.login(client, myFrameManager.getArg1(), myFrameManager.getArg2());
        }
        private string ReadFromClient(string txt)
        {
            myFrameManager.Frame(txt);
            return Orders(myFrameManager.getCommand(), myFrameManager.getArg1(), myFrameManager.getArg2(), myFrameManager.getArg3());
        }
        private string Orders(string Command, string Arg1, string Arg2, string Arg3)
        {
            string txt = ""
                ; 
            switch (Command)
            {
                //case Arg1 == "MOV"
                
            }
            return txt;
        }

        // Event caller
        private void riseUnexpectedComError(string txtError)
        {
            ErrorEventArgs args = new ErrorEventArgs();
            args.message = txtError;
            onUnexpectedComError(args);
        }
        private void riseCommand(string txtCommand, int Agv)
        {
            CommandEventArgs args = new CommandEventArgs();
            args.Command = txtCommand;
            args.AGVrequested = Agv;
            onCommand(args);
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
        private void onCommand(CommandEventArgs e)
        {
            EventHandler<CommandEventArgs> handler = Command;
            EventHandler<CommandEventArgs> handler2 = Agv;
            if (handler != null && handler2 != null)
            {
                handler(this, e);
                handler2(this, e);
            }
        }
    }
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
