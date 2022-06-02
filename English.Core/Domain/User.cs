using English.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Collection> Collection { get; set; } = new List<Collection>();

        protected User()
        {

        }
        public User(string name, string username, string email, Guid id)
        {
            Name = name;
            UserName = username;
            Email = email;
            Id = id;
        }
        public User(string name, string username, string password, string email, Guid id)
        {
            Name = name;
            UserName = username;
            Password = password;
            Email = email;
            Id = id;
        }
    }
}
