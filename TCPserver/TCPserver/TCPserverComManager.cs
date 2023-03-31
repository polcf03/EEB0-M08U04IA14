using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

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

        // Delegates
        public event EventHandler<ErrorEventArgs> UnexpectedComError;
        public event EventHandler<CommandEventArgs> CommandToExecute;
        public event EventHandler<DisconnectEventArgs> Disconnect;

        // Constructor
        public TCPServerComManager()
        {
            myIp = IPAddress.Loopback;
            myPort = 1;
            //UsersList = new List<Users>();
            //defaultUsers();
        }

        // Server startup methods
        public void startServer()
        {
            server = new TcpListener(myIp, myPort);
            server.Start();
            ThreadPool.QueueUserWorkItem(newClient);
        }
        public void stopServer() { server.Stop();}
        private void newClient(Object state)
        {
            string txt, log;
            TcpClient client;
            NetworkStream nsToRead;

            client = new TcpClient();

            try
            {
                int i = 0;
                client = server.AcceptTcpClient();

                ThreadPool.QueueUserWorkItem(newClient);

                    ReadCommands(client);
                    log = login(client, myFrameManager.getArg1(), myFrameManager.getArg2());

                    if (log != null)
                    {
                        WriteCommandsToClient(client, "LOG", "WR", log, "");
                    }
                    else
                    {
                        Users user;

                        user = myClientsManager.getUserFromOnlineUsers(myClientsManager.getIndexOnlineUsersByClient(client));

                        WriteCommandsToClient(client, "LOG", "OK", "", "");
                        riseCommand("SPWN", user.getAgvId());

                        while (myClientsManager.UserInOnlineUsers(user))
                        {
                            byte[] toReceive = new byte[100000];
                            nsToRead = client.GetStream();
                            nsToRead.Read(toReceive, 0, toReceive.Length);
                            txt = Encoding.ASCII.GetString(toReceive);
                            ReadFromClient(user, txt);
                        }
                    }

            }
            catch (Exception ex)
            {
                riseUnexpectedComError(ex.Message);
            }
        }
        private string login(TcpClient client, string name, string password)
        {
            bool notFound;
            int OnlineMax, UsersSize, OnlineUsersSize, i;
            string log = "";

            OnlineMax = 10;
            i = 0;
            UsersSize = myClientsManager.getUsersSize();
            OnlineUsersSize = myClientsManager.getOnlineUsersSize();
            notFound = true;
            log = "That Name is not registered";

            if (OnlineMax > OnlineUsersSize)
            {
                while (notFound && i < UsersSize)
                {
                    if (myClientsManager.getUsersName(i) == name)
                    {
                        notFound = false;
                        if (myClientsManager.getUsersTcpclient(i) == null && myClientsManager.getUsersPassword(i) == password)
                        {
                            myClientsManager.setUsersClient(i, client);
                            myClientsManager.setUsersAgvId(i, myClientsManager.takeAgvFromAgvList());
                            myClientsManager.AddUserInOnlineUsers(myClientsManager.getUsersFromUsers(i));
                            log = null;
                        }
                        else
                        {
                            log = "The password is incorrect";
                        }
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            else
            {
                log = "The Game is full";
            }
            return log;

        }

        // Methods
        private void WriteCommandsToClient(TcpClient client, string Command, string Arg1, string Arg2, string Arg3)
        {
            NetworkStream nsToWrite;
            string txt;
            txt = myFrameManager.Order(Command, Arg1, Arg2, Arg3);
            try
            {
                nsToWrite = client.GetStream();
                nsToWrite.Write(Encoding.ASCII.GetBytes(txt), 0, txt.Length);
            }
            catch (Exception ex)
            {
                riseUnexpectedComError(ex.Message);
            }
        }
        private void ReadCommands(TcpClient client)
        {
            NetworkStream nsToRead;
            string txt;
            byte[] received = new byte[100000];
            nsToRead = client.GetStream();
            nsToRead.Read(received, 0, received.Length);
            txt = Encoding.ASCII.GetString(received);
            myFrameManager.Frame(txt);
        }

        private void ReadFromClient(Users user ,string txt)
        {
            myFrameManager.Frame(txt);
            Orders(user ,myFrameManager.getCommand(), myFrameManager.getArg1(), myFrameManager.getArg2(), myFrameManager.getArg3());
        }
        private void Orders(Users user,string Command, string Arg1, string Arg2, string Arg3)
        {
            string txt = "";
            int Agvref = user.getAgvId();
            switch (Command)
            {
                case "MOV":
                    switch (Arg1)
                    {
                        case "RIG":
                            txt = "RIG";
                            break;
                        case "LEF":
                             txt = "LEFT";
                            break;
                        case "UP":
                            txt = "UP";
                            break;
                        case "DOWN":
                            txt = "DOWN";
                            break;
                        case "RT":
                            if (Arg2 == "RIG")
                            {
                                txt = "ROTATERIG";
                            }
                            else
                            {
                                txt = "ROTATELEF";
                            }
                            break;
                        case "FOR":
                            txt = "FORWARD";
                            break;
                        case "BACK":
                            txt = "BACKWARD";
                            break;

                    }
                break;
                case "BRK":
                    txt = "BREAK";
                    break;
                case "DISC":
                    txt = "DISC";
                    myClientsManager.RemoveUserFromOnlineUsers(user);
                    myClientsManager.leaveAgvToAgvList(Agvref);
                    myClientsManager.setUsersClient(myClientsManager.getIndexUsersByAgvId(Agvref), null);
                    break;
                    
            }
            riseCommand(txt, Agvref);
        }

        public void disconectAll()
        {
            int i = 0;
            List<Users> Onlinelist = new List<Users>();
            int size = myClientsManager.getOnlineUsersSize();
            while ( i < size)
            {
                Onlinelist.Add(myClientsManager.getUserFromOnlineUsers(i));
                i++;
            }
            foreach(Users user in Onlinelist)
            {
                WriteCommandsToClient(user.getTcpClient(), "DISC", "", "", "");
            }
        }


        // Events
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
            EventHandler<CommandEventArgs> handler = CommandToExecute;
            if (handler != null)
            {
                handler(this, e);
            }
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
    }
}
