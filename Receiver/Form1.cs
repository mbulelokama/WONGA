using Apache.NMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apache.NMS.Util;
using Apache.NMS;
using SOA_Architecture;

namespace Receiver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void receiver()
        {
            IConnectionFactory factory = new NMSConnectionFactory("tcp//localhost");
            IConnection connection = factory.CreateConnection();
            connection = factory.CreateConnection();
            connection.Start();
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            IDestination QueueDestination = SessionUtil.GetDestination(session, "Queue");
            IMessageProducer MessageProducer = session.CreateProducer(QueueDestination);
        }

        private void MessageListener(IMapMessage message)
        {
            IObjectMessage objectMessage= message as IObjectMessage;
            RequesterObject requesterObject = ((SOA_Architecture.RequesterObject) (objectMessage.Body));
            MessageBox.Show(requesterObject.Requestproerty);

        }
    }
}
