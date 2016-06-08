namespace FootballManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryId = c.Int(nullable: false),
                        CountryName = c.String(),
                        Iso = c.String(),
                        Iso3 = c.String(),
                        NumCode = c.Int(),
                        PhoneCode = c.Int(),
                        Continent = c.Int(),
                    })
                .PrimaryKey(t => t.CountryId);

            CreateTable(
                "dbo.Team",
                c => new
                {
                    TeamId = c.Int(nullable: false, identity: true),
                    TeamName = c.String(),
                    TeamType = c.Int(nullable: false),
                    CountryId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);

            CreateTable(
                "dbo.Match",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        MatchDate = c.DateTime(nullable: false),
                        FirstTeamId = c.Int(nullable: false),
                        SecondTeamId = c.Int(nullable: false),
                        FirstTeamScore = c.Int(),
                        SecondTeamScore = c.Int(),
                        MatchStatus = c.Int(),
                        ResultType = c.Int(),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Team", t => t.FirstTeamId, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.SecondTeamId, cascadeDelete: false)
                .Index(t => t.FirstTeamId)
                .Index(t => t.SecondTeamId);

            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        IsRetired = c.Boolean(nullable: false),
                        TeamId = c.Int(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Tournament",
                c => new
                    {
                        TournamentId = c.Int(nullable: false, identity: true),
                        TournamentName = c.String(),
                        TournamentType = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        FromDate = c.DateTime(),
                        ToDate = c.DateTime(),
                        HostCountryId = c.Int(),
                        TournamentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TournamentId)
                .ForeignKey("dbo.Country", t => t.HostCountryId)
                .Index(t => t.HostCountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tournament", "HostCountryId", "dbo.Country");
            DropForeignKey("dbo.Match", "SecondTeamId", "dbo.Team");
            DropForeignKey("dbo.Match", "FirstTeamId", "dbo.Team");
            DropForeignKey("dbo.Player", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Player", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Team", "CountryId", "dbo.Country");
            DropIndex("dbo.Tournament", new[] { "HostCountryId" });
            DropIndex("dbo.Player", new[] { "CountryId" });
            DropIndex("dbo.Player", new[] { "TeamId" });
            DropIndex("dbo.Team", new[] { "CountryId" });
            DropIndex("dbo.Match", new[] { "SecondTeamId" });
            DropIndex("dbo.Match", new[] { "FirstTeamId" });
            DropTable("dbo.Tournament");
            DropTable("dbo.Player");
            DropTable("dbo.Team");
            DropTable("dbo.Match");
            DropTable("dbo.Country");
        }
    }
}
