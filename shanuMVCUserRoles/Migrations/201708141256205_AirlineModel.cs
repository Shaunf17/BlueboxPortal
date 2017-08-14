namespace BlueboxPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AirlineModel : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Airlines");
        }
    }
}
