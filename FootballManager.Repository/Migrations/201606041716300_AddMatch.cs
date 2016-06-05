namespace FootballManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMatch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        FirstTeamScore = c.Int(nullable: false),
                        SecondTeamScore = c.Int(nullable: false),
                        FirstTeamId = c.Int(),
                        SecondTeamId = c.Int(),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Team", t => t.FirstTeamId)
                .ForeignKey("dbo.Team", t => t.SecondTeamId)
                .Index(t => t.FirstTeamId)
                .Index(t => t.SecondTeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Match", "SecondTeamId", "dbo.Team");
            DropForeignKey("dbo.Match", "FirstTeamId", "dbo.Team");
            DropIndex("dbo.Match", new[] { "SecondTeamId" });
            DropIndex("dbo.Match", new[] { "FirstTeamId" });
            DropTable("dbo.Match");
        }
    }
}
