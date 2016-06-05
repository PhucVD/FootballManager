namespace FootballManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nation",
                c => new
                    {
                        NationId = c.Int(nullable: false, identity: true),
                        NationName = c.String(),
                        Continent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NationId);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        TeamId = c.Int(),
                        NationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Nation", t => t.NationId, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.NationId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        NationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Nation", t => t.NationId, cascadeDelete: true)
                .Index(t => t.NationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Player", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Team", "NationId", "dbo.Nation");
            DropForeignKey("dbo.Player", "NationId", "dbo.Nation");
            DropIndex("dbo.Team", new[] { "NationId" });
            DropIndex("dbo.Player", new[] { "NationId" });
            DropIndex("dbo.Player", new[] { "TeamId" });
            DropTable("dbo.Team");
            DropTable("dbo.Player");
            DropTable("dbo.Nation");
        }
    }
}
