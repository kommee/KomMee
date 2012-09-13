using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KomMee
{
    public partial class MessageListView : KomMee.UctrlDialog
    {
        public MessageListView()
        {
            InitializeComponent();
            //List<Message> messages = Message.receive();
        }
    }
}
