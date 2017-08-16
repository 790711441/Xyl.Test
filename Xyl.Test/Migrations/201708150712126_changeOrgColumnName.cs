namespace Xyl.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeOrgColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Organizations", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Organizations", "Name");
        }
    }
}
