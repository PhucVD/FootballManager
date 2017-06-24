using System;
using System.ComponentModel.DataAnnotations;
using FootballManager.Domain;

namespace FootballManager.Web.Models
{
    public class TournamentViewModel
    {
        public int TournamentId { get; set; }

        [Required]
        [Display(Name="Tournament Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Tournament Type")]
        public TournamentType TournamentType { get; set; }

        [Required]
        public int Year { get; set; } = DateTime.Now.Year;

        [Display(Name = "From Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FromDate { get; set; } = DateTime.Now;

        [Display(Name = "To Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "Host")]
        public int? HostCountryId { get; set; }

        public Country Host { get; set; }

        [Required]
        [Display(Name="Status")]
        public ProgressStatus TournamentStatus { get; set; }
    }
}