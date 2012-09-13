using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KomMee
{
    public class SMSMessage : Message
    {
        public SMSMessage(object data)
            : base(data)
        {
        }

        public SMSMessage(DataTable data)
            : base(data)
        {
            AddressBook adr = AddressBook.getInstance();
            this.Text = data.Rows[0]["text"].ToString();
            this.Read = Convert.ToBoolean(data.Rows[0]["isRead"]);
            this.Sent = Convert.ToBoolean(data.Rows[0]["isSent"]);
            this.Sender = data.Rows[0]["senderAddress"].ToString();
            this.Contact = adr.getContact((int)data.Rows[0]["contactID"]);
        }

        public override bool send()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string shown_text = string.Format("{0} - {1}",this.Sender,this.Text);
            return shown_text;
        }
    }
}
