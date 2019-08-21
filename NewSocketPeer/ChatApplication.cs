using System;
using System.Net.Sockets;
using System.Threading;

namespace NewSocketPeer
{
    public class ChatApplication
    {
        private Message message = new Message();
        private Network network = new Network();
        public void StartConnection()
        {
            Console.WriteLine("Waiting for " + network.GetIPAddress());

            Socket send = network.StartListening();
            Console.WriteLine("Connected Start Message");
            Thread sendThread = new Thread(() => message.SendMessage(send));
            Thread receiveThread = new Thread(() => message.ReceiveMessage(send));
            sendThread.Start();
            receiveThread.Start();
        }

        public void StartConnect()
        {
            Console.WriteLine("Connect to " + network.GetIPAddress());
            string ip = Console.ReadLine();
            Socket send = network.GetSocketForListen(ip);
            Thread sendThread = new Thread(() => message.SendMessage(send));
            Thread receiveThread = new Thread(() => message.ReceiveMessage(send));
            sendThread.Start();
            receiveThread.Start();
        }
    }
}
