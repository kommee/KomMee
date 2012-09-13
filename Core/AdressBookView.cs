using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KomMee
{
    public partial class AdressBookView : KomMee.UctrlDialog
    {
        public AdressBookView()
            :base()
        {
            InitializeComponent();
            // Load addressbook
            AddressBook adrBook = AddressBook.getInstance();

            // Add Contact to the Listbox
            foreach (var contact in adrBook.ListOfContacts)
            {
                this.LbChoice.Items.Add(contact.Value);
            }

            // sort the entries
            this.LbChoice.Sorted = true;

            // Select the first entry
            if (this.LbChoice.SelectedIndex < 0)
            {
                this.LbChoice.SelectedIndex = 0;
            }
            this.LbChoice.Select();
        }


        /// <summary>
        /// Call from Key apply
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
            if (this.LbChoice.SelectedIndex >= this.LbChoice.Items.Count - 1)
            {
                this.LbChoice.SelectedIndex = 0;
            }
            else
            {
                this.LbChoice.SelectedIndex += 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void left()
        {
           // Do nothing
        }

        /// <summary>
        /// 
        /// </summary>
        public override void right()
        {
            // Do nothing
        }

        /// <summary>
        /// 
        /// </summary>
        public override void up()
        {
            if (this.LbChoice.SelectedIndex <= 0)
            {
                this.LbChoice.SelectedIndex = this.LbChoice.Items.Count - 1;
            }
            else
            {
                this.LbChoice.SelectedIndex -= 1;
            }
        }
    }
}
