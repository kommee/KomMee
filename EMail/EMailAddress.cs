using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KomMee
{
    public class EMailAddress : Address
    {

        public EMailAddress(DataRow data)
            :base(data)
        {
            this.id = (data["smsContactId"].ToString() == "") ? -1 : int.Parse(data["smsContactId"].ToString());
            this.Address1 = data["address"].ToString();
            this.contactId = int.Parse(data["contactId"].ToString());
        }
        public override void save()
        {
            SQL sqlInstance = SQL.getInstance();
            DataTable saveData = new DataTable("EmailContact");
            if (this.Id == -1)
            {
                saveData.Columns.Add("EmailContactId", typeof(int));
                saveData.Columns.Add("address", typeof(string));
                saveData.Columns.Add("contactId", typeof(int));
                saveData.Rows.Add(this.Id, this.Address1, this.contactId);
                this.id = sqlInstance.Insert(saveData);
            }
            else
            {
                saveData.Columns.Add("address", typeof(string));
                saveData.Columns.Add("contactId", typeof(int));
                saveData.Rows.Add(this.Address1, this.contactId);
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
