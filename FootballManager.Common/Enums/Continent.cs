using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Common.Enums
{
    public enum Continent
    {
        Asia = 1,
        Africa,
        Europe,
        [Display(Name = "South American")]
        SouthAmerican,
        [Display(Name = "North American")]
        NorthAmerican,
        Oceania
    }
}
