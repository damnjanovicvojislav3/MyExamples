using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballRestService.Models
{
    [Table("team")]
    public class Team
    {
        [Key]
        [Column("team_id")]
        public int TeamId { get; set; }
        

        [Required]
        [Column("team_name", TypeName = "nvarchar(50)")]
        public string Name { get; set; } = null!;

        [Column("country", TypeName = "nvarchar(50)")]
        public string? Country { get; set; } = null!;

        public virtual ICollection<Player>? Players { get; set; }
    }
}