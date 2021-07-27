using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biograf_Api.Models
{

    

    public class CandyShop
    {
        public int CandyID { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int Price { get; set; }
        public string Picture { get; set; }
    }
}