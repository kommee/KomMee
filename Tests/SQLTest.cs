using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using NUnit.Framework;

namespace KomMee
{
    [TestFixture]
    public class SQLTest
    {
        [Test]
        public void testGetInstance()
        {
            SQL sqlInstance = SQL.getInstance();
            Assert.IsNotNull(sqlInstance);
        }
        [Test]

    }
}
