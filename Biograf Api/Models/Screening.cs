using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiografApi.Models
{
    public class Screening
    {
        public int ScreeningID { get; set; }
        public int Hall { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int FilmID { get; set; }
    }
}