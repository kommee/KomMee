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
        SQLiteConnection conn = null;
        SQLiteCommand command = null;
        [TestFixtureSetUp]
        public void setUp()
        {
            this.conn = new SQLiteConnection("Data Source=" + SQL.getInstance().PathOfDatabase);
            this.conn.Open();
            this.command = new SQLiteCommand();

            //Testdaten eintragen
            command.CommandText = "CREATE TABLE testTable(testTableID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                            "testName TEXT NOT NULL," +
                                                            "testBool INTEGER NOT NULL)";
            Assert.AreEqual(command.ExecuteNonQuery(), 1);
        }

        [TestFixtureTearDown]
        public void cleanUp()
        {
            this.conn.Close();
        }
        [Test]
        public void testGetInstance()
        {
            SQL sqlInstance = SQL.getInstance();
            Assert.IsNotNull(sqlInstance);
        }
        
    }
}
