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
            DataTable saveData = new DataTable("SMS");
            SQL sqlInstance = SQL.getInstance();
            saveData.Columns.Add("text", typeof(string));
            saveData.Columns.Add("senderAddress", typeof(string));
            saveData.Columns.Add("contactID", typeof(int));
            saveData.Columns.Add("isSent", typeof(int));
            saveData.Columns.Add("isRead", typeof(int));
            saveData.Rows.Add(this.Text, this.Sender, this.Contact.Id, this.Sent, this.Read);
            sqlInstance.Insert(saveData);

            return true;
        }

        public override string ToString()
        {
            string shown_text = string.Format("{0} - {1}", this.CreationDate.ToString("dd-MM-yyyy HH:mm"), this.Text);
            return shown_text;
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
