namespace CharityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDateAddition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CharityPrograms", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CharityPrograms", "CreateDate");
        }
    }
}
