using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.ExceptionServices;

namespace TCPserver
{
    class TCPServerComManager
    {
        // Class variables    
        private IPAddress myIp;
        private int myPort;
        private TcpListener server;
        private bool Disc;
        private bool DiscAll;

        // Objects
        private FrameManager myFrameManager = new FrameManager();
        private ClientsManager myClientsManager = new ClientsManager();
        private List<TcpClient> clientslist = new List<TcpClient>();

        // Delegates
        public event EventHandler<ErrorEventArgs> UnexpectedComError;
        public event EventHandler<CommandEventArgs> CommandToExecute;
        public event EventHandler<DisconnectEventArgs> Disconnect;

        // Constructor
        public TCPServerComManager()
        {
            myIp = IPAddress.Loopback;
            myPort = 1;
            Disc = false; 
            DiscAll= false;
        }

        // Server startup methods
        public void startServer()
        {
            server = new TcpListener(myIp, myPort);
            server.Start();
            ThreadPool.QueueUserWorkItem(newClient);
            Disc = false;
        }
        public void stopServer() { Disc = true; server.Stop(); }
        private void newClient(Object state)
        {
            string txt, log;
            TcpClient client;
            NetworkStream nsToRead;
            client = new TcpClient();
            bool firstCom = true;
            bool DiscOne = false;
            Users user = null;
            try
            {
                client = server.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(newClient);
            }
            catch (Exception ex)
            {
                riseUnexpectedComError(ex.Message);
            }
            while (!Disc && !DiscOne)
            {
                try
                {
                    if (DiscAll)
                    {
                        WriteCommandsToClient(client, "DISC", "", "", "");
                        DiscAll = false;
                    }
                    byte[] received = new byte[100000];
                    nsToRead = client.GetStream();
                    nsToRead.ReadTimeout = 10;
                    nsToRead.Read(received, 0, received.Length);
                    txt = Encoding.ASCII.GetString(received);
                    myFrameManager.Frame(txt);
                    if (firstCom)
                    {
                        if (myFrameManager.getCommand() == "LOG")
                        {
                            log = login(client, myFrameManager.getArg1(), myFrameManager.getArg2());
                            if (log == null)
                            {
                                user = myClientsManager.getUserFromOnlineUsers(myClientsManager.getIndexOnlineUsersByClient(client));
                                WriteCommandsToClient(client, "LOG", "OK", "", "");
                                riseCommand("SPWN", user.getAgvId());
                                firstCom = false;
                                clientslist.Add(client);
                            }
                            else
                            {
                                WriteCommandsToClient(client, "LOG", "WR", log, "");
                            }
                        }
                    }
                    else
                    {
                        if(myFrameManager.getCommand() == "DISC")
                        {
                            ReadOrders(user);
                            DiscOne = true;
                            
                        }
                        else
                        {
                            ReadOrders(user);
                        }
                    }
                    
                }
                catch(Exception ex)
                {

                }
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

            if (OnlineMax >= OnlineUsersSize)
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
                byte[] buffer = Encoding.ASCII.GetBytes(txt);
                nsToWrite.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                riseUnexpectedComError(ex.Message);
            }
        }

        private void ReadOrders(Users user )
        {
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
                    myClientsManager.RemoveUserFromOnlineUsers(user);
                    myClientsManager.leaveAgvToAgvList(user.getAgvId());
                    myClientsManager.setUsersClient(myClientsManager.getIndexUsersByAgvId(user.getAgvId()), null);
                    clientslist.Remove(user.getTcpClient());
                    txt = "DISC";
                    break;
                    
            }
            riseCommand(txt, Agvref);
        }

        public void disconectAll()
        {
            
            foreach (TcpClient user in clientslist)
            {
                WriteCommandsToClient(user, "DISC", "", "", "");
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
        public void setDisc(bool state)
        {
            Disc = true;
        }
        public void setDiscAll(bool a) { DiscAll = a; }


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
