namespace BlueboxPortal4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AirlineApplicationUsers", newName: "ApplicationUserAirlines");
            DropPrimaryKey("dbo.ApplicationUserAirlines");
            AddPrimaryKey("dbo.ApplicationUserAirlines", new[] { "ApplicationUser_Id", "Airline_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ApplicationUserAirlines");
            AddPrimaryKey("dbo.ApplicationUserAirlines", new[] { "Airline_Id", "ApplicationUser_Id" });
            RenameTable(name: "dbo.ApplicationUserAirlines", newName: "AirlineApplicationUsers");
        }
    }
}
