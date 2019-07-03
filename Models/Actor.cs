using System;
namespace mysql.demo.Models
{
    public class Actor
    {
        private DbContext context;
        public int ActorId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public DateTime LastUpdate {get; set;}
    }

}