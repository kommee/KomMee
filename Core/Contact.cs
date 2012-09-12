using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

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
        internal Address DefaultAddress
        {
            get { return defaultAddress; }
            set { defaultAddress = value; }
        }


        /// <summary>
        /// The type of a contact
        /// /// </summary>
        private Dictionary<string, Address> contactTypes;

        /// <summary>
        /// The type of a contact
        /// /// </summary>
        internal Dictionary<string, Address> ContactTypes
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

            this.firstname = pFirstname.ToUpperInvariant();
            this.lastname = pLastname.ToUpperInvariant();
        }

        /// <summary>
        ///  Creates a contact out of his id, his firstname and his lastname
        /// </summary>
        /// <param name="pId">The contat-ID</param>
        /// <param name="pFirstname">The firstname of a contact</param>
        /// <param name="pLastname">The lastname of a contact</param>
        public Contact(int pId, string pFirstname, string pLastname)
            : this(pFirstname,pLastname)
        {
            if (pId == 0)
            {
                throw new Exception("Contact-Id is empty.");
            }

            this.id = pId;
        }

        /// <summary>
        /// save the Contactobject to the save-file. Is the Id empty, it will create a new entry.
        /// </summary>
        public bool saveContact()
        {
            bool error = false;
            if (this.Id == 0)
            {
                this.id = this.Insert();
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
            // BLA
            //return sqlInstance.Insert(Tables.Contact,this);
            return 0;
        }

        /// <summary>
        /// Updates the contactinformation
        /// </summary>
        /// <returns>true if it was succesful, else false</returns>
        private bool Update()
        {
            SQL sqlInstance = SQL.getInstance();

            //return sqlInstance.Update(Tables.Contact, this);
            return false;
        }

        /// <summary>
        /// Deletes a contact from the database
        /// </summary>
        /// <returns>true if it was succesful, else false</returns>
        private bool Delete()
        {
            SQL sqlInstance = SQL.getInstance();

            //return sqlInstance.Delete(Tables.Contact, this); ;
            return false;
        }
    }
}
