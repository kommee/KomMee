using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KomMee;
namespace KomMee_Tests
{
    public partial class MessageListViewTest : Form
    {
        public MessageListViewTest()
        {
            InitializeComponent();
            // Just for debuggin
            DataTable data = new DataTable();
            data.Columns.Add("smsID", typeof(int));
            data.Columns.Add("text", typeof(string));
            data.Columns.Add("senderAddress", typeof(string));
            data.Columns.Add("contactID", typeof(int));
            data.Columns.Add("isSent", typeof(int));
            data.Columns.Add("isRead", typeof(int));



            data.Rows.Add(0, "bla hkjsdf ansdljsd nlkddmsm", "bla@example.com", 12, 0, 1);
            MessageList msgList = MessageList.getInstance();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                msgList.Add(new SMSMessage(data));
            }

            foreach (SMSMessage sms in msgList)
            {
                this.messageListView1.LbChoice.Items.Add(sms);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyEventArgs key = new KeyEventArgs(Keys.Up);
            if (key.KeyValue == (int)Keys.Up)
            {
                this.messageListView1.up();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KeyEventArgs key = new KeyEventArgs(Keys.Down);
            if (key.KeyValue == (int)Keys.Down)
            {
                this.messageListView1.down();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
