using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace RiggenPoker.Models
{
    // For GuestPlayers who enters Riggen (or other tournaments) without membership
    public class GuestUser
    {
        public int GuestUserId { get; set; }

        [MaxLength(256)]
        public string GuestUserName { get; set; }

        public int ScoreAtStartOfYear { get; set; }
    }
}