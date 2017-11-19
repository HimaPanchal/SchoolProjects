using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net;


namespace CMPE2800HimaPanchalSocket
{
    public class SockStuff
    {
        int destackedFrames = 0;
        int totalBytes = 0;
        int numberOfFragments = 0;
        Socket _sock = null;
        static Socket listenerSock = null;
        Thread ReceiveData = null;
        Thread ProcessData = null;
        delegate void delVoidStringBool(string connectionResult, bool result);
        public delegate void delVoidObj(object data);
        delVoidStringBool connectionResult;
        delVoidObj objData;
        Queue<object> qObjectReceived = null;
        Queue<byte[]> qByteSend = null;
        Queue<int> qintLength = null;
        public int Frames;

        public int Frames
        {
            get { return destackedFrames; }
            set { destackedFrames = value; }
        }
        public int BytesReceived
        {
            get { return totalBytes; }
            set { totalBytes = value; }
        }

        public int Fragments
        {
            get { return numberOfFragments; }
            set { numberOfFragments = value; }
        }

        public int ReceiveEvents
        {
            _sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            dataReceived = new Queue<object>();
            dataSend = new Queue<byte[]>();
            dataLengths = new Queue<int>();
            connectionResult = connectionCheck;
            error = errorProcess;
            getData = dataProcess;
            ReceiveData = new Thread(ReceivingData);
            ProcessData = new Thread(ProcessingData);
            SendData = new Thread(SendingData);
            ReceiveData.IsBackground = true;
            SendData.IsBackground = true;
            ProcessData.IsBackground = true;
            ProcessData.Start();
            ReceiveData.Start();
            SendData.Start();
           
        }
        public SockStuff()
        {
            listenerSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
            qObjectReceived = new Queue<object>();
            ReceiveData = new Thread(Receiving);
            ReceiveData.IsBackground = true;
        }

        public SockStuff(delVoidStringBool error,delVoidObj receiver)
        {
            qObjectReceived = new Queue<object>();
            qByteSend = new Queue<byte[]>();
            qintLength = new Queue<int>();
            
            ReceiveData = new Thread(Receiving);
            ProcessData = new Thread(ProcessingData);
            ReceiveData.IsBackground = true;
            ProcessData.IsBackground = true;

        }

        public void BeginConnect(string IPAddress, int port)
        {
            try
            {
                _sock.BeginConnect(IPAddress, port, CBConnectDone, _sock);
            }
            catch (Exception err)
            {
                connectionResult("Could not connect to server!\n" + err.Message, false);
            }
        }

        public void CBConnectDone(IAsyncResult ar)
        {
            Socket sok = (Socket)ar.AsyncState;
            try
            {
                sok.EndConnect(ar);
                connectionResult("Connected to server!", true);
            }
            catch (Exception err)
            {
                connectionResult("Could not connect to server!\n" + err.Message, false);
            }
        }

        public void Receiving()
        {
            byte[] buffer = new byte[20004];
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            while(true)
            {
                try
                {
                    int iBytes = 0;
                    iBytes = _sock.Receive(buffer);

                    if(iBytes==0)
                    {
                        _sock.Shutdown(SocketShutdown.Both);
                        _sock.Close();
                    }
                    else
                    {
                        long lPos = ms.Position;
                        ms.Seek(0, SeekOrigin.End);
                        ms.Write(buffer, 0, iBytes);
                        ms.Position = lPos;
                        do
                        {
                           long lStartPos = ms.Position;
                            try
                            {
                                object ob = bf.Deserialize(ms);
                                ReceiveEvents++;

                                //add this frame to the queue of received frames assume
                                //another thread will process the frames
                                lock(qObjectReceived)
                                {
                                    qObjectReceived.Enqueue(ob);
                                }
                            }
                            catch(SerializationException)
                            {
                                ms.Position = lStartPos;
                                break;
                            }
                            }
                        while (ms.Position < ms.Length);

                        if (ms.Position == ms.Length)
                        {
                            ms.Position = 0;
                            ms.SetLength(0);
                        }

                        }
                       
                    }
               
                catch(Exception err)
                {
                    break;
                }
            }
        }
        public void ProcessingData()
        {
            object data = null;
            while(true)
            {
                if(qObjectReceived.Count==0|| qObjectReceived==null)
                {
                    Thread.Sleep(1);
                }
                else
                {
                    lock(qObjectReceived)
                    {
                        data = qObjectReceived.Dequeue();
                    }
                    objData(data);
                    
                }
            }
        }

        public void EnqueueData(byte[] data, long length)
        {
            lock(qByteSend)
            {
                qByteSend.Enqueue(data);
            }
            lock(qintLength)
            {
                qintLength.Enqueue((int)length);
            }
        }

        public void SendingData(MemoryStream ms)
        {
            _sock.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
        }
    }
}
