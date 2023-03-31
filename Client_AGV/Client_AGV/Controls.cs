using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Client_AGV
{
    partial class Controls : Form
    {
        // Delegates
        public event EventHandler<CommandsEventArgs> Command;
        private delegate void CloseSafe();

        // Constructores
        public Controls()
        {
            InitializeComponent();
        }

        // Control Methods
        private void btExit_Click(object sender, EventArgs e)
        {
            TransferCommand(1);
            CloseControls();
        }
        private void btFor_Click(object sender, EventArgs e)
        {
            TransferCommand(2);
        }
        private void btRtlf_Click(object sender, EventArgs e)
        {
            TransferCommand(3);
        }
        private void btUp_Click(object sender, EventArgs e)
        {
            TransferCommand(4);
        }
        private void btRtrg_Click(object sender, EventArgs e)
        {
            TransferCommand(5);
        }
        private void btLeft_Click(object sender, EventArgs e)
        {
            TransferCommand(6);
        }
        private void btDown_Click(object sender, EventArgs e)
        {
            TransferCommand(7);
        }
        private void btRight_Click(object sender, EventArgs e)
        {
            TransferCommand(8);
        }
        private void btBack_Click(object sender, EventArgs e)
        {
            TransferCommand(9);
        }
      
        // Methods
        public void CloseControls()
        {
            if (this.InvokeRequired)
            {
                var d = new CloseSafe(CloseControls);
                this.Invoke(d, new object[] {  });
            }
            else
            {
                this.Close();
            }
            
        }

        // Events
        private void TransferCommand(int command)


        {
            CommandsEventArgs args = new CommandsEventArgs();
            args.Command = command;
            EventHandler<CommandsEventArgs> handler = Command;
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}
