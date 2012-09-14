using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace KomMee
{
    public partial class View : Form
    {
        private IViewContainer ViewContainer;

        internal IViewContainer ViewContainer1
        {
            get { return ViewContainer; }
            set { ViewContainer = value; }
        }

        private AddressBook addressBook;

        internal AddressBook AddressBook
        {
            get { return addressBook; }
            set { addressBook = value; }
        }

        public View()
        {
            InitializeComponent();

            //init Input
            Input.init();
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new View());
        }

        private void View_KeyUp(object sender, KeyEventArgs e)
        {
            Input.handleKeyboardEvent(e.KeyValue);
        }

        private void FocusResetTimer_Tick(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
