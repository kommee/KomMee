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
            if (data.Rows.Count != 1)
            {
                throw new Exception("The given DataTable is empty, or has more than one row!");
            }
            SQLiteCommand command = new SQLiteCommand(this.sqliteConnection);
            string insert = null, cols = null, values = null;

            foreach (DataColumn col in data.Columns)
            {
                if (data.Rows[0][col.ColumnName] != null)
                {
                    cols += col.ColumnName + ", ";
                    if (col.DataType.Equals(typeof(int)))
                    {
                        values += data.Rows[0][col.ColumnName] + ", ";
                    }
                    else if (col.DataType.Equals(typeof(string)))
                    {
                        values += "'" + data.Rows[0][col.ColumnName] + "', ";
                    }
                    else if (col.DataType.Equals(typeof(bool)))
                    {
                        values += Convert.ToInt32(data.Rows[0][col.ColumnName]) + ", ";
                    }
                }
            }
            cols = cols.Substring(0, (cols.Length - 2));
            values = values.Substring(0, (values.Length - 2));

            insert = string.Format("INSERT INTO {0}({1}) VALUES({2})", data.TableName, cols, values);
            command.CommandText = insert;
            int rc = command.ExecuteNonQuery();
            if (rc == 1)
            {
                command.CommandText = string.Format("SELECT {0} FROM {1}  ORDER BY {0} DESC", (data.TableName + "ID"), data.TableName);
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                return reader.GetInt32(0);
            }
            else if (rc == 0)
            {
                throw new Exception(string.Format("Error inserting new data into table {0}! No data inserted!", data.TableName));
            }
            else
            {
                throw new Exception(string.Format("Error inserting new data into table {0}! More than {1} rows inserted!", data.TableName, rc));
            }
        }

        public bool Update(DataTable data)
        {
            if (data.Rows.Count != 1)
            {
                throw new Exception("The given DataTable is empty, or has more than one row!");
            }
            SQLiteCommand command = new SQLiteCommand(this.sqliteConnection);
            string tableID = data.TableName + "ID", update = null, set = null ;

            foreach (DataColumn col in data.Columns)
            {
                if (data.Rows[0][col.ColumnName] != null)
                {
                    set += col.ColumnName + " = ";
                    if (col.DataType.Equals(typeof(int)))
                    {
                        set += data.Rows[0][col.ColumnName] + ", ";
                    }
                    else if (col.DataType.Equals(typeof(string)))
                    {
                        set += "'" + data.Rows[0][col.ColumnName] + "', ";
                    }
                    else if (col.DataType.Equals(typeof(bool)))
                    {
                        set += Convert.ToInt32(data.Rows[0][col.ColumnName]) + ", ";
                    }
                }
            }
            set = set.Substring(0, (set.Length - 2));

            update = string.Format("UPDATE {0} SET {1] WHERE {2} = {3}", data.TableName, set, tableID, data.Rows[0][tableID]);
            command.CommandText = update;
            command.ExecuteNonQuery();
            return false;
        }

        public bool Delete(DataTable data)
        {
            if (!isDeletable(data.TableName))
            {
                throw new Exception(string.Format("You are not allowed to delete datasets in table {}", data.TableName));
            }
            else if (data.Rows.Count != 1)
            {
                throw new Exception("The given DataTable is empty, or has more than one row!");
            }
            SQLiteCommand command = new SQLiteCommand(this.sqliteConnection);
            string tableID = data.TableName + "ID", delete = null, currDate = null ;
            currDate = DateTime.Now.ToString("yyyyMMDD");

            delete = string.Format("UPDATE {0} SET deleteDate = {1} WHERE {2} = {3}", data.TableName, currDate, tableID, data.Rows[0][tableID]);
            command.CommandText = delete;
            switch (command.ExecuteNonQuery())
            {
                case 0:
                    throw new Exception(string.Format("Error deleting entry in table {0}! 0 Rows affected!", data.TableName));
                case 1:
                    break;
                default:
                    throw new Exception(string.Format("Error deleting entry in table {0}! More than one row affected!", data.TableName));
            }
            return false;
        }

        public bool Read(DataTable data)
        {
            if (data.Rows.Count != 0)
            { 
                throw new Exception("The given DataTable must be empty!");
            }
            SQLiteCommand command = new SQLiteCommand(this.sqliteConnection);
            SQLiteDataReader reader = null;
            string table = data.TableName, query = "", cols = "";
            bool deleteDate = this.isDeletable(data.TableName);

            foreach (DataColumn dc in data.Columns)
            {
                cols += dc.ColumnName + ", ";
            }
            cols = cols.Substring(0, (cols.Length - 2));
            query = string.Format("SELECT {0} FROM {1}", cols, table);
            if (deleteDate)
            {
                query += "WHERE deleteDate ISNULL";
            }
            
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
                                                        "address TEXT NOT NULL," +
                                                        "deleteDate TEXT DEFAULT NULL);");

            this.tableDefinitions.Add(Tables.EMailContact, "CREATE TABLE IF NOT EXISTS EMailContact(" +
                                                        "emailContactID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                        "contactID INTEGER NOT NULL REFERENCES Contact(contactID) ON DELETE CASCADE ON UPDATE CASCADE, " +
                                                        "address TEXT NOT NULL," +
                                                        "deleteDate TEXT DEFAULT NULL);");

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

        private bool isDeletable(string tableName)
        {
            SQLiteCommand command = new SQLiteCommand(string.Format("pragma table_info({0})", tableName), this.sqliteConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            { 
                while (reader.Read())
                {
                    if (reader.GetString(reader.GetOrdinal("name")) == "deletDate")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
