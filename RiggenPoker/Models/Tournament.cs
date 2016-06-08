using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiggenPoker.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }

        public string TournamentName { get; set; }

        public DateTime Date { get; set; }
    }
}