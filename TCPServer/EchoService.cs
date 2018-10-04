using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Skat;

namespace TCPServer
{
    class EchoService : Afgift
    {
        private TcpClient connectionSocket;

        public EchoService(TcpClient connectionSocket)
        {
            this.connectionSocket = connectionSocket;
        }

        internal void DoIt()
        {
            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;


            string message = sr.ReadLine();
            string message2 = sr.ReadLine();
            int answer;
            
            while (true)
            {
                if (message == "Bil")
                {
                    string pris = message2;
                    Console.WriteLine("Bil");
                    answer = BilAfgift(Convert.ToInt32(pris));
                    sw.WriteLine(answer);
                    message = sr.ReadLine();
                }
                else if (message == "Elbil")
                {
                    string pris = message2;
                    Console.WriteLine("ElBil");
                    answer = ElBilAfgift(Convert.ToInt32(pris));
                    sw.WriteLine(answer);
                    message = sr.ReadLine();
                }

            }
            ns.Close();
            connectionSocket.Close();
        }
    }
}
