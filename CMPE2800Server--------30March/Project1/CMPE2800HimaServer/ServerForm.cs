/*  Author: Hima Panchal
 *  Date: March 30,2016
 *  Course: CMPE2800-Advanced C# Programming
 *  Stream :CNT
 *  Brief Description: Server built using dll class made by Edward which runs on bits.net.nait.ca and responds to the 
 *                     clients connected to the server
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CMPE2800EdwardJabarSocketEngine;
using mdtypes;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace CMPE2800HimaServer
{
    public partial class ServerForm : Form
    {
        //List of the Class SocketEngine listClients which will be connected to the server
        List<SocketEngine> listClients = null;
        SocketEngine connectedSocket = null;
        MemoryStream stream;
        BinaryFormatter bf;
        LineSegment line;
        byte[] bASend;
      
        //delegates used for Socket engine class
        public delegate void delVoidObj(object data);
        public delVoidObj dataReceive;
        public delegate void delVoidStringBool(string errorMessage, bool result);
        public delegate void delVoidSocket(Socket connectionSocket);

        int connectedClients = 0;       // variabe to keep track of the connectedclients
        double receivedFrames = 0;
        int fragments = 0;
        double average = 0;
        int receivedBytes = 0;
        int portNumber=0;

        double clientAverage;
        string clientIP;

        /********************************************************************************************
        //Property:  public int PortNum
        //Purpose:   Stores the port number and is used in calling the instance from the class.
        //********************************************************************************************/
        public int PortNum
        {
            set { portNumber = value; }
            get { return portNumber; }
        }
     
        public ServerForm()
        {
            InitializeComponent();
        }
        //********************************************************************************************
        //Method:       private void ServerForm_Load(object sender, EventArgs e)
        //Purpose:      During first form load
        //Parameters:   object sender
        //              EventArgs e
        //Returns:      nothing
        //*********************************************************************************************
        private void ServerForm_Load(object sender, EventArgs e)
        {
            //Initializing the List and which will contain the connected sockets
            listClients = new List<SocketEngine>();
            //initial value of the textboxPort
            tbPort.Text = "1666";
        }

        //********************************************************************************************
        //Method:       private void TransferToError(string connectionResult, bool result)
        //Purpose:      Displaying error in the Trace.Writeline
        //Parameters:   string connectionResult- to display the string ,bool result
        //Returns:      nothing
        //*********************************************************************************************
        private void TransferToError(string connectionResult, bool result)
        {
            //Just to 
            System.Diagnostics.Trace.WriteLine(connectionResult);
        }

        //********************************************************************************************
        //Method:       private void Error(string message, bool result)
        //Purpose:      Form displays the message to the user
        //Parameters:   string message- to display the message and bool result according to the class dll
        //Returns:      nothing
        //*********************************************************************************************
        private void Error(string message, bool reesult)
        {
            MessageBox.Show(message, "Connection Error!", MessageBoxButtons.OK);
        }

        //********************************************************************************************
        //Method:       private void ErrorList(Socket sock)
        //Purpose:      Displaying to the form via delegate by invoking 
        //Parameters:  Socket sock
        //Returns:      nothing
        //********************************************************************************************* /     
        private void ErrorList(Socket sock)
        {
            try
            {
                Invoke(new delVoidSocket(ErrorsAfter), sock);
            }
            catch (Exception err)
            {
                Console.WriteLine("Error detected: : " + err.Message);
            }
        }

        //********************************************************************************************
        //Method:       private void ErrorsAfter(Socket connection)
        //Purpose:      checking the dead sockets by traversing through the list and removing them by Remove method 
        //Parameters:   connection
        //Returns:      nothing
        //*********************************************************************************************/
        private void ErrorsAfter(Socket connection)
        {
            foreach (SocketEngine se in listClients)
            {
                bool badConn = se.CheckBadSockets(connection);
                if (badConn)
                {
                    //Remove the instance that contains the disconnected socket.
                    listClients.Remove(se);
                }
            }
            if (listClients.Count > 0)
                tbMessages.Text = "Removed dead Sockets " + connectedClients.ToString() + " clients remaining!";
            //if the list is empty and there are no sockets left then show 
            if (listClients.Count == 0)
                tbMessages.Text = "Connection ended or no sockets left";
        }


        //********************************************************************************************
        //Method:       private void TransferToAfterConnectionErrors(Socket connection)
        //Purpose:      Transfers from the thread context to the main form context.
        //Parameters:   Socket connection - Socket that has been disconnected.
        //Returns:      nothing
        //*********************************************************************************************

        private void TransferToConnectionErrors(Socket connection)
        {
            try
            {
                Invoke(new delVoidSocket(ConnectionSucceeded), connection);
            }
            catch (Exception err)
            {
                Console.WriteLine("Error detected: " + err.Message);
            }
        }
        //********************************************************************************************
        //Method:       private void ConnectionSucceeded(Socket connection)
        //Purpose:      Creating the connected sockets which uses 
        //Parameters:   Socket connection -connected socket to the client from server
        //Returns:      nothing
        //*********************************************************************************************
        private void ConnectionSucceeded(Socket connection)
        {
            connectedSocket = new SocketEngine(connection, new SocketEngine.delVoidStringBool(TransferToError),
                new SocketEngine.delVoidObj(TransferToProcessObject),
                new SocketEngine.delVoidSocket(ErrorList));
            listClients.Add(connectedSocket);



            //Display appropriate message depending on how many connections exist
            if (listClients.Count == 1)
                tbMessages.Text = "Connected to # " + listClients.Count + " client!";
            else
                tbMessages.Text = "Connected to- #" + listClients.Count + " clients!";
            
            buttonPort.Enabled = false;
        }

        //********************************************************************************************
        //Method:       private void TransferToProcessObject(object data)
        //Purpose:      Displaying to the form via delegate by invoking 
        //Parameters:   object data - The frame of data that was received from the client through
        //              the socket.
        //Returns:      nothing
        //*********************************************************************************************
        private void TransferToProcessObject(object data)
        {
            try
            {
                Invoke(new delVoidObj(ProcessingObject), data);
            }
            catch (Exception err)
            {
                Console.WriteLine("Error detected: " + err.Message);
            }
        }

        /********************************************************************************************
        Method:       private void TransferToError(string message, bool result)
        //Purpose:      Displaying to the form via delegate by invoking 
        //Parameters:   string message- displaying the message bool result-kept as alraedy 
                        used in the socket Engine class
        //Returns:      nothing
        //*********************************************************************************************/
        private void TranferToError(string message, bool result)
        {
            try
            {
                Invoke(new delVoidStringBool(Error), message, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Detected:",ex.Message);
            }
        }

        //********************************************************************************************
        //Method:       private void ProcessingObject(object data)
        //Purpose:      deetcting the data and then Serializing the type before sending it to the clients
        //Parameters:   object data - The frame of data received from the client
        //Returns:      nothing
        //*********************************************************************************************
        private void ProcessingObject(object data)
        {
            if (data is LineSegment)
            {
                line = (LineSegment)data;
                    foreach (SocketEngine sock in listClients)
                    {
                        //Creating new streams and bf, serializing the data so that it can be sent to 
                        //all the clients.
                        stream = new MemoryStream();
                        bf = new BinaryFormatter();
                        bf.Serialize(stream, line);
                        bASend = new byte[stream.Length];
                        Array.Copy(stream.GetBuffer(), bASend, stream.Length);
                        //Sending the data by Enquing it which is the property of SocketEngine Class
                        sock.EnqueueData(bASend, stream.Length);
                    }
            }
        }
        /********************************************************************************************
        //Method:       private string CalculationOfBytes(int totBytes)
        //Purpose:      by using the totBytes creating the string notation and using that to display the data on 
                        kilobytes and megabytes using String Format
        //Parameters:   int totBytes - which represents the number of bytes received by server and each client.
        //Returns:      nothing
        //*********************************************************************************************/
        private string CalculationOfBytes(int totBytes)
        {
            string notation;
            if (totBytes > 1000000)
                notation = String.Format("{0:f3}M",(double)(totBytes / (1048576)));
                
            else if (totBytes > 1000 && totBytes < 1000000)
                notation = String.Format("{0:f3}K", (double)totBytes / 1024);

            else
                notation = "Bytes RX'ed: " + totBytes;
            return notation;
        }


        /********************************************************************************************
         Method:       private void btnPort_CLick(object sender, EventArgs e)
         Purpose:      Will start listening for the socket connections and call the listener socket from the 
         *             class-Socket Engine dll.
         Parameters:   object sender,EventArgs e
         Returns:      nothing
        //*********************************************************************************************/
        private void buttonPort_Click(object sender, EventArgs e)
        {


            if (int.TryParse(tbPort.Text, out portNumber))
            {

                portNumber = int.Parse(tbPort.Text);
                PortNum = portNumber;
            }
            SocketEngine.CreateListenerSocket(PortNum, new SocketEngine.delVoidStringBool(TransferToError),
                new SocketEngine.delVoidSocket(TransferToConnectionErrors));
                
                tbMessages.Text = "Started Listening to the Socket Connections";
               // btnListen.Enabled = false;
           
        }

        //********************************************************************************************
        //Method:       private void timerTick_Tick(object sender, EventArgs e)
        //Purpose:      Updating the stats displayed every 50ms 
        //Parameters:  object sender,EventArgs e
        //Returns:      nothing
        //*********************************************************************************************
        private void timerTick_Tick(object sender, EventArgs e)
        {
            //clearing the listbox to make sure 
            listBoxDisplay.Items.Clear();
            double events;
            foreach (SocketEngine  sock in listClients)
            {
                clientIP = sock.GetIP();
                        if (sock.ReceiveEvents > 0)
                        {
                            
                            //from frames fromthe class
                            double frames = sock.Frames;
                            events = sock.ReceiveEvents;
                            //average on teh client side
                            clientAverage = frames / events;
                            listBoxDisplay.Items.Add("ClientIPAdrress:" + clientIP + "\n"  
                                + "Frames Received: " 
                                + sock.Frames + "\n " +  
                                "Fragments Received: " + sock.Fragments + " \n "
                                + "Total Destack Average" + clientAverage.ToString("F"));
                        }
                        
            }
            //frames received from the Client 
            receivedFrames = listClients.Sum(socket => socket.Frames);
            //fragments received from the Clients side
            fragments = listClients.Sum(socket => socket.Fragments);
            //Bytes received 
            receivedBytes = listClients.Sum(socket => socket.BytesReceived);
            events = listClients.Sum(socket => socket.ReceiveEvents);
            if (events > 0)
            {
                average = receivedFrames / events;
            }
            string totalbyteCount = CalculationOfBytes(receivedBytes);
            listBoxDisplay.Items.Add("Server: Total Bytes Received: "
                + totalbyteCount + "  " + "\n" + " - Total Frames Received: " +
                    receivedFrames + "\n" + " - Total Fragments Received: "
                    + fragments + "\n" + " - Total Destack Avg.: " +
                    average.ToString("F"));
        }
    }
}

   
