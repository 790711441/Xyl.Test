namespace Xyl.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTreeOrganization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrgId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        ParentId = c.Guid(),
                        Note = c.String(),
                        State = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        LastUpdatedOn = c.DateTime(),
                        LastUpdatedBy = c.String(),
                        Sort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "ParentId", "dbo.Organizations");
            DropIndex("dbo.Organizations", new[] { "ParentId" });
            DropTable("dbo.Organizations");
        }
    }
}
