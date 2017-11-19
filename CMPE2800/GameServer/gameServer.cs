/***********
*******************************************************************
* Name: Kevin gagarin
* Assignment : ICA1
* Date:Jan 27, 2016
* By Kevin Gagarin & Hima Panchal
*******************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace GameServer
{
    //SERVER 
    public partial class gameServer : Form
    {
        Socket _LSock = null; //listening socket

        Socket _CSock = null; //Connection Socket

        Thread _tRXThread = null;

        private delegate void delvoidSocketint(int i, Socket sok); //Unpacking the Received bytes from the socket

        private delegate void delVoidSocket(Socket sok); //Erro connection

        //private delegate void delVoidBAI(byte[] buff, int iCount);

        private delegate void delVoidVoid(); //check if its still connected 

        int ServerNum = 0; //Server num which generate the random num

        int CurGuess = 0; //The current state of guess - high/ low / equal

        Random rand = new Random(); //random num

        public gameServer()
        {
            InitializeComponent();
        }
        /******************************************************************************
        * Method: Form1_Load
        * Parameters: object sender
        * Purpose: First Connection made
        *******************************************************************************/
        private void Form1_Load(object sender, EventArgs e)
        {
            ServerNum = rand.Next(1, 1001);
            //Checks the connection between the client if its connected
            Console.WriteLine("The value to be guessed is: " + ServerNum);
            try
            {
                //create the socket
                _LSock = new Socket(
                            AddressFamily.InterNetwork,
                            SocketType.Stream,
                            ProtocolType.Tcp);

            }
            catch (SocketException er)
            {
                System.Diagnostics.Trace.WriteLine(er.Message);
            }

            try
            {
                //bind the listening socket to port
                _LSock.Bind(new IPEndPoint(IPAddress.Any, 1666));
            }
            catch (SocketException er)
            {
                System.Diagnostics.Trace.WriteLine(er.Message);
            }

            try
            {
                // start listening
                _LSock.Listen(5);
            }
            catch (SocketException er)
            {
                System.Diagnostics.Trace.WriteLine(er.Message);
            }

            try
            { 
                _LSock.BeginAccept(CBAcceptDone, _LSock);
            }
            catch(SocketException er)
            {
                System.Diagnostics.Trace.WriteLine(er.Message);
            }
        }

        /******************************************************************************
        * Method: CBAcceptDone
        * Parameters: IAsyncResult ar
        * Purpose: Check if connection is success or fail
        *******************************************************************************/
        private void CBAcceptDone(IAsyncResult ar)
        {
            Socket lsock = (Socket)ar.AsyncState;
           
            try
            {
                Socket ConnSock = lsock.EndAccept(ar);
                Invoke(new delVoidSocket(NewConnSortofMaybe), ConnSock);


            }
            catch (Exception err)
            {
                System.Diagnostics.Trace.WriteLine(err.Message);
                Invoke(new delVoidSocket(NewConnSortofMaybe), null);
            }
        }

        /******************************************************************************
        * Method: NewConnSortofMaybe
        * Parameters: Socket sock
        * Purpose: Checks the invoke if it fail or success and go through the Thread made
        *******************************************************************************/
        private void NewConnSortofMaybe(Socket sock)
        {
            if (sock == null)
            {
                MessageBox.Show("Connection Failed");
            }
            else
            {

                _CSock = sock;
                //Header format for the connection
                Text = "I have a connection at : " + sock.RemoteEndPoint.ToString();
                //if its connected - thread start for the activity
                //Thread is waiting after the connection is made
                _tRXThread = new Thread(TRXThread);
                _tRXThread.IsBackground = true;
                _tRXThread.Start(_CSock);
            }
        }
        private void CBLostConn()
        {
            MessageBox.Show("Lost connection!");
        }
        /******************************************************************************
        * Method: TRXThread 
        * Parameters: object obj
        * Purpose: While connected - checks if it received byte if not - goes throuh disconnect
        *******************************************************************************/
        private void TRXThread(object obj)
        {
            //while it still connect - checks if it received any byes 
            //from the client and unpacks it
            Socket sok = (Socket)obj;

            //buffer
            byte[] buff = new byte[2048];

            while (true)
            {   
                try
                {
                    //byte received from sender 
                    int iBytesRXed = sok.Receive(buff);

                    //soft Connection
                    if (iBytesRXed == 0)
                    {
                        Console.WriteLine("Lost connection!");

                        Invoke(new delVoidVoid(CBLostConn));

                        return;
                    }
                    else
                    {
                        //unpacking the bytes received and store it to memory
                        MemoryStream ms = new MemoryStream(buff);
                        
                        BinaryReader br = new BinaryReader(ms);
                        int iValue = br.ReadInt32();
                        //invokes the bytes from value and socket
                        Invoke(new delvoidSocketint(CBytes), iValue, sok);
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                    Invoke(new delVoidVoid(CBLostConn));

                    return;
                }
            }
        }
        /******************************************************************************
        * Method: Cbytes
        * Parameters: int i and Socket sok
        * Purpose: Checks the bytes recieve and returns to socket 0 , -1 1
        *******************************************************************************/
        private void CBytes(int i , Socket sok)
        {
            // reads the bytes received and check number guess and returns a ( 0 , -1 , 1)
            //Sending  a binary array
            //unpacking the bytes and sending 
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);
               
            Console.WriteLine("Value : " + i.ToString());
            
            //i is the client guess
            //i > servernum = return 1 which is number is high
            if (i > ServerNum)
            {
                CurGuess = 1;
                Console.WriteLine("1");
            }

            //i < servernum = return -1 which is number is low
            else if (i < ServerNum)
            {
                CurGuess = -1;
                Console.WriteLine("-1");
            }

            //i = servernum = return 0 which is number is right and generates new random server number
            else if (i == ServerNum)
            {
                CurGuess = 0;
                Console.WriteLine("0");
                //if client guess the number - this reset the server num and generate a new num
                ServerNum = rand.Next(1, 1001);
                Console.WriteLine("New number: " + ServerNum);
            }
            
            bw.Write(CurGuess);

            //saves it bytes and send it to client
            byte[] txtBuff = new byte[ms.Length];
            Array.Copy(ms.GetBuffer(), txtBuff, ms.Length);
            sok.Send(txtBuff);
        }
    }
}
