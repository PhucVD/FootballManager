using System;
using System.ComponentModel.DataAnnotations;
using FootballManager.Common.Enums;
using FootballManager.Common.Extension;

namespace FootballManager.Common.Classes
{
    public class NationViewModel
    {
        public int NationId { get; set; }

        [Display(Name = "Nation")]
        public string NationName { get; set; }

        public Continent Continent { get; set; }

        public string ContinentString => Continent.GetDisplayName();
    }
}
