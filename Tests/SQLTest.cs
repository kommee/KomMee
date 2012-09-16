using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using NUnit.Framework;
using System.Data;
using System.IO;

namespace KomMee
{
    [TestFixture]
    public class SQLTest
    {
        SQLiteConnection conn = null;
        [TestFixtureSetUp]
        public void setUp()
        {
            string ds = "Data Source=" + SQL.getInstance().PathOfDatabase;
            this.conn = new SQLiteConnection(ds);
            this.conn.Open();
            SQLiteCommand command = new SQLiteCommand(this.conn);

            //Testdaten eintragen
            command.CommandText = "DROP TABLE IF EXISTS TestTable";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE IF NOT EXISTS TestTable(testTableID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                            "testName TEXT NOT NULL," +
                                                            "testBool INTEGER NOT NULL, " +
                                                            "deleteDate TEXT DEFAULT NULL)";
            Assert.AreEqual(command.ExecuteNonQuery(), 0);
        }

        [TestFixtureTearDown]
        public void cleanUp()
        {
            SQLiteCommand command = new SQLiteCommand(this.conn);
            command.CommandText = "DROP TABLE IF EXISTS TestTable";
            command.ExecuteNonQuery();
        }

        [Test]
        public void testGetInstance()
        {
            SQL sqlInstance = SQL.getInstance();
            Assert.IsNotNull(sqlInstance);
        }

        [Test]
        public void atestInsert()
        {
            DataTable data = new DataTable("TestTable");
            data.Columns.Add("testTableID", typeof(int));
            data.Columns.Add("testName", typeof(string));
            data.Columns.Add("testBool", typeof(bool));
            data.Columns.Add("deleteDate", typeof(string));

            for (int i = 1; i <= 20; i++)
            {
                DataRow row = data.NewRow();
                row[1] = "Test";
                row[2] = i % 2;
                data.Rows.Add(row);
                SQL.getInstance().Insert(data);
                data.Rows.RemoveAt(0);
            }
            SQLiteCommand command = new SQLiteCommand(this.conn);
            command.CommandText = "SELECT testTableID, testName, testBool FROM testTable";
            SQLiteDataReader reader = command.ExecuteReader();
            int rowCount = 0;

            while (reader.Read())
            {
                rowCount++;
                Assert.AreEqual("Test", reader.GetString(1));
                Assert.AreEqual(Convert.ToBoolean(rowCount % 2), reader.GetBoolean(2));
            }

            Assert.AreEqual(20, rowCount);
        }
    
        [Test]
        public void testUpdate()
        {
            DataTable data = new DataTable("TestTable");
            SQLiteCommand command = new SQLiteCommand(this.conn);
            data.Columns.Add("testTableID", typeof(int));
            data.Columns.Add("testName", typeof(string));
            data.Columns.Add("testBool", typeof(bool));
            data.Columns.Add("deleteDate", typeof(string));

            command.CommandText = "INSERT INTO TestTable(testTableID, testName, testBool) VALUES(1337, 'Test', 0)";
            command.ExecuteNonQuery();

            DataRow row = data.NewRow();
            row[0] = 1337;
            row[1] = "Test";
            row[2] = 1;
            data.Rows.Add(row);

            SQL.getInstance().Update(data);
        }

        [Test]
        public void testDelete()
        {
            DataTable data = new DataTable("TestTable");
            SQLiteCommand command = new SQLiteCommand(this.conn);
            data.Columns.Add("testTableID", typeof(int));
            data.Columns.Add("testName", typeof(string));
            data.Columns.Add("testBool", typeof(bool));
            data.Columns.Add("deleteDate", typeof(string));

            command.CommandText = "INSERT INTO TestTable(testTableID, testName, testBool) VALUES(7331, 'Test', 0)";
            command.ExecuteNonQuery();

            DataRow row = data.NewRow();
            row[0] = 7331;
            row[1] = "Test";
            row[2] = 0;
            data.Rows.Add(row);

            SQL.getInstance().Delete(data);

            command.CommandText = "SELECT deleteDate FROM TestTable WHERE testTableID = 7331";
            SQLiteDataReader reader = command.ExecuteReader();

            Assert.IsTrue(reader.HasRows);
            reader.Read();
            Assert.AreEqual(DateTime.Now.ToString("yyyyMMdd"), reader.GetString(0));
        }
    }
}
