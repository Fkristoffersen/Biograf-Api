using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiografApi.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int SeatID { get; set; }
        public int ScreeningID { get; set; }
        public int CustomerID { get; set; }
    }
}