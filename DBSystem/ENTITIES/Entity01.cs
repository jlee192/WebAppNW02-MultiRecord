using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DBSystem.ENTITIES
{
    [Table("Team")]
    public class Entity01
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Coach { get; set; }
        public string AssistantCoach { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
    }
}
