namespace FootballManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "IsRetired", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "IsRetired");
        }
    }
}
