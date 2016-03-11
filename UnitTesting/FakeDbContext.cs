
using System.Data.Entity;
using FootballManager.Data;
using FootballManager.Domain;

namespace UnitTesting
{
    public class FakeFootballContext : DbContext, IFootballContext
    {
        public FakeFootballContext() : base("FakeFootballContext")
        {
            
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Nation> Nations { get; set; }
    }
}
