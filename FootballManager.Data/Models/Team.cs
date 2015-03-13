using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [Display(Name = "Team")]
        public string TeamName { get; set; }

        public string Nation { get; set; }
    }
}
