using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;

namespace web_members1stAPI.Models
{

    public class Profile
    {
        
        public string Id { get; set; }

        public string username { get; set; }
        public string name { get; set; }
        public string street_address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
        public string home_phone { get; set; }
        public string mobile_Phone { get; set; }
        public string email_Address { get; set; }

    }

   



 
    

    

}
