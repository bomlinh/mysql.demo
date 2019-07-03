using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace mysql.demo.Models
{
    public class ActorContext
    {
        public string ConnectionString {get; set;}
        public ActorContext(string connectionString)
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
                MySqlCommand cmd = new MySqlCommand("Select * from Actor where actor_id < 10", conn);
                
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