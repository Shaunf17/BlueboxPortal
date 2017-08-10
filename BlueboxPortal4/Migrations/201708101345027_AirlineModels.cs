namespace BlueboxPortal4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AirlineModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airlines",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        NameAlias = c.String(),
                        FriendlyName = c.String(),
                        DisplayName = c.String(),
                        DbName = c.String(),
                        SSRSFolder = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AirlineApplicationUsers",
                c => new
                    {
                        Airline_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Airline_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Airlines", t => t.Airline_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Airline_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AirlineApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AirlineApplicationUsers", "Airline_Id", "dbo.Airlines");
            DropIndex("dbo.AirlineApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AirlineApplicationUsers", new[] { "Airline_Id" });
            DropTable("dbo.AirlineApplicationUsers");
            DropTable("dbo.Airlines");
        }
    }
}
