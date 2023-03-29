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
                if (myComManager.getConexionState())
                {
                    myControls.ShowDialog();
                }
                else
                {
                    label3.Text = myComManager.getLogError();
                }
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
                lblstate.Text = "Offline";
                lblstate.ForeColor = Color.Red;
            }
            myComManager.SendOrder(a);
        }
        private void NewServer(object sender, ConexionEventArgs e)
        {
            serverOnline = true;
            lblstate.Text = "Online";
            lblstate.ForeColor=Color.Green;
            myComManager.NewServer(e.client);
        }
        private void Disconnexion(object sender, EventArgs e)
        {
            serverOnline = false;
            lblstate.Text = "Offline";
            lblstate.ForeColor = Color.Red;
            myComManager.disconect();
        }
    }
}
