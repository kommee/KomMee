using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KomMee
{
    public class MessageList : List<Message>
    {
        private static MessageList msgListInstance;

        private MessageList()
        {
            SQL sqlInstance = SQL.getInstance();
            DataTable data = new DataTable("SMS");
            data.Columns.Add("smsID", typeof(int));
            data.Columns.Add("text", typeof(string));
            data.Columns.Add("senderAddress", typeof(string));
            data.Columns.Add("contactID", typeof(int));
            data.Columns.Add("isSent", typeof(int));
            data.Columns.Add("isRead", typeof(int));
            data.Columns.Add("creationDate", typeof(string));
            
            try
            {
                sqlInstance.Read(data);
                if (data.Rows.Count > 0)
                {
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        this.Add(new SMSMessage(data.Rows[i]));
                    }
                }
            }
            catch (Exception e)
            {

            }

            data.Rows.Add(1, "test eintragf mdmcocclödcmdklsdlklklsd", "0176442228", 8, 0, 1, DateTime.Now.ToString("dd-MM-yyyy HH:mm"));
            this.Add(new SMSMessage(data.Rows[0]));
        }

        public static MessageList getInstance()
        {
            if (MessageList.msgListInstance == null)
                MessageList.msgListInstance = new MessageList();
            return MessageList.msgListInstance;
        }

        public DataTable getDatasource()
        {
            DataTable data = new DataTable("Messages");
            data.Columns.Add("MessageID", typeof(int));
            data.Columns.Add("Name", typeof(string));
            if (this.Count > 0)
            {
                foreach (Message msg in this)
                {
                    data.Rows.Add(msg.Id, msg.ToString());
                }
            }
            return data;
        }
    }
}
