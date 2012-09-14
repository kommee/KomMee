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
            MessageList msgList = MessageList.getInstance();

            // Add the Messages to list 
            foreach(Message msg in msgList)
            {
                this.LbChoice.Items.Add(msg);
            }

            // Select the first entry
            if (this.LbChoice.Items.Count > 0)
            {
                if (this.LbChoice.SelectedIndex < 0)
                {
                    this.LbChoice.SelectedIndex = 0;
                }
                this.LbChoice.Select();
            }
        }

        /// <summary>
        /// Call from Key apply
        /// </summary>
        public override void apply()
        {
            base.apply();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void cancel()
        {
            base.cancel();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void down()
        {
            if (this.LbChoice.Items.Count > 0)
            {
                if (this.LbChoice.SelectedIndex >= this.LbChoice.Items.Count - 1)
                {
                    this.LbChoice.SelectedIndex = 0;
                }
                else
                {
                    this.LbChoice.SelectedIndex += 1;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void left()
        {
            // Do nothing
        }

        /// <summary>
        /// 
        /// </summary>
        public override void right()
        {
            // Do nothing
        }

        /// <summary>
        /// 
        /// </summary>
        public override void up()
        {
            if (this.LbChoice.Items.Count > 0)
            {
                if (this.LbChoice.SelectedIndex <= 0)
                {
                    this.LbChoice.SelectedIndex = this.LbChoice.Items.Count - 1;
                }
                else
                {
                    this.LbChoice.SelectedIndex -= 1;
                }
            }
        }
    }
}
