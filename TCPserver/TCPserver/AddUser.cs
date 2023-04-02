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
    partial class AddUser : Form
    {
        public event EventHandler<Class1> NewUser;

        public AddUser()
        {
            InitializeComponent();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Substring(0, 3) == "Us_")
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        try
                        {
                            string c = textBox2.Text.Substring(0, 3);
                            int a = Int32.Parse(textBox2.Text);
                            int b = Int32.Parse(textBox3.Text);
                            riseNewUser(textBox1.Text, textBox2.Text);
                            this.Close();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("The passwords must be numeric and 4 digits");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The passwords must be the same to apply");
                    }
                }
                else
                {
                    MessageBox.Show("The Name must starts with -> Us_");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("You must enter as minimum (Us_ + some identfier type)");
            }
            
        }
        private void riseNewUser(string Name, string password)
        {
            Class1 args = new Class1();
            args.user = Name;
            args.password = password;
            EventHandler<Class1> handler = NewUser;
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}
