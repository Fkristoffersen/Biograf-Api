using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiografApi.Models
{
    public class ShoppingCart
    {
        public int CartID { get; set; }
        public int CustomerID { get; set; }
        public int OrderID { get; set; }
        public int CandyID { get; set; }
        public int Total { get; set; }
    }
}