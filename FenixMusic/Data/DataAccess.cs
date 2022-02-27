using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace FenixMusic
{
    class DataAccess
    {
        public DataAccess()
        {
        }

        public Boolean createDB()
        {
            Boolean response = false;

            Connection conn = new Connection();
            conn.open();

            try
            {
                // Table configuration

                string sql_drop_configuration = "DROP TABLE IF EXISTS configuration;";

                SQLiteCommand cmd_drop_keys = new SQLiteCommand(sql_drop_configuration, conn.connection);
                cmd_drop_keys.ExecuteNonQuery();

                string sql_create_table_configuration = "CREATE TABLE configuration(id integer PRIMARY KEY autoincrement, ask_update_playlist integer, hotkeys integer, directory nvarchar(100));";

                SQLiteCommand cmd_create_keys = new SQLiteCommand(sql_create_table_configuration, conn.connection);
                cmd_create_keys.ExecuteNonQuery();

                // Table stations

                string sql_drop_stations = "DROP TABLE IF EXISTS stations;";

                SQLiteCommand cmd_drop_tasks = new SQLiteCommand(sql_drop_stations, conn.connection);
                cmd_drop_tasks.ExecuteNonQuery();

                string sql_create_table_stations = "CREATE TABLE stations(id integer PRIMARY KEY autoincrement,name nvarchar(100), link nvarchar(100), categories nvarchar(100));";

                SQLiteCommand cmd_create_tasks = new SQLiteCommand(sql_create_table_stations, conn.connection);
                cmd_create_tasks.ExecuteNonQuery();

                response = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public DataTable loadStationTable()
        {
            Connection connection = new Connection();
            connection.open();
            DataTable dt = new DataTable();
            connection.command.CommandText = "SELECT name, link, categories FROM stations";
            dt.Load(connection.command.ExecuteReader());
            connection.close();
            return dt;
        }
    }
}