using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCommands.Models
{
    public class Command
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(250)]
        public string Line { get; set; }
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Platform { get; set; }

    }
}
