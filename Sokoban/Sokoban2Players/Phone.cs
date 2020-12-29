using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Sokoban2Players
{
    public delegate void DlgReceive(byte data);

    abstract class Phone
    {
        protected NetworkStream ns;
        protected int port;
        protected string host;
        public DlgReceive Receive;

        public bool Send(byte data)
        {
            try
            {
                ns.WriteByte(data);
                return true;
            }
            catch
            {
                Thread.Sleep(100);
                return false;
            }
        }

        public void Start()
        {
            Thread thread = new Thread(Waiter);
            thread.IsBackground = true;
            thread.Start();
        }

        private void Waiter()
        {
            while (true)
            {
                Connect();
                while (true)
                {
                    try
                    {
                        int data = ns.ReadByte();
                        if (data != -1) Receive((byte)data);
                    }
                    catch
                    {
                        Thread.Sleep(100);
                        break;
                    }
                }
            }
        }

        public abstract void Connect();
    }

    class PhoneServer : Phone
    {
        public PhoneServer(int port)
        {
            this.port = port;
        }

        public override void Connect()
        {
            try
            {
                TcpListener listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                TcpClient client = listener.AcceptTcpClient();
                ns = client.GetStream();
            }
            catch
            {
                
            }
        }
    }

    class PhoneClient : Phone
    {
        public PhoneClient(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public override void Connect()
        {
            try
            {
                TcpClient client = new TcpClient(host, port);
                ns = client.GetStream();
            }
            catch
            {

            }
        }
    }
}
