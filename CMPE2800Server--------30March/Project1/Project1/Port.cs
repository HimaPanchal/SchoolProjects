using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Port : Form
    {
        int portNumber;
        public Port()
        {

            InitializeComponent();
        }

        public int MyPort { get{return portNumber;} set{portNumber = value;} }
        private void Port_Load(object sender, EventArgs e)
        {
            textBoxPort.Text = "1666";
        }

        private void buttonListening_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBoxPort.Text,out portNumber))
            {
                portNumber = int.Parse(textBoxPort.Text);
                MyPort = portNumber;
                DialogResult = DialogResult.OK;
                Close();
                
            }
            else
            {
                MessageBox.Show("The port is not valid number", "port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
