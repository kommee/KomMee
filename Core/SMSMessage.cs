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

        public SMSMessage(DataRow data)
            : base(data)
        {
            AddressBook adr = AddressBook.getInstance();
            this.id = int.Parse(data["smsID"].ToString());
            this.Text = data["text"].ToString();
            this.Read = Convert.ToBoolean(data["isRead"]);
            this.Sent = Convert.ToBoolean(data["isSent"]);
            this.Sender = data["senderAddress"].ToString();
            this.CreationDate = new DateTime();
            CreationDate = DateTime.ParseExact(data["creationDate"].ToString(), "dd-MM-yyyy HH:mm", null);
            this.Contact = adr.getContact((int)data["contactID"]);
            this.ViewContainer = null;
            // TODO 
            // Implement the IViewContainer
        }

        public override bool send()
        {
            this.save();
            SIM card = SIM.getInstance();
            return card.sendMessage(this.Sender.ToString(), this.Text.ToString());
        }

        protected override string validateSender(string sender)
        {
            Regex r = new Regex("^[0-9]*$");
            if (r.IsMatch(sender))
                return sender;
            else
            {
                System.Windows.Forms.MessageBox.Show("Es dürfen nur Zahlen verwendet werden!", "Fehler beim setzen des Absenders.", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return "";
            }
        }

        public static void receive()
        {
            DataTable receivedMessages = new DataTable();
            SIM card = SIM.getInstance();
            MessageList msgList = MessageList.getInstance();

            if (receivedMessages.Rows.Count > 0)
            {
                for (int i = 0; i < receivedMessages.Rows.Count; i++)
                {
                    msgList.Add(new SMSMessage(receivedMessages.Rows[i]));
                }
            }
            receivedMessages = card.readMessages();

        }

        public override void save()
        {
            DataTable saveData = new DataTable("SMS");
            SQL sqlInstance = SQL.getInstance();
            if (this.Id > 0)
            {
                saveData.Columns.Add("smsID", typeof(int));
                saveData.Columns.Add("text", typeof(string));
                saveData.Columns.Add("senderAddress", typeof(int));
                saveData.Columns.Add("contactID", typeof(int));
                saveData.Columns.Add("isSent", typeof(int));
                saveData.Columns.Add("isRead", typeof(int));
                saveData.Rows.Add(this.Id, this.Text, this.Sender, this.Contact.Id, this.Sent, this.Read);
                sqlInstance.Insert(saveData);
            }
            else
            {
                saveData.Columns.Add("text", typeof(string));
                saveData.Columns.Add("senderAddress", typeof(int));
                saveData.Columns.Add("contactID", typeof(int));
                saveData.Columns.Add("isSent", typeof(int));
                saveData.Columns.Add("isRead", typeof(int));
                saveData.Rows.Add(this.Text, this.Sender, this.Contact.Id, this.Sent, this.Read);
                sqlInstance.Insert(saveData);
            }
        }

        public override void delete()
        {
            DataTable saveData = new DataTable("SMS");
            SQL sqlInstance = SQL.getInstance();
            if (this.Id > 0)
            {
                saveData.Columns.Add("smsID", typeof(int));
                saveData.Rows.Add(this.Id);
                sqlInstance.Insert(saveData);
            }
        }
    }
}
