using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace Server
{
    

    public partial class Form1 : Form
    {
        //???
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread server = new Thread(async_server);
            server.Start();
        }

        private void async_server()
        {
            byte[] bytes = new Byte[1024];

            Console.WriteLine("Server started!");

            //Creating local endpoint for listening, on any address.
            IPEndPoint localeEndPoint = new IPEndPoint(IPAddress.Any, 11000);

            //Creating the socket
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Binding the socket
            try
            {
                listener.Bind(localeEndPoint);
                listener.Listen(50);

                while (true)
                {
                    //?
                    allDone.Reset();

                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    //?
                    allDone.WaitOne();
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            //...not here
            //...not here
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
            Console.WriteLine("ReadCallBack STARTED!");
            String content = String.Empty;

            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            int bytesRead = handler.EndReceive(ar);
            state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
            Console.WriteLine(bytesRead);

            if (bytesRead > 0)
            {
                byte x = 2;
                content = state.sb.ToString();
                for (int i = 0; i < content.Length; i++)
                {
                    if (x == Convert.ToByte(content[i]))
                    {
                        //Special Key Found (Shift/Ctrl/Alt etc.)
                        Console.WriteLine("Special Key Found!");
                    }
                    else 
                    { 
                        //Letter/Symbol is found!
                        Console.WriteLine(content[i]);
                    }
                }    
            }
            handler.BeginReceive(state.buffer, 0, StateObject.bufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        private static void Send(Socket handler, string data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar) 
        { 
        
        }

        //Object for reading client data.
        public class StateObject {
            public Socket workSocket = null;
            public const int bufferSize = 1024;
            public byte[] buffer = new byte[bufferSize];
            public StringBuilder sb = new StringBuilder();
        }
    }
}
