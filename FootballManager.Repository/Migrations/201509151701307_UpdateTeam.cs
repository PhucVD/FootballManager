namespace FootballManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTeam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Team", "TeamType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Team", "TeamType");
        }
    }
}
