namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beer",
                c => new
                    {
                        BeerID = c.Guid(nullable: false),
                        BeerName = c.String(nullable: false),
                        Brewery = c.String(),
                        Style = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ABV = c.Single(nullable: false),
                        Vintage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BeerID);
            
            CreateTable(
                "dbo.Brewery",
                c => new
                    {
                        BreweryID = c.Guid(nullable: false),
                        BreweryName = c.String(nullable: false),
                        BrewLocState = c.String(nullable: false),
                        BrewLocCity = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BreweryID);
            
            CreateTable(
                "dbo.Drinker",
                c => new
                    {
                        DrinkerID = c.Guid(nullable: false),
                        FName = c.String(),
                        LName = c.String(),
                        UserName = c.String(nullable: false),
                        LocationState = c.String(),
                        LocationCity = c.String(),
                        FavoriteBeer = c.String(),
                        FavoriteBrewery = c.String(),
                        Age = c.Int(nullable: false),
                        NoOfTastings = c.Int(nullable: false),
                        ProfileCreated = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.DrinkerID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Tasting",
                c => new
                    {
                        TastingID = c.Guid(nullable: false),
                        DrinkerID = c.Guid(nullable: false),
                        BeerID = c.Guid(nullable: false),
                        BreweryID = c.Guid(nullable: false),
                        DateOfTasting = c.DateTimeOffset(nullable: false, precision: 7),
                        DateAdded = c.DateTimeOffset(nullable: false, precision: 7),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.TastingID)
                .ForeignKey("dbo.Beer", t => t.BeerID, cascadeDelete: true)
                .ForeignKey("dbo.Brewery", t => t.BreweryID, cascadeDelete: true)
                .ForeignKey("dbo.Drinker", t => t.DrinkerID, cascadeDelete: true)
                .Index(t => t.DrinkerID)
                .Index(t => t.BeerID)
                .Index(t => t.BreweryID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Tasting", "DrinkerID", "dbo.Drinker");
            DropForeignKey("dbo.Tasting", "BreweryID", "dbo.Brewery");
            DropForeignKey("dbo.Tasting", "BeerID", "dbo.Beer");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Tasting", new[] { "BreweryID" });
            DropIndex("dbo.Tasting", new[] { "BeerID" });
            DropIndex("dbo.Tasting", new[] { "DrinkerID" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Tasting");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Drinker");
            DropTable("dbo.Brewery");
            DropTable("dbo.Beer");
        }
    }
}
