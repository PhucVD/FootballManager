namespace FootballManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Continent",
                c => new
                    {
                        ContinentId = c.Int(nullable: false),
                        Code = c.String(maxLength: 2, unicode: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ContinentId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Iso = c.String(maxLength: 2, unicode: false),
                        Iso3 = c.String(maxLength: 3, unicode: false),
                        NumCode = c.Int(),
                        PhoneCode = c.Int(),
                        ContinentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.Continent", t => t.ContinentId)
                .Index(t => t.ContinentId);
            
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
                .ForeignKey("dbo.Team", t => t.FirstTeamId)
                .ForeignKey("dbo.Team", t => t.SecondTeamId)
                .Index(t => t.FirstTeamId)
                .Index(t => t.SecondTeamId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TeamType = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
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
                .ForeignKey("dbo.Country", t => t.CountryId)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Tournament",
                c => new
                    {
                        TournamentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
            DropForeignKey("dbo.Country", "ContinentId", "dbo.Continent");
            DropIndex("dbo.Tournament", new[] { "HostCountryId" });
            DropIndex("dbo.Player", new[] { "CountryId" });
            DropIndex("dbo.Player", new[] { "TeamId" });
            DropIndex("dbo.Team", new[] { "CountryId" });
            DropIndex("dbo.Match", new[] { "SecondTeamId" });
            DropIndex("dbo.Match", new[] { "FirstTeamId" });
            DropIndex("dbo.Country", new[] { "ContinentId" });
            DropTable("dbo.Tournament");
            DropTable("dbo.Player");
            DropTable("dbo.Team");
            DropTable("dbo.Match");
            DropTable("dbo.Country");
            DropTable("dbo.Continent");
        }
    }
}
