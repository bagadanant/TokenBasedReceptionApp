namespace TokenBasedReception.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientAddedPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "PhoneNumber");
        }
    }
}
