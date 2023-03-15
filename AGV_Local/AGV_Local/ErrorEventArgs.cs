using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatServerTCPObjected
{
    class ErrorEventArgs:EventArgs
    {
        public string message { get; set; }
    }
}
