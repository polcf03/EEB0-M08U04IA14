using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPserver
{
    class DisconnectEventArgs:EventArgs
    {
        public int agv { get; set; }
    }
}
