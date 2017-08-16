namespace Xyl.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOgr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "Name", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Organizations", "Note");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "Note", c => c.String());
            AlterColumn("dbo.Organizations", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
