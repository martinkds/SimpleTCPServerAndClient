using System;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace SimpleTCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
			{
				TcpListener listener = new TcpListener(IPAddress.Loopback,5432);
				listener.Start();
				Console.WriteLine("Waiting for a connection...");
				TcpClient socket = listener.AcceptTcpClient();
				NetworkStream outputStream = socket.GetStream();
				using(StreamWriter writer = new StreamWriter(outputStream))
				{
					writer.WriteLine("Hello World to the client!");
				}
				outputStream.Close();
				socket.Close();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
        }
    }
}
