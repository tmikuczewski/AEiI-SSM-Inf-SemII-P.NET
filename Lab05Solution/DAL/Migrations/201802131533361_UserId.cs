namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.People");
			DropColumn("dbo.People", "Id");
            AddColumn("dbo.People", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.People", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Name", c => c.String(nullable: false));
            AddPrimaryKey("dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.People", "Name", c => c.String());
            AlterColumn("dbo.People", "Password", c => c.String());
            AlterColumn("dbo.People", "Login", c => c.String());
	        DropColumn("dbo.People", "Id");
            AddColumn("dbo.People", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.People", "Id");
        }
    }
}
