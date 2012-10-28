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
using WindowsInput;


namespace Server
{
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Searching for the local IP addreses.
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    Console.WriteLine(localIP);
                }
            }

            AsyncServerClass server = new AsyncServerClass();
            server.Start();
            //writing it on a label in the GUI
            label1.Text = "IP: " + localIP + "          Port: " + Convert.ToString(AsyncServerClass.GetPort());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.BalloonTipTitle = "MobileKeyboard Hidden!";
                notifyIcon1.BalloonTipText = "DoubleClick to restore the main window.";
                notifyIcon1.ShowBalloonTip(3000);                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed by\nMaiorescu Ioan & Vlad Bogdan\n@ 10.2012 Hackathon.ro","About");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To manually find your ip, run <cmd>, the ipconfig command and find your local IP address among your active network connections", "Help");
        }
    }
}
