using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        internal Contact Contact
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
        //public abstract static List<Message> recieve();

        public Message(object data)
        {
        }
    }
}
