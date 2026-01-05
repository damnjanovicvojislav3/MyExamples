using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballRestService.Models
{
    [Table("player")]
    public class Player
    {
        [Key]
        [Column("player_id")]
        public int PlayerId { get; set; }
        

        [Required]
        [Column("name", TypeName = "nvarchar(50)")]
        public string Name { get; set; } = null!;

        [Column("birth_date", TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Column("position", TypeName = "nvarchar(50)")]
        public string? Position { get; set; }

        [Column("team_id")]
        public int TeamId { get; set; }

        public virtual Team? Team { get; set; }
    }
}
