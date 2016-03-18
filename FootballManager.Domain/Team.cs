using System.Collections.Generic;
using FootballManager.Common.Enums;
using FootballManager.Common.Interfaces;

namespace FootballManager.Domain
{
    public class Team : ITeamEntity
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public TeamType TeamType { get; set; }

        public int NationId { get; set; }

        public virtual Nation Nation { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
