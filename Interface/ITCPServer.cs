using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTCPSample
{
    public interface ITCPServer
    {
        Int32 Port { get; set; }
        string IP { get; set; }
        bool Start();
        void Listen();
        bool Stop();
    }
}
