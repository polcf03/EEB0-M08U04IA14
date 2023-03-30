using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client_AGV
{
    partial class Config_form : Form
    {
        // Class variables
        private string serverIP;
        private int serverPort;
        private TcpClient client;

        // Delegates
        public event EventHandler<ConexionEventArgs> ClientConexion;
        
        // Constructores
        public Config_form()
        {
            InitializeComponent();

            serverIP = IPAddress.Loopback.ToString();
            serverPort = 1;
        }

        // Class events
        private void button2_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }
        
        // Methods
        public void ConnectToServer()
        {
            try
            {
                serverIP = textBox1.Text;
                serverPort = int.Parse(textBox2.Text);
                client = new TcpClient(serverIP, serverPort);
                if(client != null)
                {
                    TransferClient(client);
                    CloseConfig();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar al servdior. Volver a intentar.");
            }
        }
        private void CloseConfig()
        {
            this.Close();
        }

        // Events
        private void TransferClient(TcpClient ClientTransferred)
        {
            ConexionEventArgs args = new ConexionEventArgs();
            args.client = ClientTransferred;
            EventHandler<ConexionEventArgs> handler = ClientConexion;
            if(handler != null)
            {
                handler(this, args);
            }
        }

        // Accessors
        public string getServerIP() { return serverIP; }
        public int getServerPort() { return serverPort; }
        public TcpClient getClient() { return client; }

        // Modifiers
        public void setServerIP(string ip) { serverIP = ip; }
        public void setServerPort(int port) { serverPort = port; }
        public void setClient(TcpClient newclient) { client = newclient; }
    }
}
