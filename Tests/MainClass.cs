using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KomMee;


namespace KomMee_Tests
{
    public static class MainClass
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // AddressbookView Test
            //Application.Run(new AdressBookUCtrl());
            // MessageListView Test
            Application.Run(new MessageListViewTest());
        }
    }
}
