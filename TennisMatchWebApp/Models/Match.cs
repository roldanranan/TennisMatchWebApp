using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TennisMatchWebApp.Models
{
    public class Match
    {
        public int MatchId { get; set; }

        public int Player1 { get; set; }

        public string P1Name { get; set; }

        public int P1Set1 { get; set; }

        public int P1Set2 { get; set; }

        public int P1Set3 { get; set; }

        public int Player2 { get; set; }

        public string P2Name { get; set; }

        public int P2Set1 { get; set; }

        public int P2Set2 { get; set; }

        public int P2Set3 { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int WinnerId { get; set; }
    }
}