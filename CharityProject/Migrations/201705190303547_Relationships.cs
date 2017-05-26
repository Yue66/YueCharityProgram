namespace CharityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationships : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Donations", "Id");
            AddForeignKey("dbo.Donations", "Id", "dbo.CharityPrograms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "Id", "dbo.CharityPrograms");
            DropIndex("dbo.Donations", new[] { "Id" });
        }
    }
}
