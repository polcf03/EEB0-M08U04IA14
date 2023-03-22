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

        // Objects
        private FrameManager myFrameManager = new FrameManager();
        private ClientsManager myClientsManager = new ClientsManager();

        // Eventos
        public event EventHandler<ErrorEventArgs> UnexpectedComError;
        public event EventHandler<CommandEventArgs> Command;

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

            string txt;
            TcpClient client;
            NetworkStream nsToRead;
            NetworkStream nsToWrite;
            client = new TcpClient();
            try
            {
                client = server.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(newClient);
                bool UserLogged = login(client);
                while (UserLogged)
                {
                    // Read
                    byte[] toReceive = new byte[100000];
                    nsToRead = client.GetStream();
                    nsToRead.Read(toReceive, 0, toReceive.Length);
                    txt = Encoding.ASCII.GetString(toReceive);

                    // Process
                    myFrameManager.Frame(txt);
                    riseCommand(Orders());

                    //Write

                }
            }
            catch (Exception ex)
            {
                riseUnexpectedComError(ex.Message); 
            }
        }

        // Orders
        private void Orders()
        {
            string Command = myFrameManager.getCommand();
            string Arg1 = myFrameManager.getArg1();
            string Arg2 = myFrameManager.getArg2();
            string Arg3 = myFrameManager.getArg3();

            switch (Command)
            {
                //case Arg1 == "MOV"
            }
        }
        private bool login(TcpClient client)
        {
            NetworkStream nsToWrite;
            NetworkStream nsToRead;
            string txt = myFrameManager.Order("LOG", "", "", "");
            nsToWrite = client.GetStream();
            nsToWrite.Write(Encoding.ASCII.GetBytes(txt), 0, txt.Length);
            byte[] txt2 = new byte[100000];
            nsToRead = client.GetStream();
            nsToRead.Read(txt2, 0, txt2.Length);
            txt = Encoding.ASCII.GetString(txt2);
            myFrameManager.Frame(txt);
            return myClientsManager.login(client,myFrameManager.getArg1(), myFrameManager.getArg2());
        }

        // Event caller
        private void riseUnexpectedComError(string txtError)
        {
            ErrorEventArgs args = new ErrorEventArgs();
            args.message = txtError;
            onUnexpectedComError(args);
        }
        private void riseCommand(string txtCommand)
        {
            CommandEventArgs args = new CommandEventArgs();
            args.Command = txtCommand;
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
            if (handler != null)
            {
                handler(this, e);
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
