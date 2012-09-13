using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

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
            this.id = int.Parse(data.Rows[0]["smsID"].ToString());
            this.Text = data.Rows[0]["text"].ToString();
            this.Read = Convert.ToBoolean(data.Rows[0]["isRead"]);
            this.Sent = Convert.ToBoolean(data.Rows[0]["isSent"]);
            this.Sender = data.Rows[0]["senderAddress"].ToString();
            this.CreationDate = new DateTime();
            CreationDate = DateTime.ParseExact(data.Rows[0]["creationDate"].ToString(), "dd-MM-yyyy HH:mm", null);
            this.Contact = adr.getContact((int)data.Rows[0]["contactID"]);
            
            // TODO 
            // Implement the IViewContainer
        }

        public override bool send()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string shown_text = string.Format("{0} - {1}",this.CreationDate.ToString("dd-MM-yyyy HH:mm"),this.Text);
            return shown_text;
        }

        protected override string validateSender(string sender)
        {
            Regex r = new Regex("^[0-9]*$");
            if(r.IsMatch(sender))
                return sender;
            else
            {
                System.Windows.Forms.MessageBox.Show("Es dürfen nur Zahlen verwendet werden!", "Fehler beim setzen des Absenders.", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Error);
                return "";
            }
        }
    }
}
