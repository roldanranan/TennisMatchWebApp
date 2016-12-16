using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TennisMatchWebApp.Models
{
    public class PopulateSearch
    {
        public IEnumerable<string> Players { get; set; }

        public IEnumerable<string> Locations { get; set; }

        public IEnumerable<DateTime> Dates { get; set; }
    }
}