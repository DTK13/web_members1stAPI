using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_members1stAPI.Models
{
    public class Account
    {
        public string Id { get; set; }

        public string username { get; set; }

        public string description { get; set; }

        public double balance { get; set; }

        public string lastActivityDate { get; set; }
    }
}
