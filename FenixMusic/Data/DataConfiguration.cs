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
                int hotkeys = configuration.Hotkeys;
                string directory = configuration.Directory;

                var query = new SQLiteCommand("INSERT INTO configuration(hotkeys,directory) VALUES (@p0,@p1)", conn.connection);

                query.Parameters.AddWithValue("@p0", hotkeys);
                query.Parameters.AddWithValue("@p1", directory);

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
                int hotkeys = configuration.Hotkeys;
                string directory = configuration.Directory;

                var query = new SQLiteCommand("UPDATE configuration SET hotkeys = @p0, directory = @p1 WHERE id = @p2", conn.connection);

                query.Parameters.AddWithValue("@p0", hotkeys);
                query.Parameters.AddWithValue("@p1", directory);
                query.Parameters.AddWithValue("@p2", id);

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

            var query = new SQLiteCommand("SELECT id,hotkeys,directory FROM configuration", conn.connection);

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
                    configuration.Hotkeys = reader.GetInt32(1);
                }
                if (!reader.IsDBNull(2))
                {
                    configuration.Directory = reader.GetString(2);
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
            var query = new SQLiteCommand("SELECT id,hotkeys,directory FROM configuration WHERE id = @p0", conn.connection);
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
                    configuration.Hotkeys = reader.GetInt32(1);
                }
                if (!reader.IsDBNull(2))
                {
                    configuration.Directory = reader.GetString(2);
                }
            }
            reader.Close();
            conn.close();
            return configuration;
        }
    }
}
