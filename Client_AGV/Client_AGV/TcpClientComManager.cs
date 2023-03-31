using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing.Imaging;

namespace Client_AGV
{
    partial class TcpClientComManager
    {
        // Class variables
        private FrameManager myFrameManager;
        private TcpClient ServerToConect;
        private bool ConexionState;
        private string LogError;

        // Delegates
        public event EventHandler<ErrorEventArgs> UnexpectedComError;
        public event EventHandler Disconnect;
        public event EventHandler Connect;

        // Constructores
        public TcpClientComManager()
        {
            ServerToConect = null;
            myFrameManager= new FrameManager();
            ConexionState = false;
            LogError = "";
        }

        // Methods
        public void NewServer(TcpClient NewServer)
        {
            setTcpServer(NewServer);
        }
        private void ReceiveMessages(object state)
        {
            NetworkStream ns;
            byte[] toReceive = new byte[100000];
            string txt;
            try
            {
                while (ConexionState)
                {
                    ns = ServerToConect.GetStream();
                    ns.Read(toReceive, 0, toReceive.Length);
                    txt = Encoding.ASCII.GetString(toReceive);
                    myFrameManager.Frame(txt);
                    ReadData(myFrameManager.getCommand(),myFrameManager.getArg1());
                }
            }
            catch (Exception ex)
            {
                riseUnexpectedComError(ex.Message);
            }
        }
        private void sendMessage(String txtToSend)
        {
            NetworkStream ns;
            try
            {
                ns = ServerToConect.GetStream();
                ns.Write(Encoding.ASCII.GetBytes(txtToSend), 0, txtToSend.Length);
            }
            catch (Exception ex)
            {
                riseUnexpectedComError(ex.Message);
            }
        }
        public void SendOrder(int a)
        {
            sendMessage(OrderToSend(a));
            if(myFrameManager.getCommand() == "DISC")
            {
                ServerToConect = null;
                ConexionState = false;
            }
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
        public void login(string user, string passw)
        {
            string order;
            byte[] received = new byte[100000];
            order = myFrameManager.Order("LOG", "Us_" + user, passw, "");
            NetworkStream nsToRead;
            try
            {
                sendMessage(order);
                nsToRead = ServerToConect.GetStream();
                nsToRead.Read(received, 0, received.Length);
                order = Encoding.ASCII.GetString(received);
                myFrameManager.Frame(order);
                if (myFrameManager.getCommand() == "LOG" && myFrameManager.getArg1() == "OK")
                {
                    ConexionState = true;
                    ThreadPool.QueueUserWorkItem(ReceiveMessages);
                }
                else if (myFrameManager.getArg1() == "WR")
                {
                    LogError = myFrameManager.getArg2();
                    riseConexion(EventArgs.Empty);
                    ConexionState = false;
                    
                }
                else
                {
                    riseConexion(EventArgs.Empty);
                    LogError = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                riseUnexpectedComError(ex.Message);
            }
        }
        public void disconect()
        {
            ConexionState = false;
        }
        private void ReadData(string Command, string Arg1)
        {
            if(Command == "DISC")
            {
                riseDisconexion(EventArgs.Empty);
            }

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
        private void riseConexion(EventArgs e)
        {
            Connect.Invoke(this, e);
        }

        // Accessors
        private TcpClient getTcpClient() { return ServerToConect; }
        public bool getConexionState() { return ConexionState; }
        public string getLogError() { return LogError; }

        // Modifiers
        private void setTcpServer(TcpClient NewServer) { ServerToConect = NewServer; }

    }
}
