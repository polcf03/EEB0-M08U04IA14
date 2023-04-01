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
using System.Xml.Linq;

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
        }
        private void newClient(object satate)
        {
            bool firstCom = true;
            
            TcpClient client;
            NetworkStream nsToRead;
            client = new TcpClient();
            Users user = null;

            try
            {
                client = server.AcceptTcpClient();
                clientslist.Add(client);
                ThreadPool.QueueUserWorkItem(newClient);
                while (true)
                {
                    myFrameManager.Frame(ReceiveMessageFromClient(client));
                    if (firstCom)
                    {
                        string name = myFrameManager.getArg1();
                        string password = myFrameManager.getArg2();
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
                        if (myFrameManager.getCommand() == "LOG")
                        {
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
                        string txt = "";
                        switch (myFrameManager.getCommand())
                        {
                            case "MOV":
                                switch (myFrameManager.getArg1())
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
                                        if (myFrameManager.getArg2() == "RIG")
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
                        riseCommand(txt, user.getAgvId());
                    }
                }
            }
            catch (Exception ex)
            {
                if (clientslist.Contains(client))
                {
                    clientslist.Remove(client);
                }
                riseUnexpectedComError(ex.Message);
            }
        }

        private void WriteCommandsToClient(TcpClient client, string Command, string Arg1, string Arg2, string Arg3)
        {
            string txt = myFrameManager.Order(Command, Arg1, Arg2, Arg3);
            try
            {
                TcpClient clientToSend = client;
                NetworkStream nsToWrite = client.GetStream();
                nsToWrite.Write(Encoding.ASCII.GetBytes(txt), 0, txt.Length);
                byte[] buffer = Encoding.ASCII.GetBytes(txt);
                nsToWrite.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                riseUnexpectedComError(ex.Message);
            }
        }
        public void DisconectAll()
        {
            string txt = myFrameManager.Order("DISC", "", "", "");
            foreach(TcpClient client in clientslist)
            {
                try
                {
                    TcpClient clientToSend = client;
                    NetworkStream nsToWrite = client.GetStream();
                    nsToWrite.Write(Encoding.ASCII.GetBytes(txt), 0, txt.Length);
                    byte[] buffer = Encoding.ASCII.GetBytes(txt);
                    nsToWrite.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    riseUnexpectedComError(ex.Message);
                }
            }
            
        }
        private string ReceiveMessageFromClient(TcpClient client)
        {
            TcpClient clientToReadFrom = client;
            NetworkStream stream = clientToReadFrom.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            return message;
        }











        public void stopServer() { Disc = true; server.Stop(); }
        














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
