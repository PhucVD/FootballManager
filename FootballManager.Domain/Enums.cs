using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Domain
{

    public enum Continent
    {
        Asia = 1,
        Africa,
        Europe,
        SouthAmerican,
        NorthAmerican,
        Oceania
    }

    public enum TournamentType
    {
        [Display(Name = "World Cup")]
        WorldCup = 1,

        Euro,

        [Display(Name="Copa America")]
        CopaAmerica,

        [Display(Name="Asian Cup")]
        AsianCup,

        [Display(Name="Champions League")]
        ChampionsLeague,

        [Display(Name="Europa League")]
        EuropaLeague
    }

    public enum MatchResultType
    {
        NotDefined,
        FirstTeamWin,
        Draw,
        SecondTeamWin
    }

    public enum ProgressStatus
    {
        [Display(Name = "Not Occurred")]
        NotOccurred = 1,

        Ongoing,

        Finished
    }

    public enum TeamType
    {
        Nation = 1,
        Club
    }
}
