namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Username : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.People", "Login", "Username");
        }
        
        public override void Down()
        {
			RenameColumn("dbo.People", "Username", "Login");
		}
	}
}
