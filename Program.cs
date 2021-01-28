using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EasyTCPSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.TCP Server 2.TCP Client");
            var input = Console.ReadLine();
            IKernel container = new StandardKernel();
            container.Bind<TCPServer>().ToSelf()
                     .WithConstructorArgument("ip", "127.0.0.1")
                     .WithConstructorArgument("port", 54088);

            container.Bind<TCPClient>().ToSelf()
                     .WithConstructorArgument("ip", "127.0.0.1")
                     .WithConstructorArgument("port", 54088);

            switch (input)
            {
                case "1":
                    var tcpServer = container.Get<TCPServer>();
                    tcpServer.Start();
                    tcpServer.Listen();
                    tcpServer.Stop();
                    break;
                case "2":
                    var tcpClient = container.Get<TCPClient>();
                    tcpClient.Start();
                    while (true)
                    {
                        Console.WriteLine("Input message : ");
                        var message = Console.ReadLine();
                        var sendSuccess = tcpClient.Send(message);
                        if (!sendSuccess)
                        {
                            tcpClient.Stop();
                            break;
                        }
                    }
                    break;
            }
        }
    }
}
