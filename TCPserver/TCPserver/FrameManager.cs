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
            Command = a;
            a = "";
            i++;
            while (c[i] != '&')
            {
                a += c[i];
                i++;
            }
            Arg1 = a;
            a = "";
            i++;
            while (c[i] != '%')
            {
                a += c[i];
                i++;
            }
            Arg2 = a;
            a = "";
            i++;
            while (c[i] != '#')
            {
                a += c[i];
                i++;
            }
            Arg3 = a;
            a = "";
            i++;
        
        }

        // Access
        public string Command()
        {
            return command;
        }
        public string Arg1()
        {
            return arg1;
        }
        public string Arg2()
        {
            return arg2;
        }
        public string Arg3()
        {
            return arg3;
        }
    }
}
