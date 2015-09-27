using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Domain
{
    public class Team
    {
        public int TeamId { get; set; }

        [Display(Name = "Team")]
        public string TeamName { get; set; }

        [Display(Name="Team Type")]
        public TeamType TeamType { get; set; }

        [Display(Name="Nation")]
        public int NationId { get; set; }

        public virtual Nation Nation { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }

    public enum TeamType
    {
        Nation = 1,
        Club
    }
}
