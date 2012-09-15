using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KomMee
{
    public abstract class Message
    {
        protected int id;

        public int Id
        {
            get { return id; }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private IViewContainer viewContainer;

        public IViewContainer ViewContainer
        {
            get { return viewContainer; }
            set { viewContainer = value; }
        }

        private string sender;

        public string Sender
        {
            get { return sender; }
            set { sender = this.validateSender(value); }
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

        private DateTime creationDate;

        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        public abstract bool send();

        public Message(object data)
        {
        }

        public Message(DataTable data)
        {

        }

        protected abstract string validateSender(string sender);

        public abstract void save();

        public abstract void delete();

        public override string ToString()
        {
            string shown_text = "";
            if(this.Contact == null)
                shown_text = string.Format("{0} - {1}", this.CreationDate.ToString("dd-MM-yyyy HH:mm"), this.Sender);
            else
                shown_text = string.Format("{0} - {1}", this.CreationDate.ToString("dd-MM-yyyy HH:mm"), this.Contact.ToString());
            return shown_text;
        }
    }
}
