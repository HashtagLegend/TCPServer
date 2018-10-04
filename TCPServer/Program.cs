using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener serverSocket = new TcpListener(ip, 7000);
            serverSocket.Start();

            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Incoming connection established");
                EchoService service = new EchoService(connectionSocket);
                Task.Factory.StartNew(service.DoIt);
            }

            serverSocket.Stop();
        }
    }
}
