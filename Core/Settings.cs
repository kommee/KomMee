using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KomMee
{
    public static class Settings
    {
        private static Dictionary<string, string> mapping;

        public static void init()
        {
            SQL sqlInstance = SQL.getInstance();
            DataTable keymappingSettings = new DataTable("Setting");
            Settings.mapping = new Dictionary<string, string>();
            
            keymappingSettings.Columns.Add("key", typeof(string));
            keymappingSettings.Columns.Add("value", typeof(string));
            sqlInstance.Read(keymappingSettings);

            foreach (DataRow row in keymappingSettings.Rows)
            {
                Settings.mapping.Add(row["key"].ToString(), row["value"].ToString());
            }
        }

        public static string getValue(string key)
        {
            return Settings.mapping[key];
        }

        public static void setValue(string key, string newValue)
        {
            SQL sqlInstance = SQL.getInstance();
            DataTable tableUpdate = new DataTable("Setting");
            DataRow updateValue = null;

            tableUpdate.Columns.Add("key", typeof(string));
            tableUpdate.Columns.Add("value", typeof(string));

            updateValue = tableUpdate.NewRow();
            updateValue["key"] = key;
            updateValue["value"] = newValue;
            tableUpdate.Rows.Add(updateValue);

            if (Settings.mapping.ContainsKey(key))
            {
                sqlInstance.Update(tableUpdate);
                Settings.mapping[key] = newValue;
            }
            else
            {
                sqlInstance.Insert(tableUpdate);
                Settings.mapping.Add(key, newValue);
            }
        }
    }
}
