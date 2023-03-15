using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPserver
{
    class DataReceivedEventArgs:EventArgs
    {
        public string txtReceived { get; set; }
    }
}
