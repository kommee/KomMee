using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KomMee
{
    public class Address
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
        
        protected int contactId;

        public Address(DataRow data)
        {

        }

        public abstract void save();

        public abstract void delete();
    }
}