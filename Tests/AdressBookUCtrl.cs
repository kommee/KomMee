using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KomMee;

namespace KomMee_Tests
{
    public partial class AdressBookUCtrl : Form
    {
        public AdressBookUCtrl()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void addressBookView1_UpPressed(object sender, EventArgs e)
        {
            this.addressBookView1.up();
        }

        private void addressBookView1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == (int)Keys.Up)
            {
                this.addressBookView1_UpPressed(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.addressBookView1_KeyUp(sender, new KeyEventArgs(Keys.Up));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KeyEventArgs key = new KeyEventArgs(Keys.Down);
            if (key.KeyValue == (int)Keys.Down)
            {
                this.addressBookView1.down();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KeyEventArgs key = new KeyEventArgs(Keys.Space);
            if (key.KeyValue == (int)Keys.Space)
            {
                this.addressBookView1.apply();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
