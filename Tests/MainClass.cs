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
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                // AddressbookView Test
                //Application.Run(new AdressBookUCtrl());
                // MessageListView Test
                //Application.Run(new MessageListViewTest());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
