using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Token
    {

        public int Id { get; set; }

        public string userEmail { get; set; }

        public string data { get; set; }

        public Functions function { get; set; }

        public DateTime Date1 { get; set; }

        public DateTime Date2 { get; set; }

        public Token(string userEmail, string data, Functions function, DateTime date1, DateTime date2)
        {
            this.userEmail = userEmail;
            this.data = data;
            this.function = function;
            Date1 = date1;
            Date2 = date2;
        }
    }
}
