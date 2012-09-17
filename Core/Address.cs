using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KomMee
{
    public abstract class Address
    {
        protected int id;

        public int Id
        {
            get { return id; }
        }

        private string address;

        public string Address1
        {
            get { return address; }
            set { address = value; }
        }

        private int contactId;

        public int ContactId
        {
            get { return contactId; }
            set { contactId = value; }
        }

        public Address(DataRow data)
        {

        }

        public Address(string address)
        {

        }

        public abstract void save();

        public abstract void delete();
    }
}