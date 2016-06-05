using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Domain
{
    public class Match
    {
        public int MatchId { get; set; }

        public DateTime MatchDate { get; set; }

        [Column("FirstTeamId")]
        public Team FirstTeam { get; set; }

        [Column("SecondTeamId")]
        public Team SecondTeam { get; set; }

        public int FirstTeamScore { get; set; }

        public int SecondTeamScore { get; set; }

        public string Score => $"{FirstTeamScore} - {SecondTeamScore}";

        public ProgressStatus MatchStatus { get; set; }

        public MatchResultType ResultType { get; set; }

    }

}
