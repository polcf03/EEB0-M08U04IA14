using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing.Imaging;
using System.Drawing.Text;

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
            ThreadPool.QueueUserWorkItem(ReceiveMessages);
            logged = false;
        }
        private void ReceiveMessages(object state)
        {
            NetworkStream ns;
            byte[] toReceive = new byte[100000];
            string txt;

            while (ConexionState)
            {
                try
                {
                    ns = ServerToConect.GetStream();
                    //ns.ReadTimeout = 10;
                    ns.Read(toReceive, 0, toReceive.Length);
                    txt = Encoding.ASCII.GetString(toReceive);
                    myFrameManager.Frame(txt);
                    ReadData(myFrameManager.getCommand(), myFrameManager.getArg1(),myFrameManager.getArg2());
                }
                catch(Exception ex) { }
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
            string txt = OrderToSend(a);
            sendMessage(txt);
            if (myFrameManager.getCommand() == "DISC")
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
            sendMessage(order);
        }
        public void disconect()
        {
            ConexionState = false;
        }
        private void ReadData(string Command, string Arg1, string Arg2)
        {
            if(Command == "DISC")
            {
                riseDisconexion(EventArgs.Empty);
            }
            else if(Command == "LOG")
            {
                if(Arg1 != "OK")
                {
                    LogError = Arg2;
                }
                else
                {
                    logged = true;
                }
                riseLogged(EventArgs.Empty);
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
