using System;
using System.Net.Sockets;
using System.Text;

namespace NewSocketPeer
{
    public class Message
    {
        private Network network = new Network();

        public void SendMessage(Socket sender)
        {

            while (true)
            {
                String message = Console.ReadLine();
                byte[] msg = Encoding.ASCII.GetBytes(message);
                int bytesSent = sender.Send(msg);
            }
        }

        public void ReceiveMessage(Socket receiver)
        {
            while (true)
            {
                string data = "";

                byte[] bytess = new byte[1024];

                int bytesRec = receiver.Receive(bytess);

                data = Encoding.ASCII.GetString(bytess, 0, bytesRec);

                Console.WriteLine("> Received : {0}", data);

            }
        }
    }
}
