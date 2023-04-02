using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCPserver
{
    partial class removeUser : Form
    {
        private List<Users> users = new List<Users>();
        public event EventHandler<Class2> remove;
            
        public removeUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                risermoveUser(comboBox1.GetItemText(comboBox1.SelectedItem));
                this.Close();
            }
        }
        public void setList(List<Users> Users)
        {
            users = Users;
        }

        private void removeUser_Load(object sender, EventArgs e)
        {
            foreach(Users user in users)
            {
                comboBox1.Items.Add(user.getName());
            }
        }
        private void risermoveUser(string Name)
        {
            Class2 args = new Class2();
            args.Name = Name;
            EventHandler<Class2> handler = remove;
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}
