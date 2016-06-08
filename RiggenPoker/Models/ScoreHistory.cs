using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiggenPoker.Models
{
    public class ScoreHistory
    {
        public int ScoreHistoryId { get; set; }

        public int Year { get; set; }

        public decimal Score { get; set; }

        public virtual ApplicationUser RegisteredUser { get; set; }
    }
}