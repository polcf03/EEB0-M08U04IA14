using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client_AGV
{
    class CommandsEventArgs : EventArgs
    {
        public int Command { get; set; }
    }
}
