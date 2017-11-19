using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPE2800HimaPanchalICAMultidraw
{
    public partial class WindowConnection : Form
    {
        int portNumber;
        string addressLocation;

        public int Port
        {
            set {portNumber= value;}
            get{return portNumber;}
        }

        public string Address
        {
            set {addressLocation =value;}
            get {return addressLocation;}
        }
        public WindowConnection()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
             if (int.TryParse(textBoxPort.Text, out portNumber))
            {
                portNumber = int.Parse(textBoxPort.Text);
                Port = portNumber;
                Address = tbIPAddress.Text;
                DialogResult = DialogResult.OK;
                Close();

            }
            else
            {

            }
        
        }

        private void WindowConnection_Load(object sender, EventArgs e)
        {
            tbIPAddress.Text = "bits.net.nait.ca";
            textBoxPort.Text = "1666";
        }
    }
}
