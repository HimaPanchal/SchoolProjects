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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameClient
{
    public partial class gameClient : Form
    {

        Socket _sok = null;

<<<<<<< .mine
        Thread worker = null; //worker thread 
       
      
=======
        Thread worker = null;
        private delegate void delVoidBoolString(bool bResult, string sMessage);

>>>>>>> .r103
        public delegate void delVoidInt(int s);
        private delegate void delVoidBool(bool b);

        int iGuess = 0;
        bool winning = false;


        public gameClient()
        {
            InitializeComponent();

        }
       
      
        private void gameClient_Load(object sender, EventArgs e)
        {
            textBoxDisplay.Text = "PICK a NUMBER and Hit Guess";
            trackBarGuess.Minimum = 1;
            trackBarGuess.Maximum = 1000;
            textBoxMinimum.Text = "1";
            textBoxMaximum.Text = "1000";
            buttonGuess.Enabled = false;
            textBoxIPAddress.Text = "localhost";
        }


        private void CBConnectDone(IAsyncResult ar)
        {
            Socket sok = (Socket)ar.AsyncState;     //pass socket object
           
            //End the connection attempt
            try
            {
                sok.EndConnect(ar);                 
                
            }
            catch (Exception err)
            {
                System.Diagnostics.Trace.WriteLine(err.Message);
               

            }
        }

        private void buttonGuess_Click_1(object sender, EventArgs e)
        {
<<<<<<< .mine
            
=======
>>>>>>> .r103
            winning = int.TryParse(textBoxCorrect.Text, out iGuess);
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write(iGuess);
            byte[] bufferGuess = new byte[ms.Length];
            Array.Copy(ms.GetBuffer(),bufferGuess,ms.Length);
            try
            {
                _sok.Send(bufferGuess);
            }
            catch(Exception err)
            {
                System.Diagnostics.Trace.WriteLine(err.Message);
            }

            foreach(byte bbufGuess in bufferGuess)
                Console.WriteLine(bbufGuess.ToString("X2"));

            worker = new Thread(RecycleData);       //worker thread target to RecycleData method
            worker.IsBackground = true;            //
            worker.Start();                       //starting worker thread

          

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (_sok == null || !_sok.Connected)
                try
                {

                    //Build the socket 
                    _sok = new Socket(AddressFamily.InterNetwork,//IP V4 address scheme
                        SocketType.Stream,                      //streaming socket (connection based)
                        ProtocolType.Tcp);                      //using TCP as protocol

                    //Starting the connection attempt
    
                    _sok.BeginConnect(textBoxIPAddress.Text, 1666, CBConnectDone, _sok);
                    Text = "Connected: " + textBoxIPAddress.Text;

                 
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.Message, "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                }
            buttonGuess.Enabled = true;         //button Guess is Enabled
        }

        private void trackBarGuess_Scroll(object sender, EventArgs e)
        {
            textBoxCorrect.Text = trackBarGuess.Value.ToString();
        }


        private void cbAccept(bool bIsConnected, string sMessage)
        {
            if (bIsConnected)
            {
                labelStatus.Text = "Accepted Successfully";
            }
            else
            {
                labelStatus.Text = "cbAccept: " + sMessage;
            }
        }
       
        private void RecycleData()
        {
            while(true)
            {
                byte[] textBuff = new byte[2048];
                int receiveData = 0;

                try
                {
                    receiveData = _sok.Receive(textBuff);
                    if(receiveData==0)
                    {
                        return;
                    }

                    else
                    {
                        byte[] answer = new byte[receiveData];
                        Array.Copy(textBuff, answer, receiveData);
                        MemoryStream ms = new MemoryStream(answer);
                        BinaryReader br = new BinaryReader(ms);
                        int ivalue = br.ReadInt32();
                        Invoke(new delVoidInt(DisplayRxData),ivalue);
                    }
                    //port forwarding will help 
                }
                catch(Exception)
                {

                }
            }

        }

        private void DisplayRxData(int message)
        {
            //if the guessed number is lower than the expected Number
            if (message == -1)
            {
                textBoxDisplay.Text = "Number is too low!!";
                trackBarGuess.Minimum = trackBarGuess.Value + 1;
                textBoxMinimum.Text = trackBarGuess.Minimum.ToString();
                textBoxCorrect.Text = trackBarGuess.Minimum.ToString();
            }
            
            //if the guessed number is greater than the expected Number
            else if (message == 1)
            {
                textBoxDisplay.Text = "Number is too high";
                trackBarGuess.Maximum = trackBarGuess.Value - 1;
                textBoxMaximum.Text = trackBarGuess.Maximum.ToString();
                trackBarGuess.Text = trackBarGuess.Maximum.ToString();
            }

            //if the guess is guessed correctly and it matches the server's guess
            else
            {
                textBoxDisplay.Text = "Right Guess!!";
                trackBarGuess.Minimum = 1;
                trackBarGuess.Value = 500;
                trackBarGuess.Maximum = 1000;
                textBoxMinimum.Text = trackBarGuess.Minimum.ToString();
                textBoxMaximum.Text = trackBarGuess.Maximum.ToString();
                textBoxCorrect.Text = trackBarGuess.Value.ToString();


            }
        }

      
    }
}

         

