using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Reflection;


namespace KomMee
{
    /// <summary>
    /// 
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// The Contact id
        /// </summary>
        private int id;

        /// <summary>
        /// The Contact id
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// The firstname of a contact
        /// </summary>
        private string firstname;

        /// <summary>
        /// The firstname of a contact
        /// </summary>
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        /// <summary>
        /// The lastname of a contact
        /// </summary>
        private string lastname;

        /// <summary>
        /// The lastname of a contact
        /// </summary>
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        /// <summary>
        /// The default address
        /// </summary>
        private Address defaultAddress;

        /// <summary>
        /// The default address
        /// </summary>
        public Address DefaultAddress
        {
            get { return defaultAddress; }
            set { defaultAddress = value; }
        }

        private int messageTypeID;

        public int MessageTypeID
        {
            get { return messageTypeID; }
            set { messageTypeID = value; }
        }

        /// <summary>
        /// The type of a contact
        /// /// </summary>
        private Dictionary<string, Address> contactTypes;

        /// <summary>
        /// The type of a contact
        /// /// </summary>
        public Dictionary<string, Address> ContactTypes
        {
            get { return contactTypes; }
            set { contactTypes = value; }
        }

        /// <summary>
        /// Creates a contact out of his firstname and his lastname.
        /// </summary>
        /// <param name="pFirstname">The firstname of a contact</param>
        /// <param name="pLastname">The lastname of a contact</param>
        public Contact(string pFirstname, string pLastname)
        {
            if (pFirstname.Trim().Length == 0)
            {
                throw new Exception("The firstname is empty.");
            }
            else if (pFirstname.Trim().Length == 0)
            {
                throw new Exception("The lastname is empty.");
            }

            this.id = 0;
            this.messageTypeID = 0;
            this.firstname = pFirstname;
            this.lastname = pLastname;
            this.ContactTypes = new Dictionary<string, Address>();

        }

        /// <summary>
        ///  Creates a contact out of his id, his firstname and his lastname
        /// </summary>
        /// <param name="pId">The contat-ID</param>
        /// <param name="pFirstname">The firstname of a contact</param>
        /// <param name="pLastname">The lastname of a contact</param>
        public Contact(DataRow data, List<DataTable> tableList)
        {
            this.id = int.Parse(data["contactID"].ToString());
            this.Firstname = data["firstName"].ToString();
            this.Lastname = data["lastName"].ToString();
            this.messageTypeID = int.Parse(data["messageTypeID"].ToString());

            // set Addresses
            this.contactTypes = new Dictionary<string, Address>();
            foreach (DataTable dt in tableList)
            {
                switch(dt.TableName)
                {
                    case "SMSContact": // set SMSAdresse
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (this.Id == int.Parse(dt.Rows[i]["contactID"].ToString()))
                            {
                                this.contactTypes.Add(dt.Rows[i]["address"].ToString(), new SMSAddress(dt.Rows[i]));
                            }
                        }
                        break;
                    case "EMailContact":
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (this.Id == int.Parse(dt.Rows[i]["contactID"].ToString()))
                            {
                                this.contactTypes.Add(dt.Rows[i]["address"].ToString(), new EMailAddress(dt.Rows[i]));
                            }
                        }
                        break;
                    case "messageType": // has to be done later
                        break;
                    default:
                        throw new Exception("Unknown tablename.");
                }
            }

            foreach (DataTable dt in tableList)
            {
                switch (dt.TableName)
                {
                    case "messageType":
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (int.Parse(data["messageTypeID"].ToString()) == int.Parse(dt.Rows[i]["messageTypeID"].ToString()))
                            {
                                foreach (var addr in this.contactTypes)
                                {
                                    if (addr.Value.GetType().Equals(Type.GetType(dt.Rows[i]["className"].ToString())))
                                    {
                                        this.defaultAddress = addr.Value;
                                    }
                                }
                            }
                        }
                        break;
                    case "SMSContact":
                    case "EMailContact":
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// save the Contactobject to the save-file. Is the Id empty, it will create a new entry.
        /// </summary>
        public bool saveContact()
        {
            bool error = false;
            if (this.Id == 0)
            {
                this.Insert();
                error = true;
            }
            else
            {
                error = this.Update();
            }

            return error;
        }

        /// <summary>
        /// Deletes a contact
        /// </summary>
        /// <returns>true if it was succesful, else false</returns>
        public bool deleteContact()
        {
            return this.Delete();
        }

        /// <summary>
        /// Insert the contact into the database
        /// </summary>
        /// <returns>the new contact-ID</returns>
        private int Insert()
        {
            SQL sqlInstance = SQL.getInstance();
            DataTable saveContactData = new DataTable("Contact");
            saveContactData.Columns.Add("firstName", typeof(string));
            saveContactData.Columns.Add("lastName", typeof(string));
            saveContactData.Columns.Add("messageTypeID", typeof(int));

            saveContactData.Rows.Add(this.Firstname,this.Lastname,this.messageTypeID);
            this.id = sqlInstance.Insert(saveContactData);
            
            // save the Adresses
            if(this.contactTypes.Count > 0)
            {
                foreach(var addr in this.ContactTypes)
                {
                    if (this.ContactTypes[addr.Key].ContactId == 0)
                    {
                        this.ContactTypes[addr.Key].ContactId = this.id;
                    }
                    this.ContactTypes[addr.Key].save();
                }
            }

            return 0;
        }

        /// <summary>
        /// Updates the contactinformation
        /// </summary>
        /// <returns>true if it was succesful, else false</returns>
        private bool Update()
        {
            SQL sqlInstance = SQL.getInstance();
            DataTable saveContactData = new DataTable("Contact");
            saveContactData.Columns.Add("contactID", typeof(int));
            saveContactData.Columns.Add("firstName", typeof(string));
            saveContactData.Columns.Add("lastName", typeof(string));
            saveContactData.Columns.Add("messageTypeID", typeof(int));
            saveContactData.Rows.Add(this.Id, this.Firstname, this.Lastname, this.messageTypeID);
            this.id = sqlInstance.Insert(saveContactData);
            // save the Adresses
            if (this.contactTypes.Count > 0)
            {
                foreach (var addr in this.ContactTypes)
                {
                    addr.Value.save();
                }
            }
            return true;
        }

        /// <summary>
        /// Deletes a contact from the database
        /// </summary>
        /// <returns>true if it was succesful, else false</returns>
        private bool Delete()
        {
            SQL sqlInstance = SQL.getInstance();
            DataTable saveContactData = new DataTable("Contact");
            saveContactData.Columns.Add("contactID", typeof(int));
            saveContactData.Rows.Add(this.Id);

            // first delete  the Adresses
            if (this.contactTypes.Count > 0)
            {
                foreach (var addr in this.ContactTypes)
                {
                    addr.Value.delete();
                }
            }

            sqlInstance.Delete(saveContactData);
            
            return true;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", this.Lastname, this.Firstname);
        }

        public void removeAddresFromList(string listIndex)
        {
            if(this.contactTypes.ContainsKey(listIndex))
            {
                this.contactTypes[listIndex].delete();
                this.contactTypes.Remove(listIndex);
            }
        }
    }
}
