using System;
using System.Net;
using System.Net.Sockets;

namespace NewSocketPeer
{
    public class Network
    {
        public string GetIPAddress()
        {
            IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress i in ip)
            {
                if (i.AddressFamily == AddressFamily.InterNetwork)
                    return i.ToString();
            }

            return "127.0.0.1";
        }
        public IPEndPoint GetIPEndPoint(string ip)
        {
            return new IPEndPoint(IPAddress.Parse(GetIPAddress()), 35);
        }
        public Socket GetSocket()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(GetIPEndPoint(GetIPAddress()));
            socket.Listen(10);

            return socket;
        }

        public Socket GetSocketForListen(string ip)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(GetIPEndPoint(ip));
            Console.Clear();
            Console.WriteLine("Successfuly connected");
            return socket;
        }

        public Socket StartListening()
        {
            return GetSocket().Accept();
        }

        public void StopListening()
        {
            GetSocket().Close();
        }


    }
}
