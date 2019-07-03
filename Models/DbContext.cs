using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;

namespace mysql.demo.Models
{
    public class DbContext
    {
        public string ConnectionString {get; set;}
        public DbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<Actor> GetAllActors()
        {
            List<Actor> list = new List<Actor>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                //MySqlCommand cmd = new MySqlCommand("Select * from Actor where actor_id < 10", conn);
                MySqlCommand cmd = new MySqlCommand()
                {
                    Connection = conn,
                    CommandText = "Select* from Actor where actor_id < 10",
                    CommandType = CommandType.Text
                };
                
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Actor()
                        {
                            ActorId = Convert.ToInt32(reader["actor_id"]),
                            FirstName = reader["first_name"].ToString(),
                            LastName = reader["last_name"].ToString()
                        });
                    }
                }

            }
            return list;
        }
    }
}