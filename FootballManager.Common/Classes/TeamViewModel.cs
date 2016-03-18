using System.ComponentModel.DataAnnotations;
using FootballManager.Common.Enums;
using FootballManager.Common.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FootballManager.Common.Classes
{
    public class TeamViewModel : ITeamEntity
    {
        public int TeamId { get; set; }

        [Display(Name = "Team")]
        public string TeamName { get; set; }
        [Display(Name = "Team Type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TeamType TeamType { get; set; }
        public int NationId { get; set; }
        [Display(Name = "Nation")]
        public string NationName { get; set; }
    }

}
