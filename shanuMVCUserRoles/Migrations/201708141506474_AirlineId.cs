namespace BlueboxPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AirlineId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Airlines");
            AlterColumn("dbo.Airlines", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Airlines", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Airlines");
            AlterColumn("dbo.Airlines", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Airlines", "Id");
        }
    }
}
