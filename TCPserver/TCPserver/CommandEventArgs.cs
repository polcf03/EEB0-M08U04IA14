using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPserver
{
    internal class CommandEventArgs: EventArgs
    {
        public string Command { get; set; }
        public int AGVrequested { get; set; }
    }
}
