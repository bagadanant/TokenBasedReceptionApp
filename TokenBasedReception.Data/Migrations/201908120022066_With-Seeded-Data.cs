namespace TokenBasedReception.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WithSeededData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "IsFollowUp", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "City");
            DropColumn("dbo.Appointments", "IsFollowUp");
        }
    }
}
