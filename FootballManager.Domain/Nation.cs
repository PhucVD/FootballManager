using System.ComponentModel.DataAnnotations;
using FootballManager.Common.Enums;

namespace FootballManager.Domain
{
    public class Nation
    {
        public int NationId { get; set; }

        [Display(Name="Nation")]
        public string NationName { get; set; }

        public Continent Continent { get; set; }
    }
}
