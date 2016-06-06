namespace FootballManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTournament : DbMigration
    {
        public override void Up()
        {
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
                        HostNationId = c.Int(),
                        TournamentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TournamentId)
                .ForeignKey("dbo.Nation", t => t.HostNationId)
                .Index(t => t.HostNationId);
            
            AddColumn("dbo.Match", "MatchStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tournament", "HostNationId", "dbo.Nation");
            DropIndex("dbo.Tournament", new[] { "HostNationId" });
            DropColumn("dbo.Match", "MatchStatus");
            DropTable("dbo.Tournament");
        }
    }
}
