using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManager.Domain
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [StringLength(100)]
        [Display(Name="Nation")]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(2)]
        public string Iso { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(3)]
        public string Iso3 { get; set; }

        public int? NumCode { get; set; }

        public int? PhoneCode { get; set; }

        public int ContinentId { get; set; }

        [ForeignKey("ContinentId")]
        public Continent Continent { get; set; }
    }

}
