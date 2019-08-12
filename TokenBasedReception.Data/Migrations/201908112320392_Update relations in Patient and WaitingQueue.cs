namespace TokenBasedReception.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdaterelationsinPatientandWaitingQueue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        BookedSlot = c.DateTime(),
                        Duration = c.Time(precision: 7),
                        PatientId = c.Long(nullable: false),
                        DoctorId = c.Long(nullable: false),
                        AddedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        AddedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WaitingQueue",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        TokenNumber = c.Int(nullable: false),
                        AppointmentId = c.Long(),
                        AddedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Appointments", t => t.ID)
                .Index(t => t.ID);
            
            AddColumn("dbo.Diseases", "Appointment_ID", c => c.Long());
            CreateIndex("dbo.Diseases", "Appointment_ID");
            AddForeignKey("dbo.Diseases", "Appointment_ID", "dbo.Appointments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WaitingQueue", "ID", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Diseases", "Appointment_ID", "dbo.Appointments");
            DropIndex("dbo.WaitingQueue", new[] { "ID" });
            DropIndex("dbo.Diseases", new[] { "Appointment_ID" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropColumn("dbo.Diseases", "Appointment_ID");
            DropTable("dbo.WaitingQueue");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
