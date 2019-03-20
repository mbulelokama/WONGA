using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apache.NMS;
using Apache.NMS.Util;
using SOA_Architecture;

namespace Queue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IObjectMessage objMessage;
            
            RequesterObject Request=new RequesterObject();
            Request.Requestproerty = textBox1.Text.ToString();

            IConnectionFactory factory=new NMSConnectionFactory("tcp://localhost/");
            IConnection connection = factory.CreateConnection();
            connection = factory.CreateConnection();
            connection.Start();
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            IDestination QueueDestination = SessionUtil.GetDestination(session, "Queue");
            IMessageProducer MessageProducer = session.CreateProducer(QueueDestination);
            objMessage = session.CreateObjectMessage(Request);
            MessageProducer.Send(objMessage);
            session.Close();
            connection.Stop();
        }
    }
}
