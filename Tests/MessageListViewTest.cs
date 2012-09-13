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
            DataTable data;
            //MessageList msgList = KomMee.M
            for (int i = 0; i <= 3; i++)
            {
                //this.Add(new )
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
