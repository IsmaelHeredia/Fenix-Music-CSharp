using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace FenixMusic
{
    class DataConfiguration
    {
        public Boolean Add(Configuration configuration)
        {
            Boolean response = false;

            Connection conn = new Connection();
            conn.open();

            try
            {
                int ask_update_playlist = configuration.Ask_update_playlist;
                int hotkeys = configuration.Hotkeys;
                string directory = configuration.Directory;

                var query = new SQLiteCommand("INSERT INTO configuration(ask_update_playlist,hotkeys,directory) VALUES (@p0,@p1,@p2)", conn.connection);

                query.Parameters.AddWithValue("@p0", ask_update_playlist);
                query.Parameters.AddWithValue("@p1", hotkeys);
                query.Parameters.AddWithValue("@p2", directory);

                query.ExecuteNonQuery();

                response = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.close();

            return response;
        }

        public Boolean Update(Configuration configuration)
        {
            Boolean response = false;

            Connection conn = new Connection();
            conn.open();

            try
            {
                int id = configuration.Id;
                int ask_update_playlist = configuration.Ask_update_playlist;
                int hotkeys = configuration.Hotkeys;
                string directory = configuration.Directory;

                var query = new SQLiteCommand("UPDATE configuration SET ask_update_playlist = @p0, hotkeys = @p1, directory = @p2 WHERE id = @p3", conn.connection);

                query.Parameters.AddWithValue("@p0", ask_update_playlist);
                query.Parameters.AddWithValue("@p1", hotkeys);
                query.Parameters.AddWithValue("@p2", directory);
                query.Parameters.AddWithValue("@p3", id);

                query.ExecuteNonQuery();

                response = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.close();

            return response;
        }

        public Boolean Delete(int id)
        {
            Boolean response = false;

            Connection conn = new Connection();
            conn.open();

            try
            {
                var query = new SQLiteCommand("DELETE FROM configuration WHERE id = @p0", conn.connection);

                query.Parameters.AddWithValue("@p0", id);

                query.ExecuteNonQuery();

                response = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.close();

            return response;
        }

        public ArrayList List()
        {
            ArrayList list_configuration = new ArrayList();
            Connection conn = new Connection();
            conn.open();

            var query = new SQLiteCommand("SELECT id,ask_update_playlist,hotkeys,directory FROM configuration", conn.connection);

            var reader = query.ExecuteReader();

            while (reader.Read())
            {
                Configuration configuration = new Configuration();
                if (!reader.IsDBNull(0))
                {
                    configuration.Id = reader.GetInt32(0);
                }
                if (!reader.IsDBNull(1))
                {
                    configuration.Ask_update_playlist = reader.GetInt32(1);
                }
                if (!reader.IsDBNull(2))
                {
                    configuration.Hotkeys = reader.GetInt32(2);
                }
                if (!reader.IsDBNull(3))
                {
                    configuration.Directory = reader.GetString(3);
                }
                list_configuration.Add(configuration);
            }
            reader.Close();
            conn.close();
            return list_configuration;
        }

        public Configuration Get(int id)
        {
            Configuration configuration = new Configuration();
            Connection conn = new Connection();
            conn.open();
            var query = new SQLiteCommand("SELECT id,ask_update_playlist,hotkeys,directory FROM configuration WHERE id = @p0", conn.connection);
            query.Parameters.AddWithValue("@p0", id);

            var reader = query.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                if (!reader.IsDBNull(0))
                {
                    configuration.Id = reader.GetInt32(0);
                }
                if (!reader.IsDBNull(1))
                {
                    configuration.Ask_update_playlist = reader.GetInt32(1);
                }
                if (!reader.IsDBNull(2))
                {
                    configuration.Hotkeys = reader.GetInt32(2);
                }
                if (!reader.IsDBNull(3))
                {
                    configuration.Directory = reader.GetString(3);
                }
            }
            reader.Close();
            conn.close();
            return configuration;
        }
    }
}
