using System;
using System.Net;
using System.Net.Sockets;

namespace EasyTCPSample
{
    public class TCPServer
    {
        #region Declarations
        private TcpListener _server = null;
        Byte[] byteInstance = new byte[2048];
        string data = string.Empty;
        #endregion

        #region Property

        /// <summary>
        /// 
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IP { get; set; }
        #endregion

        #region Memberfunction
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public TCPServer(string ip, int port)
        {
            IP = ip;
            Port = port;
            _server = new TcpListener(IPAddress.Parse(IP), Port);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            try
            {
                _server.Start();
                return true;
            }
            catch (Exception ie)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Listen()
        {
            Console.WriteLine("Service listening...");
            while (true)
            {
                var tcpClient = _server.AcceptTcpClient();
                var NetworkStream = tcpClient.GetStream();

                int currentDataIndex = 0;
                while ((currentDataIndex = NetworkStream.Read(byteInstance, 0, byteInstance.Length)) != 0)
                {
                    data = System.Text.Encoding.Unicode.GetString(byteInstance, 0, currentDataIndex);
                    Console.WriteLine($"Receive data : {data}");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            try
            {
                _server.Stop();
                return true;
            }
            catch (Exception ie)
            {
                return false;
            }
        }
        #endregion
    }
}
