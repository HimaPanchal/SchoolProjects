using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMPE2800EdwardJabarSocketEngine;
using mdtypes;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Threading;


namespace Project1
{
    public partial class Server : Form
    {

        List<SocketEngine> listSock = null;
        SocketEngine _conSock = null;
        MemoryStream ms = null;
        BinaryFormatter bf = null;
        LineSegment linesegment;
        int fragments = 0;


        public Server()
        {
            InitializeComponent();
        }

        private void buttonPort_Click(object sender, EventArgs e)
        {

        }

        private void Server_Load(object sender, EventArgs e)
        {
        
        }
    }
}
