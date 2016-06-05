using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Domain
{
    public class Tournament
    {
        public int TournamentId { get; set; }

        public string TournamentName { get; set; }

        public TournamentType TournamentType { get; set; }

        public int Year { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int? HostNationId { get; set; }

        [ForeignKey("HostNationId")]
        public Nation HostNation { get; set; }

        public ProgressStatus TournamentStatus { get; set; }

    }

}
