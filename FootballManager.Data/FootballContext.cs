using System.Data.Entity;
using FootballManager.Data.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FootballManager.Data
{
    public class FootballContext : DbContext
    {
        public FootballContext()
            : base("FootballContext")
        {

        }

        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
