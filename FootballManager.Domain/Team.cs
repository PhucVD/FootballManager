using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Domain
{
    public class Team
    {
        public int TeamId { get; set; }

        [Display(Name = "Team")]
        public string Name { get; set; }

        [Display(Name="Team Type")]
        public TeamType TeamType { get; set; }

        [Display(Name= "Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }

}