namespace TokenBasedReception.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenBasedReceptionAppDBV3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        AddedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        DisplayName = c.String(nullable: false),
                        Description = c.String(),
                        AddedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DiseaseId = c.Long(),
                        AddedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Diseases", t => t.DiseaseId)
                .Index(t => t.DiseaseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "DiseaseId", "dbo.Diseases");
            DropIndex("dbo.Patients", new[] { "DiseaseId" });
            DropTable("dbo.Patients");
            DropTable("dbo.Diseases");
            DropTable("dbo.Users");
        }
    }
}
