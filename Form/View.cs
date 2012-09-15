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
        public Panel MessageViewContainer
        {
            get { return this.TopPanel.Panel2; }
        }

        public UctrlDialog UpperLeftControl
        {
            get { return this.uctrlDialog1; }
        }

        private AddressBook addressBook;

        internal AddressBook AddressBook
        {
            get { return addressBook; }
            set { addressBook = value; }
        }

        internal KeyboardView KeyboardView
        {
            get { return (KeyboardView)this.abcdefKeyboardView1;  }
        }

        public View()
        {
            InitializeComponent();

            //init Input
            Settings.init();
            Input.init(this);
            Input.setNewMenuState(MenuState.None);
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
            Input.handleUserInput(e.KeyValue);
        }

        private void FocusResetTimer_Tick(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void abcdefKeyboardView1_Applied(object sender, EventArgs e)
        {
            Input.handleKeyboardEvent((KeyboardViewEventArgs)e);
        }

        private void View_Shown(object sender, EventArgs e)
        {
            this.abcdefKeyboardView1.setDefaultFocus();
        }

    }
}
