using System;
using System.Net.Sockets;

namespace EasyTCPSample
{
    public class TCPClient
    {
        #region Declarations
        private TcpClient _client = null;
        Byte[] data = System.Text.Encoding.Unicode.GetBytes("DefaultMessage");
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
        /// Constructor
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public TCPClient(string ip, int port)
        {
            IP = ip;
            Port = port;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            try
            {
                _client = new TcpClient(IP, Port);
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
        /// <param name="Message"></param>
        /// <returns></returns>
        public bool Send(string Message)
        {
            try
            {
                Byte[] data = System.Text.Encoding.Unicode.GetBytes(Message);
                NetworkStream stream = _client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.WriteLine($"Message send : {data}");
                return true;
            }
            catch (Exception ie)
            {
                Console.WriteLine($"Send Exception\r\n{ie.Message}\r\n{ie.StackTrace}");
                return false;
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
                _client.Close();
                return true;
            }
            catch (Exception ie)
            {
                Console.WriteLine($"Stop Exception\r\n{ie.Message}\r\n{ie.StackTrace}");
                return false;
            }
        }
        #endregion
    }
}
