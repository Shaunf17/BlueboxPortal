namespace BlueboxPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelCreation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ApplicationUserAirlines", name: "ApplicationUser_Id", newName: "UserId");
            RenameColumn(table: "dbo.ApplicationUserAirlines", name: "Airline_Id", newName: "AirlineId");
            RenameIndex(table: "dbo.ApplicationUserAirlines", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.ApplicationUserAirlines", name: "IX_Airline_Id", newName: "IX_AirlineId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ApplicationUserAirlines", name: "IX_AirlineId", newName: "IX_Airline_Id");
            RenameIndex(table: "dbo.ApplicationUserAirlines", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.ApplicationUserAirlines", name: "AirlineId", newName: "Airline_Id");
            RenameColumn(table: "dbo.ApplicationUserAirlines", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
