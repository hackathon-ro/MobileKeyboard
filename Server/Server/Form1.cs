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
            AsyncServerClass server = new AsyncServerClass();
            server.Start();
        }
    }
}
