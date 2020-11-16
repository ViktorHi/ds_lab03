using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class User
    {


        public User(string login, string password)
        {
            Id = login;
            Password = password;
        }

        public string Id { get; set; }


        public string Password { get; set; }
    }
}
