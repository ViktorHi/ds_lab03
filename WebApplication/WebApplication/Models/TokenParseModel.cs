using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class TokenParseModel
    {


        public bool Get { get; set; }
        public bool Create { get; set; }
        public bool Delete { get; set; }
        public bool Edit { get; set; }
        public string Day1 { get; set; }

        public string Day2 { get; set; }
    }
}
