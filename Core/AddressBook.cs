using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace KomMee
{
    /// <summary>
    /// Implemnts a list of contacts
    /// </summary>
    public class AddressBook
    {
        /// <summary>
        /// List of Contacts the user has.
        /// </summary>
        private Dictionary<int, Contact> listOfContacts;

        /// <summary>
        /// List of Contacts the user has.
        /// </summary>
        public Dictionary<int, Contact> ListOfContacts
        {
            get { return listOfContacts; }
            set { listOfContacts = value; }
        }

        /// <summary>
        /// The instance of a Adressbook
        /// </summary>
        private static AddressBook addressBookInstance;

        private AddressBook()
        {
            // connect to database

            SQL sqlInstance = SQL.getInstance();
            this.listOfContacts = new Dictionary<int, Contact>();
            // Get all contacts
            DataTable data = new DataTable("Contact");
            data.Columns.Add("contactID", typeof(int));
            data.Columns.Add("firstname", typeof(string));
            data.Columns.Add("lastname", typeof(string));
            data.Columns.Add("messageTypeId", typeof(int));
            if (sqlInstance.Read(data))
            {
                List<DataTable> dataList = new List<DataTable>();
                DataTable messageType = new DataTable("MessageType");
                messageType.Columns.Add("mesageTypeID", typeof(int));
                messageType.Columns.Add("typeName", typeof(string));
                messageType.Columns.Add("className", typeof(string));
                sqlInstance.Read(messageType);
                dataList.Add(messageType);

                DataTable smsContact = new DataTable("SMSContact");
                smsContact.Columns.Add("smsContactID", typeof(int));
                smsContact.Columns.Add("contactID", typeof(int));
                smsContact.Columns.Add("address", typeof(string));
                sqlInstance.Read(smsContact);
                dataList.Add(smsContact);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    this.listOfContacts.Add(int.Parse(data.Rows[i]["contactID"].ToString()), new Contact(data.Rows[i], dataList));
                }
            }
            // fill the Addressbook
            int j = 0;
            do
            {
                this.listOfContacts.Add(j, new Contact("Harald_" + j.ToString(), "Petersen"));
                j++;
            } while (j <= 3);
        }

        /// <summary>
        /// Returns a Instance of AddressBook.
        /// </summary>
        /// <returns>The actually Instance of AddressBook</returns>
        public static AddressBook getInstance()
        {
            if (AddressBook.addressBookInstance == null)
                AddressBook.addressBookInstance = new AddressBook();
            return AddressBook.addressBookInstance;
        }
        /// <summary>
        /// Adds a Contact to the list.
        /// </summary>
        /// <param name="contact">A contact-object</param>
        public void addContact(Contact contact)
        {
            this.ListOfContacts.Add(contact.Id, contact);
        }

        /// <summary>
        /// Returns a contact.
        /// </summary>
        /// <param name="contactID">The id of the contact</param>
        /// <returns>contact-object</returns>
        public Contact getContact(int contactID)
        {
            if (this.listOfContacts.ContainsKey(contactID))
                return this.listOfContacts[contactID];
            else
                return null;
        }

        /// <summary>
        /// Removes a contact
        /// </summary>
        /// <param name="contactID"></param>
        /// <returns>true if the delete of the Contact was successful else false</returns>
        public bool removeContact(int contactID)
        {
            if (this.listOfContacts.Remove(contactID) == true)
            {
                Contact contact = this.listOfContacts[contactID];
                if (contact.deleteContact() == true)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns a Datatable with 2 Columns.
        /// </summary>
        /// <returns>2 Colums. First Column has index "contactID" which is the Contact-Id. Second Column is the return of Contact.TooString()-Method</returns>
        public DataTable getDatasource()
        {
            DataTable data = new DataTable("Contacts");
            data.Columns.Add("contactID", typeof(int));
            data.Columns.Add("name", typeof(string));

            foreach (var contact in this.listOfContacts)
            {
                data.Rows.Add(contact.Value.Id, contact.Value.ToString());
            }
            return data;
        }
    }
}
