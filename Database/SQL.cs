using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace KomMee
{
    public class SQL
    {
        private string pathOfDatabase = "kommee.db";

        public string PathOfDatabase
        {
            get { return pathOfDatabase; }
        }
        private SQLiteConnection sqliteConnection;
        private static SQL sqlInstance = new SQL();
        private Dictionary<Tables, string> tableDefinitions = new Dictionary<Tables, string>();
        
        private SQL()
        {
            this.sqliteConnection = new SQLiteConnection("Data Source=" + this.pathOfDatabase);
            Console.WriteLine("Im Konstruktor!!!");
            this.sqliteConnection.Open();

            this.initTableDefs();


            SQLiteCommand command = new SQLiteCommand(this.sqliteConnection);

            command.CommandText = this.tableDefinitions[Tables.MessageType];
            command.ExecuteNonQuery();


            command.CommandText = this.tableDefinitions[Tables.Setting];
            command.ExecuteNonQuery();

            command.CommandText = this.tableDefinitions[Tables.Contact];
            command.ExecuteNonQuery();

            command.CommandText = this.tableDefinitions[Tables.SMSContact];
            command.ExecuteNonQuery();

            command.CommandText = this.tableDefinitions[Tables.EMailContact];
            command.ExecuteNonQuery();

            command.CommandText = this.tableDefinitions[Tables.SMS];
            command.ExecuteNonQuery();

            command.CommandText = this.tableDefinitions[Tables.EMail];
            command.ExecuteNonQuery();
        }

        ~SQL()
        {
            this.sqliteConnection.Close();
        }

        public static SQL getInstance()
        {
            return sqlInstance;
        }

        public int Insert(DataTable data)
        {
            SQLiteCommand command = new SQLiteCommand(this.sqliteConnection);
            return -1;
        }

        public bool Update(DataTable data)
        {
            SQLiteCommand command = new SQLiteCommand(this.sqliteConnection);
            return false;
        }

        public bool Delete(DataTable data)
        {
            SQLiteCommand command = new SQLiteCommand(this.sqliteConnection);
            string tableID = data.TableName + "ID", insert = null, currDate = null ;
            DataRow row = data.Rows[0];
            currDate = DateTime.Now.ToString("yyyyMMDD");

            insert = string.Format("UPDATE {0} SET deleteDate = {1} WHERE {2} = {3}", data.TableName, currDate, tableID, row[tableID]);
            command.CommandText = insert;
            switch (command.ExecuteNonQuery())
            {
                case 0:
                    throw new Exception("Error deleting entry in table {0}! 0 Rows affected!",);
                case 1:
                    break;
                default:
                    throw new Exception("Error deleting entry in table {0}! More than one row affected!",);
            }
            return false;
        }

        public bool Read(DataTable data)
        {
            SQLiteCommand command = new SQLiteCommand(this.sqliteConnection);
            SQLiteDataReader reader = null;
            string table = data.TableName, query = "", cols = "";

            foreach (DataColumn dc in data.Columns)
            {
                cols += dc.ColumnName + ", ";
            }
            cols = cols.Substring(0, (cols.Length - 2));
            query = string.Format("SELECT {0} FROM {1} WHERE deleteDate ISNULL", cols, table);
            command.CommandText = query;
            reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                DataRow row;
                while(reader.Read())
                {
                    row = data.NewRow();
                    foreach(DataColumn col in data.Columns)
                    {
                        if(col.GetType().Equals(typeof(int)))
                        {
                            row[col.ColumnName] = reader.GetInt32(reader.GetOrdinal(col.ColumnName));
                        }
                        else if(col.GetType().Equals(typeof(string)))
                        {
                            row[col.ColumnName] = reader.GetString(reader.GetOrdinal(col.ColumnName));
                        }
                        else if(col.GetType().Equals(typeof(bool)))
                        {
                            row[col.ColumnName] = Convert.ToBoolean(reader.GetInt32(reader.GetOrdinal(col.ColumnName)));
                        }
                        else
                        {
                            throw new Exception(string.Format("Invalid Datatype: {0}", col.GetType().FullName));
                        }
                    }
                    data.Rows.Add(row);
                }
            }
            else
            {
                throw new Exception(string.Format("Table {} is empty, or doesn't exist!", data.TableName));
            }
           return true;
        }

        private void initTableDefs()
        {
            this.tableDefinitions.Add(Tables.MessageType, "CREATE TABLE IF NOT EXISTS MessageType(" +
                                                        "messageTypeID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                        "typeName TEXT NOT NULL, " +
                                                        "className TEXT NOT NULL);");


            this.tableDefinitions.Add(Tables.Setting, "CREATE TABLE IF NOT EXISTS Setting(" +
                                                    "key TEXT PRIMARY KEY, " +
                                                    "value TEXT NOT NULL);");

            this.tableDefinitions.Add(Tables.Contact, "CREATE TABLE IF NOT EXISTS Contact(" +
                                                    "contactID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                    "firstName TEXT NOT NULL, " +
                                                    "lastName TEXT NOT NULL, " +
                                                    "deleteDate INTEGER DEFAULT NULL, " +
                                                    "messageTypeID INTEGER NOT NULL REFERENCES MessageType(messageTypeID) ON DELETE SET NULL ON UPDATE CASCADE, " +
                                                    "image BLOB DEFAULT NULL);");

            this.tableDefinitions.Add(Tables.SMSContact, "CREATE TABLE IF NOT EXISTS SMSContact(" +
                                                        "smsContactID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                        "contactID INTEGER NOT NULL REFERENCES Contact(contactID) ON DELETE CASCADE ON UPDATE CASCADE, " +
                                                        "address TEXT NOT NULL);");

            this.tableDefinitions.Add(Tables.EMailContact, "CREATE TABLE IF NOT EXISTS EMailContact(" +
                                                        "emailContactID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                        "contactID INTEGER NOT NULL REFERENCES Contact(contactID) ON DELETE CASCADE ON UPDATE CASCADE, " +
                                                        "address TEXT NOT NULL);");

            this.tableDefinitions.Add(Tables.EMail, "CREATE TABLE IF NOT EXISTS EMail(" +
                                                "emailID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                "subject TEXT NOT NULL DEFAULT \"\", " +
                                                "text TEXT NOT NULL, " +
                                                "senderAddress TEXT NOT NULL, " +
                                                "contactID INTEGER NOT NULL REFERENCES Contact(contactID) ON DELETE SET NULL ON UPDATE CASCADE, " +
                                                "isSent INTEGER NOT NULL DEFAULT 0, " +
                                                "isRead INTEGER NOT NULL DEFAULT 0, " +
                                                "deleteDate TEXTs DEFAULT NULL," +
                                                "creationDate TEXT NOT NULL);");

            this.tableDefinitions.Add(Tables.SMS, "CREATE TABLE IF NOT EXISTS SMS(" +
                                                "smsID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                "text TEXT NOT NULL, " +
                                                "senderAddress TEXT NOT NULL, " +
                                                "contactID INTEGER NOT NULL REFERENCES Contact(contactID) ON DELETE SET NULL ON UPDATE CASCADE, " +
                                                "isSent INTEGER NOT NULL DEFAULT 0, " +
                                                "isRead INTEGER NOT NULL DEFAULT 0, " +
                                                "deleteDate TEXT DEFAULT NULL," +
                                                "creationDate TEXT NOT NULL);");
        }

        private enum Tables
        {
            Contact, EMail, EMailContact, MessageType, Setting, SMS, SMSContact
        }

        private int getCurrentTimestamp()
        {
            int currentTimestamp = 0;
            DateTime now, unixTime;
            TimeSpan span;

            now = DateTime.Now;
            unixTime = new DateTime(1970,1,1);
            span = new TimeSpan(now.Ticks - unixTime.Ticks);

            currentTimestamp = (int)(span.TotalSeconds);

            return currentTimestamp;
        }
    }
}
