using System.Globalization;
using FootballManager.Domain;

namespace UnitTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FakeFootballContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FakeFootballContext context)
        {
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            context.Nations.AddOrUpdate(p => p.NationId,
                new Nation { NationId = 1, NationName = "Italy", Continent = Continent.Europe },
                new Nation { NationId = 2, NationName = "Germany", Continent = Continent.Europe },
                new Nation { NationId = 3, NationName = "Brazil", Continent = Continent.SouthAmerican },
                new Nation { NationId = 4, NationName = "Argentina", Continent = Continent.SouthAmerican },
                new Nation { NationId = 5, NationName = "USA", Continent = Continent.NorthAmerican },
                new Nation { NationId = 6, NationName = "Vietnam", Continent = Continent.Asia },
                new Nation { NationId = 7, NationName = "Portugal", Continent = Continent.Europe },
                new Nation { NationId = 8, NationName = "Sweden", Continent = Continent.Europe }        
            );

            context.Teams.AddOrUpdate(p => p.TeamId,
                new Team { TeamId = 1, TeamName = "Italy", NationId = 1, TeamType = TeamType.Nation},
                new Team { TeamId = 2, TeamName = "Germany", NationId = 2, TeamType = TeamType.Nation },
                new Team { TeamId = 3, TeamName = "Brazil", NationId = 3, TeamType = TeamType.Nation },
                new Team { TeamId = 4, TeamName = "Argentina", NationId = 4, TeamType = TeamType.Nation }           
            );

            context.Players.AddOrUpdate(p => p.PlayerId,
                new Player { PlayerId = 1, FirstName = "Lionel", LastName = "Messi", DateOfBirth = DateTime.Parse("01/01/1987", CultureInfo.CurrentCulture), NationId = 4 },
                new Player { PlayerId = 2, FirstName = "Cristiano", LastName = "Ronaldo", DateOfBirth = DateTime.Parse("10/03/1985", CultureInfo.CurrentCulture), NationId = 7 },
                new Player { PlayerId = 3, FirstName = "Zlatan", LastName = "Ibrahimovic", DateOfBirth = DateTime.Parse("03/10/1981", CultureInfo.CurrentCulture), NationId = 8 }
            );

            context.SaveChanges();
        }
    }
}
