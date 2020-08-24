namespace MVCMovieCustWithAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameofmenberShipTypeRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenberShipTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MenberShipTypes", "Name", c => c.String());
        }
    }
}
