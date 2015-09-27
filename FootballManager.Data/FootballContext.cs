﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FootballManager.Domain;

namespace FootballManager.Data
{
    public class FootballContext : DbContext
    {
        public FootballContext()
            : base("FootballContext")
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Nation> Nations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
