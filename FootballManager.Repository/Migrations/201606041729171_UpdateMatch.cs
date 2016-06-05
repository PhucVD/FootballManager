namespace FootballManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Match", "MatchDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Match", "IsFinished", c => c.Boolean(nullable: false));
            AddColumn("dbo.Match", "ResultType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Match", "MatchDate");
            DropColumn("dbo.Match", "ResultType");
            DropColumn("dbo.Match", "IsFinished");
        }
    }
}
