namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beer", "BreweryName", c => c.String());
            DropColumn("dbo.Beer", "Brewery");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Beer", "Brewery", c => c.String());
            DropColumn("dbo.Beer", "BreweryName");
        }
    }
}
