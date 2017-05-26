namespace CharityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharityPrograms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        MoneyGoal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BankAccountNumber = c.Int(nullable: false),
                        MoneyAlreadyGot = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmergencyLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        DonationId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DonationDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DonationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Donations");
            DropTable("dbo.CharityPrograms");
        }
    }
}
