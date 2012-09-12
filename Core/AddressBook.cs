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
            //SQL sqlInstance = SQL.getInstance();
            // Get all contacts
            //List<Hashtable> data = sqlInstance.Read(Tables.Contact);

            // fill the Addressbook
            int i = 0;
            do
            {
                try
                {
                    this.listOfContacts.Add(i, new Contact("Harald_" + i.ToString(), "Petersen"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                i++;
            } while (i <= 3);
          /*  foreach (Hashtable table in data)
            {
                this.listOfContacts.Add((int)table["contactID"], new Contact((int)table["contactID"], (string)table["firstname"], (string)table["lastname"]));
            }*/
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
            return this.listOfContacts[contactID];
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
