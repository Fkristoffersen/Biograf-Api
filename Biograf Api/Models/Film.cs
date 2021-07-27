using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiografApi.Models
{
    public class Film
    {
        public int FilmID { get; set; }
        public string Titel { get; set; }
        public string RunTime { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}