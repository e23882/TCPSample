using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTCPSample
{
    public interface ITCPClient
    {
        Int32 Port { get; set; }
        string IP { get; set; }
        bool Stop();
        bool Send(string message);
    }
}
