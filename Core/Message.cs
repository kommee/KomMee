using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KomMee
{
    public abstract class Message
    {
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private IViewContainer viewContainer;

        internal IViewContainer ViewContainer
        {
            get { return viewContainer; }
            set { viewContainer = value; }
        }

        private string sender;

        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        private Contact contact;

        public Contact Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        private bool read;

        public bool Read
        {
            get { return read; }
            set { read = value; }
        }

        private bool sent;

        public bool Sent
        {
            get { return sent; }
            set { sent = value; }
        }

        public abstract bool send();

        // Muss vermutlich in ein Interface
        //public virtual static List<Message> recieve()
        //{
        //    throw new NotImplementedException();
        //}

        public Message(object data)
        {
        }

        public Message(DataTable data)
        {

        }
    }
}
