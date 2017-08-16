namespace Xyl.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOrgColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Organizations", "OrgId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "OrgId", c => c.Guid(nullable: false));
        }
    }
}
