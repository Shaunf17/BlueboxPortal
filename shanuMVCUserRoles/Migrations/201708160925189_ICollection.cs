namespace BlueboxPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ICollection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserAirlines",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Airline_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Airline_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Airlines", t => t.Airline_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Airline_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserAirlines", "Airline_Id", "dbo.Airlines");
            DropForeignKey("dbo.ApplicationUserAirlines", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserAirlines", new[] { "Airline_Id" });
            DropIndex("dbo.ApplicationUserAirlines", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserAirlines");
        }
    }
}
