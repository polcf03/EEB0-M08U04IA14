using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Client_AGV
{
    class ConexionEventArgs : EventArgs
    {
        public TcpClient client { get; set; }
    }
}
