using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.ExceptionServices;
using System.Diagnostics.Eventing.Reader;

namespace Client_AGV
{
    partial class TcpClientComManager
    {
        // Class variables
        private FrameManager myFrameManager;
        private TcpClient ServerToConect;
        private bool ConexionState;
        private string LogError;
        private bool logged;

        // Delegates
        public event EventHandler<ErrorEventArgs> UnexpectedComError;
        public event EventHandler Disconnect;
        public event EventHandler Connect;
        public event EventHandler Loggedin;

        // Constructores
        public TcpClientComManager()
        {
            ServerToConect = null;
            myFrameManager= new FrameManager();
            ConexionState = false;
            logged= false;
            LogError = "";
        }

        // Methods
        public void NewServer(TcpClient NewServer)
        {
            setTcpServer(NewServer);
            ConexionState = true;
            ThreadPool.QueueUserWorkItem(Main);
            logged = false;
        }
        private void Main(object state)
        {
            NetworkStream ns;
            byte[] toReceive = new byte[100000];
            string txt;

            while (ConexionState)
            {
                try
                {
                    if (!logged)
                    {
                        myFrameManager.Frame(ReceiveMessageFromClient(ServerToConect));
                        if(myFrameManager.getCommand() == "LOG")
                        {

                            if (myFrameManager.getArg1() == "OK")
                            {
                                logged = true;
                            }
                            else
                            {
                                LogError = myFrameManager.getArg3();
                            }
                            riseLogged(EventArgs.Empty);
                        }
                        else
                        {
                            LogError = "Something wrong";
                            riseLogged(EventArgs.Empty);
                        }
                    }
                    else
                    {
                        myFrameManager.Frame(ReceiveMessageFromClient(ServerToConect));
                        if (myFrameManager.getCommand() == "DISC")
                        {
                            riseDisconexion(EventArgs.Empty);
                        }
                    }
                }
                catch(Exception ex) { }
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
        public void WriteCommandsToClient( int a)
        {
            string txt = OrderToSend(a);

            try
            {
                TcpClient clientToSend = ServerToConect;
                NetworkStream nsToWrite = ServerToConect.GetStream();
                nsToWrite.Write(Encoding.ASCII.GetBytes(txt), 0, txt.Length);
                byte[] buffer = Encoding.ASCII.GetBytes(txt);
                nsToWrite.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                riseUnexpectedComError(ex.Message);
            }
        }
        public void login(string name, string passsword)
        {
            WriteCommandsToClient(ServerToConect, "LOG", "Us_"+ name, passsword, "");
        }
        private string OrderToSend(int Command)
        {
            string order;
            order = "";
            switch (Command)
            {
                case 1: // EXIT
                    order = myFrameManager.Order("DISC", "", "", "");
                    break;
                case 2: // FOR
                    order = myFrameManager.Order("MOV", "FOR", "", "");
                    break;
                case 3: // ROTATE_LEFT
                    order = myFrameManager.Order("MOV", "RT", "LEF", "");
                    break;
                case 4: // UP
                    order = myFrameManager.Order("MOV", "UP", "", "");
                    break;
                case 5: // ROTATE_RIGHT
                    order = myFrameManager.Order("MOV", "RT", "RIG", "");
                    break;
                case 6: // LEFT
                    order = myFrameManager.Order("MOV", "LEF", "", "");
                    break;
                case 7: // DOWN
                    order = myFrameManager.Order("MOV", "DOWN", "", "");
                    break;
                case 8: // RIGHT
                    order = myFrameManager.Order("MOV", "RIG", "", "");
                    break;
                case 9: // BACK
                    order = myFrameManager.Order("MOV", "BACK", "", "");
                    break;
            }
            return order;
        }

        public void disconect()
        {
            ConexionState = false;
        }
       









        // Events
        private void riseUnexpectedComError(string txtError)
        {
            ErrorEventArgs args = new ErrorEventArgs();
            args.message = txtError;
            EventHandler<ErrorEventArgs> handler = UnexpectedComError;
            if (handler != null)
            {
                handler(this, args);
            }
        }
        private void riseDisconexion(EventArgs e)
        {
            Disconnect.Invoke(this, e);
        }
        private void riseLogged(EventArgs e)
        {
            Loggedin.Invoke(this, e);
        }
        private void riseConexion(EventArgs e)
        {
            Connect.Invoke(this, e);
        }

        // Accessors
        private TcpClient getTcpClient() { return ServerToConect; }
        public bool getConexionState() { return ConexionState; }
        public string getLogError() { return LogError; }
        public bool getLogged() { return logged; }

        // Modifiers
        private void setTcpServer(TcpClient NewServer) { ServerToConect = NewServer; }

    }
}
