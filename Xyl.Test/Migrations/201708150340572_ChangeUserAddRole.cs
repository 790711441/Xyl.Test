namespace Xyl.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserAddRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "ShowName", c => c.String(maxLength: 20));
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "ShowName", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ShowName");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "ShowName");
        }
    }
}
