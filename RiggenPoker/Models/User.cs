using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiggenPoker.Models
{
    public class User
    {
        // All Riggen-members, and their yearly score
        public int UserId { get; set; }

        public decimal ScoreAtStartOfYear { get; set; }

        //[ForeignKey("User")]
        public virtual ApplicationUser UserName { get; set; }

    }
}