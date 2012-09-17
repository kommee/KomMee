using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace KomMee
{
    public class SMSAddress : Address
    {
        public SMSAddress(string address)
            :base(address)
        {
            DataTable data = new DataTable("SMS");
            data.Columns.Add("smsContactId", typeof(int));
            data.Columns.Add("address", typeof(string));
            data.Columns.Add("contactId", typeof(int));

            data.Rows.Add(0, address, 0);
            this.id = (data.Rows[0]["smsContactId"].ToString() == "") ? -1 : int.Parse(data.Rows[0]["smsContactId"].ToString());
            this.Address1 = data.Rows[0]["address"].ToString();
            this.ContactId = int.Parse(data.Rows[0]["contactId"].ToString());
        }

        public SMSAddress(DataRow data)
            :base(data)
        {
            this.id = (data["smsContactId"].ToString() == "")? -1 : int.Parse(data["smsContactId"].ToString());
            this.Address1 = data["address"].ToString();
            this.ContactId = int.Parse(data["contactId"].ToString());
        }

        public override void save()
        {
            SQL sqlInstance = SQL.getInstance();
            DataTable saveData = new DataTable("SMSContact");
            if (this.Id == -1)
            {
                saveData.Columns.Add("smsContactId", typeof(int));
                saveData.Columns.Add("address", typeof(string));
                saveData.Columns.Add("contactId", typeof(int));
                saveData.Rows.Add(this.Id, this.Address1, this.ContactId);
                this.id = sqlInstance.Insert(saveData);
            }
            else
            {
                saveData.Columns.Add("address", typeof(string));
                saveData.Columns.Add("contactId", typeof(int));
                saveData.Rows.Add(this.Address1, this.ContactId);
                sqlInstance.Update(saveData);
            }
        }

        public override void delete()
        {
            if (this.Id >= 0)
            {
                SQL sqlInstance = SQL.getInstance();
                DataTable saveData = new DataTable("SMS");
                saveData.Columns.Add("smsContactId", typeof(int));
                saveData.Rows.Add(this.Id);
                sqlInstance.Delete(saveData);
            }
        }
    }
}
