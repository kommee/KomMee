using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using KomMee;
using System.Data;
using System.Threading;

namespace KomMee_Tests
{
    [TestFixture]
    public class SIMTest
    {
        [Test]
        public void test()
        {
            SIM sim = SIM.getInstance();
            Assert.IsTrue(sim.sendMessage("017678243093", "This SMS is proudly presented by KomMee"));
            Thread.Sleep(3000);
            DataTable messages = sim.readMessages();
            this.printMessages(messages);
            Assert.IsTrue(messages.Rows.Count > 0);
            
            messages = sim.readMessages();
            this.printMessages(messages);
            Assert.IsTrue(messages.Rows.Count == 0);

            Console.ReadKey();
        }
        public void printMessages(DataTable messages)
        {
            int count = 0;
            Console.WriteLine("-----------------------");
            Console.WriteLine("Start Printing Messages");
            Console.WriteLine("-----------------------");
            foreach (DataRow row in messages.Rows)
            {
                Console.WriteLine("Message " + ++count + ":\n");
                Console.WriteLine("Sender: " + row[0]);
                Console.WriteLine("Receive-Time: " + row[1]);
                Console.WriteLine("Message-Text: \n" + row[2]);
                Console.WriteLine("\n----------\n");
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Finish Printing Messages");
            Console.WriteLine("------------------------");
        }
    }
}
