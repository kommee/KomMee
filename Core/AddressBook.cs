using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
        internal Dictionary<int, Contact> ListOfContacts
        {
            get { return listOfContacts; }
            set { listOfContacts = value; }
        }

        /// <summary>
        /// The instance of a Adressbook
        /// </summary>
        private static AddressBook addressBookInstance = new AddressBook();

        private AddressBook()
        {
            this.listOfContacts = new Dictionary<int, Contact>();
            // connect to database
            try
            {
                SQL sqlInstance = SQL.getInstance();
                // Get all contacts
                System.Data.DataTable data = new System.Data.DataTable("Contact");
                data.Columns.Add("contactID", typeof(int));
                data.Columns.Add("firstname", typeof(string));
                data.Columns.Add("lastname", typeof(string));
                data.Columns.Add("messageTypeId", typeof(int));
                if (sqlInstance.Read(data))
                {
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        this.listOfContacts.Add(int.Parse(data.Rows[i]["contactID"].ToString()), new Contact(int.Parse(data.Rows[i]["contactID"].ToString()), data.Rows[i]["firstname"].ToString(), data.Rows[i]["lastname"].ToString()));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            // fill the Addressbook
            int j = 0;
            do
            {
                try
                {
                    this.listOfContacts.Add(j, new Contact("Harald_" + j.ToString(), "Petersen"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                j++;
            } while (j <= 3);
        }

        /// <summary>
        /// Returns a Instance of AddressBook.
        /// </summary>
        /// <returns>The actually Instance of AddressBook</returns>
        public static AddressBook getInstance()
        {
            return addressBookInstance;
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
    }
}
