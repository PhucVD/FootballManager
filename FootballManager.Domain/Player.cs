using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManager.Domain
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name="Player Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "DOB")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Retired")]
        public bool IsRetired { get; set; }

        [Display(Name = "Team")]
        public int? TeamId { get; set; }

        [Display(Name = "Nationality")]
        public int CountryId { get; set; }

        public virtual Team Team { get; set; }

        public virtual Country Nationality { get; set; }
    }
}
