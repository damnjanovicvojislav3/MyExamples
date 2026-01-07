using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballRestService.Models
{
    [Table("match")]
    public class Match
    {
        [Key]
        [Column("match_id")]
        public int MatchId { get; set; }

        [Column("home_team_id")]
        public int HomeTeamId { get; set; }

        [ForeignKey(nameof(HomeTeamId))]
        public virtual Team? HomeTeam { get; set; }

        [Column("away_team_id")]
        public int AwayTeamId { get; set; }

        [ForeignKey(nameof(AwayTeamId))]
        public virtual Team? AwayTeam { get; set; }

        [Column("match_date", TypeName = "date")]
        public DateTime MatchDate { get; set; }

        [Column("home_score")]
        public int? HomeScore { get; set; }

        [Column("away_score")]
        public int? AwayScore { get; set; }
    }
}
