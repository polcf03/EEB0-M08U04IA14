using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatServerTCPObjected
{
    class DataReceivedEventArgs:EventArgs
    {
        public string txtReceived { get; set; }
    }
}
