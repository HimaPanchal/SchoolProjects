using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using CMPE2800EdwardJabarSocketEngine;
using mdtypes;
using System.Net;
using System.Net.Sockets;

namespace CMPE2800HimaPanchalICAMultidraw
{

    public partial class Form1 : Form
    {
            public delegate void delVoidBoolString(bool bIsConnected, string sMessage);
            SocketEngine _sock;
            bool connected = false;
            WindowConnection winConn;
            int port;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbServerCommunication.Text = "Please connect to the server";
        }

        private void tbServerCommunication_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainConnectionDone(bool bIsConnected,string sMessage)
        {
            try
            {
                Invoke(new delVoidBoolString(ConnectionDone),bIsConnected, sMessage);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"FAILED CONNECTION");
            }

        }
     
        private void ConnectionDone(bool bIsConnected, string sMessage)
        {
            if(bIsConnected)
            {

            }
            else
            {

            }
        }

        private void MainProcess(object data)
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
        }

        private void ProcessObject(object data)
        {
           if(data is LineSegment)
           {
               tsFragments.Text = "Frames RX ed : " + _sock.Frames;
               tsFragments.Text = "Fragments RX ed " + _sock.Fragments;
               if(_sock.BytesReceived !=0)
               {
                   double frame = _sock.Frames;
                   double events = _sock.BytesReceived;


                  // double average = frame / events;
                   //tsAverage.Text = "Destack Avg :" + average.ToString("F");
               }
           }

           LineSegment lineS = (LineSegment)data;
            using(Graphics gr = CreateGraphics())
            {
                lineS.Render(gr);
            }
        }

        private void stsStatus_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsConnect_Click(object sender, EventArgs e)
        {
            winConn = new WindowConnection();
            if(winConn.ShowDialog() == DialogResult.OK)
            {
                port = winConn.Port;
            }
        }
    }
}
