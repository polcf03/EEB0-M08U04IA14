using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPserver
{
    class FrameManager
    {
        // Class variables
        string command, arg1, arg2, arg3;

        //Constructor
        public FrameManager() 
        {
            command = "";
            arg1 = "";
            arg2 = "";
            arg3 = "";
        }

        // Frame modifier
        public void Frame(string str)
        {
            char [] c = str.ToCharArray();
            string a = "";
            int i = 0;
            do
            {
                a += c[i];
                i++;
            }
            while (c[i] != '#');
            a = "";
            i++;
            while (c[i] != '$')
            {
                a += c[i];
                i++;
            }
            command = a;
            a = "";
            i++;
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
            i++;
        
        }

        // Accessors
        public string Command() { return command; }
        public string Arg1() { return arg1; }
        public string Arg2() { return arg2; }
        public string Arg3() { return arg3;}

        // Modifier
        public void Command(string str) { command = str; }
        public void Arg1(string str) { arg1 = str; }
        public void Arg2(string str) { arg2 = str; }
        public void Arg3(string str) { arg3 = str; }



    }
}
