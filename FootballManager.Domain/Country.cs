using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManager.Domain
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryId { get; set; }

        [Display(Name="Nation")]
        public string CountryName { get; set; }

        public string Iso { get; set; }

        public string Iso3 { get; set; }

        public int? NumCode { get; set; }

        public int? PhoneCode { get; set; }

        public Continent? Continent { get; set; }
    }

}
