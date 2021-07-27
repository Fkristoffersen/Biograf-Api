using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiografApi.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int CustomerID { get; set; }
        public int ReservationID { get; set; }
        public int ScreeningID { get; set; }
        public int OrderID { get; set; }

    }
}