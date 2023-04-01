using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client_AGV
{
    public partial class Form1 : Form
    {
        // Objects
        private Config_form mySvConf;
        private TcpClientComManager myComManager;
        private Controls myControls;

        // Delgates
        private delegate void Safelblconexion(string state, Color color);
        private delegate void SafelblLog(string state, Color color);
        private delegate void SafeCloseControls();

        // Class variables
        private bool serverOnline;
        
        // Constructors
        public Form1()
        {
            InitializeComponent();

            mySvConf = new Config_form();
            myComManager= new TcpClientComManager();
            myControls = new Controls();

            mySvConf.ClientConexion += NewServer;
            myControls.Command += OrdersToSend;
            myComManager.Connect += Conexion;
            myComManager.Disconnect += Disconnexion;
            myComManager.Loggedin += Logged;

            serverOnline = false;
            lblstate.Text = "Offline";
        }

        // Graphics methods
        private void Config_Click(object sender, EventArgs e)
        {
            mySvConf.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (serverOnline)
            {
                myComManager.login(textBox1.Text, textBox2.Text);
            }
            else
            {
                MessageBox.Show("You have to connect to a server");
            }
        }

        // Method
        private void OrdersToSend(object sender, CommandsEventArgs e)
        {
            int a;
            a = e.Command;
            if(a == 1) 
            {
                ChangeLbl("Online", Color.Red);
                lblstate.ForeColor = Color.Red;
                serverOnline = false;
            }
            myComManager.WriteCommandsToClient(a);
        }
        private void NewServer(object sender, ConexionEventArgs e)
        {
            serverOnline = true;
            lblstate.Text = "Online";
            lblstate.ForeColor=Color.Green;
            myComManager.NewServer(e.client);
        }
        private void Conexion(object sender, EventArgs e)
        {
            mySvConf.ConnectToServer();
        }
        private void Disconnexion(object sender, EventArgs e)
        {
            myControls.Close();
            ChangeLbl("Offline", Color.Red);
            serverOnline = false;
            myComManager.WriteCommandsToClient(1);
        }
       
        private void Logged(object sender, EventArgs e)
        {
            if (myComManager.getLogged())
            {
                myControls.ShowDialog();
                ChangeLbl3("", Color.Red);
            }
            else
            {
                ChangeLbl3(myComManager.getLogError(), Color.Red);
            }
        }


        // safe methods
        private void ChangeLbl3(string text, Color color)
        {
            if (label3.InvokeRequired)
            {
                var d = new SafelblLog(ChangeLbl3);
                label3.Invoke(d, new object[] { text, color });
            }
            else
            {
                label3.Text = text;
                label3.ForeColor = color;
            }
        }
        private void ChangeLbl(string text, Color color)
        {
            if (lblstate.InvokeRequired)
            {
                var d = new Safelblconexion(ChangeLbl);
                lblstate.Invoke(d, new object[] { text, color });
            }
            else
            {
                lblstate.Text = text;
                lblstate.ForeColor = color;
            }
        }
    }

}
