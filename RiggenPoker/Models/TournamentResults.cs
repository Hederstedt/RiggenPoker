using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RiggenPoker.Models
{
    public class TournamentResults
    {
        [Key]
        public int Id { get; set; }

        public decimal UserScore { get; set; }

        public int UserLadder { get; set; }
        
        //[ForeignKey("Tournament")]
        public virtual Tournament TournamentId { get; set; }

        //[ForeignKey("TournamentRotY")]
        public virtual RiggenOfTheYear RotYId { get; set; }

        //[ForeignKey("ApplicationUser")]
        public virtual ApplicationUser RegisteredUser { get; set; }

        ////[ForeignKey("GuestUser")]
        //public virtual GuestUser GuestUser { get; set; }


    }
}