using System;
using System.ComponentModel.DataAnnotations;
using FootballManager.Domain;

namespace FootballManager.Web.ViewModels
{
    public class TournamentViewModel
    {
        public int TournamentId { get; set; }

        [Required]
        [Display(Name="Tournament Name")]
        public string TournamentName { get; set; }

        [Required]
        [Display(Name="Tournament Type")]
        public TournamentType TournamentType { get; set; }

        [Required]
        public int Year { get; set; }

        [Display(Name="From Date")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "Host Nation")]
        public int? HostNationId { get; set; }

        public Nation HostNation { get; set; }

        [Required]
        [Display(Name="Status")]
        public ProgressStatus TournamentStatus { get; set; }
    }
}