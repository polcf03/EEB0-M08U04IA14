using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPserver
{
    class FrameManager : EventArgs
    {
        // Class varables
        string command, arg1, arg2, arg3, order;

        // Constructor
        public FrameManager()
        {
            command = "";
            arg1 = "";
            arg2 = "";
            arg3 = "";
            order = "";
        }

        // Frame spliter
        public void Frame(string str)
        {
            char[] c = str.ToCharArray();
            string a = "";
            int i = 0;
            do
            {
                a += c[i];
                i++;
            }
            while (c[i] == '#');
            a = "";
            while (c[i] != '$')
            {
                a += c[i];
                i++;
            }
            command = a;
            i++;
            a = "";
            while (c[i] != '&')
            {
                a += c[i];
                i++;
            }
            arg1 = a;
            a = "";
            i++;
            while (c[i] != '%')
            {
                a += c[i];
                i++;
            }
            arg2 = a;
            a = "";
            i++;
            while (c[i] != '#')
            {
                a += c[i];
                i++;
            }
            arg3 = a;
            a = "";
        }

        // Order creator 
        public string Order()
        {
            CreateFrame();
            return order;
        }
        public string Order(string Command, string Arg1, string Arg2, string Arg3)
        {
            setFramesArgs(Command, Arg1, Arg2, Arg3);
            CreateFrame();
            return order;
        }

        // Args Modifier and frame creator
        private void setFramesArgs(string Command, string Arg1, string Arg2, string Arg3)
        {
            command = Command;
            arg1 = Arg1;
            arg2 = Arg2;
            arg3 = Arg3;
        }
        private void CreateFrame()
        {
            order = "#" + command + "$" + arg1 + "&" + arg2 + "%" + arg3 + "#";
        }

        // Accessors
        public string getCommand() { return command; }
        public string getArg1() { return arg1; }
        public string getArg2() { return arg2; }
        public string getArg3() { return arg3; }

        // Modifier
        private void setCommand(string str) { command = str; }
        private void setArg1(string str) { arg1 = str; }
        private void setArg2(string str) { arg2 = str; }
        private void setArg3(string str) { arg3 = str; }
    }
}
