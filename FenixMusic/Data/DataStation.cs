using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace FenixMusic
{
    class DataStation
    {
        public Boolean Add(Station station)
        {
            Boolean response = false;

            Connection conn = new Connection();
            conn.open();

            try
            {
                string name = station.Name;
                string link = station.Link;
                string categories = station.Categories;

                var query = new SQLiteCommand("INSERT INTO stations(name,link,categories) VALUES (@p0,@p1,@p2)", conn.connection);

                query.Parameters.AddWithValue("@p0", name);
                query.Parameters.AddWithValue("@p1", link);
                query.Parameters.AddWithValue("@p2", categories);

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

        public Boolean Update(Station station)
        {
            Boolean response = false;

            Connection conn = new Connection();
            conn.open();

            try
            {
                int id = station.Id;
                string name = station.Name;
                string link = station.Link;
                string categories = station.Categories;

                var query = new SQLiteCommand("UPDATE stations SET name = @p0, link = @p1, categories = @p2 WHERE id = @p3", conn.connection);

                query.Parameters.AddWithValue("@p0", name);
                query.Parameters.AddWithValue("@p1", link);
                query.Parameters.AddWithValue("@p2", categories);
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
                var query = new SQLiteCommand("DELETE FROM stations WHERE id = @p0", conn.connection);

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

        public ArrayList List(string search)
        {
            ArrayList stations = new ArrayList();
            Connection conn = new Connection();
            conn.open();

            var query = new SQLiteCommand("SELECT id, name, link, categories FROM stations WHERE name LIKE @p0 OR categories LIKE @p0", conn.connection);
            query.Parameters.AddWithValue("@p0", "%" + search + "%");

            var reader = query.ExecuteReader();

            while (reader.Read())
            {
                Station station = new Station();
                if (!reader.IsDBNull(0))
                {
                    station.Id = reader.GetInt32(0);
                }
                if (!reader.IsDBNull(1))
                {
                    station.Name = reader.GetString(1);
                }
                if (!reader.IsDBNull(2))
                {
                    station.Link = reader.GetString(2);
                }
                if (!reader.IsDBNull(3))
                {
                    station.Categories = reader.GetString(3);
                }
                stations.Add(station);
            }
            reader.Close();
            conn.close();
            return stations;
        }

        public Station Get(int id)
        {
            Station station = new Station();
            Connection conn = new Connection();
            conn.open();
            var query = new SQLiteCommand("SELECT id,name,link,categories FROM stations WHERE id = @p0", conn.connection);
            query.Parameters.AddWithValue("@p0", id);

            var reader = query.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                if (!reader.IsDBNull(0))
                {
                    station.Id = reader.GetInt32(0);
                }
                if (!reader.IsDBNull(1))
                {
                    station.Name = reader.GetString(1);
                }
                if (!reader.IsDBNull(2))
                {
                    station.Link = reader.GetString(2);
                }
                if (!reader.IsDBNull(3))
                {
                    station.Categories = reader.GetString(3);
                }
            }
            reader.Close();
            conn.close();
            return station;
        }
    }
}
