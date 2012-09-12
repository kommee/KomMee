using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KomMee_Tests
{
    public partial class AdressBookUCtrl : Form
    {
        private KomMee.AddressBookView adrView;

        public AdressBookUCtrl()
        {
            try
            {
                InitializeComponent();
                this.adrView = new KomMee.AddressBookView();
                this.Controls.Add(this.adrView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
