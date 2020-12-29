using System;
using System.Threading;

namespace MyPhone
{
    class Program
    {
        private static int port = 8000;
        private static string host = "127.0.0.1";
        static Random rand = new Random();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        public void Run()
        {
            Console.Write("1 - Server, 2 - Client >");
            string t = Console.ReadLine();

            Phone phone;
            if (t == "1") phone = new PhoneServer(port);
            else phone = new PhoneClient(host, port);
            phone.Receive += Receive;
            phone.Start();

            if (t=="1")
            while (true)
            {
                phone.Send((byte)rand.Next(10, 100));
                Thread.Sleep(2000);
            }
        }

        public void Receive(byte data)
        {
            Console.WriteLine("Data: " + data);
        }
    }
}
