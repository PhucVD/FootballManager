using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Domain
{
    public class Continent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContinentId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(2)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

    }
}
