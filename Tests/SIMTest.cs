using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using KomMee;

namespace KomMee_Tests
{
    [TestFixture]
    public class SIMTest
    {
        [Test]
        public void test()
        {
            SIM sim = SIM.getInstance();
            Console.WriteLine(sim.sendMessage("017678243093", "Hello World!\r\nTest =)"));
            Console.WriteLine(sim.sendMessage("017678243093", "Hello World!"));
            sim.readMessages();
            Console.ReadKey();
        }
    }
}
