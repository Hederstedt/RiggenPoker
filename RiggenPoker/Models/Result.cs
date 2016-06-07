﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiggenPoker.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public decimal History { get; set; }
        public decimal TotalScore { get; set; }
        public decimal NewScore { get; set; }
        //[ForeignKey("ApplicationUser")]
        public int UserNameId { get; set; }
        public virtual ApplicationUser UserName { get; set; }
    }
}

