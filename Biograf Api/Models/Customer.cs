using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biograf_Api.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
        public string Password { get; set; }
        
    }
}