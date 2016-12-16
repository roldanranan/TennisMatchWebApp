using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TennisMatchWebApp.Models
{
    public class Search
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime? Date { get; set; }
    }
}