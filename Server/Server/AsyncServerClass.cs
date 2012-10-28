using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class AsyncServerClass
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        private static int port;
        

        public AsyncServerClass()
        {
            //generating random port number > 1000
            Random number = new Random();
            port = number.Next(100) * 100 + number.Next(100);
            if (port < 1000) port = port * 10;
        }

        public static int GetPort()
        {
            return port;
        }

        public void Start()
        {
            Thread server = new Thread(AsyncServer);
            server.Start();
        }

        private void AsyncServer()
        {
            byte[] bytes = new Byte[1024];

            Console.WriteLine("Server is up and running!");

            //Creating local endpoint for listening, on any address.
            IPEndPoint localeEndPoint = new IPEndPoint(IPAddress.Any, port);

            //Creating the socket
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Binding the socket
            try
            {
                listener.Bind(localeEndPoint);
                listener.Listen(50);

                while (true)
                {
                    allDone.Reset();

                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    
                    allDone.WaitOne();
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public static void AcceptCallback(IAsyncResult ar) 
        {
            Console.WriteLine("Connection Incoming!");
            allDone.Set();

            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            //Creating object for the accepted socket
            StateObject state = new StateObject();
            state.workSocket = handler;
            //Starts reading information from the socket.
            handler.BeginReceive(state.buffer, 0, StateObject.bufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar) {
            //Decoding data received from socket to make the proper input.
            String content = String.Empty;

            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            int bytesRead = handler.EndReceive(ar);
            state.sb.Clear();
            state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
            //Console.WriteLine(bytesRead);
            if (bytesRead > 0)
            {
                //Code used in order to manage exceptional keys and mouse movements;
                //The bite is a prefix in the received message.
                //No prefix = normal key press.
                byte special = 2;
                byte mouse = 3;
                content = state.sb.ToString();
                for (int i = 0; i < content.Length; i++)
                {
                    if (special == Convert.ToByte(content[i]))
                    {
                        //Special Key Found (Shift/Ctrl/Alt etc.)
                        i++;
                        ContentManager.ShowSpecialKey(content[i]);
                    }
                    else if (mouse == Convert.ToByte(content[i]))
                    {
                        //Interpreting all the contet received on socket
                        for (int j = 0; j < content.Length / 9; j++)
                            ContentManager.MouseCommand(GetXFromContent(content.Substring(j * 9 + 1,4)),
                                GetYFromContent(content.Substring(j * 9 + 5,4)));
                        //Jumping over the mouse command to the next input
                        i = i + content.Length;
                    }
                    else
                    {
                        //Letter/Symbol is found!
                        ContentManager.ShowSymbol(content[i]);
                    }
                }
                //Reading the next input
                handler.BeginReceive(state.buffer, 0, StateObject.bufferSize, 0, new AsyncCallback(ReadCallback), state);
            }
            else 
            {
                //No byte read => socket error => closing
                handler.Close();
            }
            
        }

        //Object for reading client data.
        public class StateObject {
            public Socket workSocket = null;
            public const int bufferSize = 1024;
            public byte[] buffer = new byte[bufferSize];
            public StringBuilder sb = new StringBuilder();
        }

        //Converting mouse coordinates from string to int
        public static int GetXFromContent(String content)
        {
            if (content.IndexOf('-') == -1)
            {
                return Convert.ToInt32(content);
            }
            else
            {
                content = content.Replace('-', '0');
                return Convert.ToInt32(content) * (-1);
            }
        }

        public static int GetYFromContent(String content)
        {
            if (content.IndexOf('-') == -1)
            {
                return Convert.ToInt32(content);
            }
            else
            {
                content = content.Replace('-', '0');
                return Convert.ToInt32(content) * (-1);
            }
        }
    }
}
