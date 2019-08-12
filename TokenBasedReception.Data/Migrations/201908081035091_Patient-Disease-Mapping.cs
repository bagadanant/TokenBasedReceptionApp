namespace TokenBasedReception.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientDiseaseMapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "DiseaseId", "dbo.Diseases");
            DropIndex("dbo.Patients", new[] { "DiseaseId" });
            CreateTable(
                "dbo.DiseasePatients",
                c => new
                    {
                        Disease_ID = c.Long(nullable: false),
                        Patient_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Disease_ID, t.Patient_ID })
                .ForeignKey("dbo.Diseases", t => t.Disease_ID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_ID, cascadeDelete: true)
                .Index(t => t.Disease_ID)
                .Index(t => t.Patient_ID);
            
            DropColumn("dbo.Patients", "DiseaseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "DiseaseId", c => c.Long());
            DropForeignKey("dbo.DiseasePatients", "Patient_ID", "dbo.Patients");
            DropForeignKey("dbo.DiseasePatients", "Disease_ID", "dbo.Diseases");
            DropIndex("dbo.DiseasePatients", new[] { "Patient_ID" });
            DropIndex("dbo.DiseasePatients", new[] { "Disease_ID" });
            DropTable("dbo.DiseasePatients");
            CreateIndex("dbo.Patients", "DiseaseId");
            AddForeignKey("dbo.Patients", "DiseaseId", "dbo.Diseases", "ID");
        }
    }
}
