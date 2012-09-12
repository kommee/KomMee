using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomMee
{
    public class AddressBookView : UctrlDialog
    {
        public AddressBookView()
            :base()
        {
            // Load addressbook
            AddressBook adrBook = AddressBook.getInstance();

            // Add Contact to the Listbox
            foreach (var contact in adrBook.ListOfContacts)
            {
                this.LbChoice.Items.Add(contact.Value);
            }
            
        }


        /// <summary>
        /// Call from Key applay
        /// </summary>
        public override void apply()
        {
            base.apply();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void cancel()
        {
            base.cancel();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void down()
        {
            base.down();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void left()
        {
            base.left();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void right()
        {
            base.right();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void up()
        {
            base.up();
        }
    }
}
