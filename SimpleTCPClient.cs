using System;
using System.Net.Sockets;
using System.IO;

namespace Samples.Networking
{
    public class SimpleTCPClient
    {
        public static void Main(string[]args)
        {
			Console.WriteLine ("Press [Enter] to read the message from the server");
			Console.ReadLine ();
            try
            {
                TcpClient socket = new TcpClient("127.0.0.1",5432);
                NetworkStream inputStream = socket.GetStream();
                using(StreamReader reader = new StreamReader(inputStream)){
					string message = reader.ReadLine();
                    Console.WriteLine("Message from server:" + message);
                }
		Console.WriteLine();
                inputStream.Close();
				socket.Close();
            }
            catch(SocketException socketException){
                Console.WriteLine("SocketException: " + socketException.Message);
            }
            catch (System.Exception exception){
                Console.WriteLine("Exception: " + exception.Message);
            }
        }
    }
} 
