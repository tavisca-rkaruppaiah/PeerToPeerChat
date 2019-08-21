using System;

namespace NewSocketPeer
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatApplication chatApplication = new ChatApplication();
            Console.WriteLine("Are you Client or Server");
            string s = Console.ReadLine().ToLower();
            if (s == "c")
            {
                chatApplication.StartConnect();
            }
            else if(s == "s")
            {
                chatApplication.StartConnection();
            }
        }
    }
}
