using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RiggenPoker.Models
{
    public class Result
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int History { get; set; }
        public int TotalScore { get; set; }
        public int NewScore { get; set; }
        public virtual ApplicationUser UserName { get; set; }
    }
}


