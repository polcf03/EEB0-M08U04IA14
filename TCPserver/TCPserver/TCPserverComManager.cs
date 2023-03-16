using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPserver
{
    //-------------------------------------------------------------------------------------------------------------------
    //------Esta Clase se encarga de la gestion de la comunicación TCP-IP------------------------------------------------
    //------Es independiente de la IGU, es capaz de lanzar dos eventos---------------------------------------------------
    //-----------------UnexpectedComError  --> Evento que lanzamos si hay unh error inesperado en la comunicación--------
    //-----------------DataReceived  --> Evento podemos lanzar si recivimos un dato--------------------------------------
    //-------------------------------------------------------------------------------------------------------------------

    class TCPServerComManager
    {
        // Class variables    
        private IPAddress myIp;
        private int myPort;
        private TcpListener server;
        private List<TcpClient> listOfClients;

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


        //Método compacto que permite lanzar el evento de error de comunicación inesperado
        private void riseUnexpectedComError(string txtError)
        {
            ErrorEventArgs args = new ErrorEventArgs();
            args.message = txtError;
            onUnexpectedComError(args);
        }

        //Método compacto que permite lanzar un evento de información recivida
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
