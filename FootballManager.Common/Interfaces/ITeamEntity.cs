using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballManager.Common.Enums;

namespace FootballManager.Common.Interfaces
{
    public interface ITeamEntity
    {
        int TeamId { get; set; }
        string TeamName { get; set; }
        TeamType TeamType { get; set; }
        int NationId { get; set; }
    }
}
