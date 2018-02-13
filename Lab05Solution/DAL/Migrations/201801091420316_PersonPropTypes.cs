namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonPropTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Login", c => c.String());
            AlterColumn("dbo.People", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Password", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "Login", c => c.Int(nullable: false));
        }
    }
}
