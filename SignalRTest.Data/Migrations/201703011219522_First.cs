namespace SignalRTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DevTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CampaignName = c.String(),
                        Date = c.DateTime(nullable: false),
                        Clicks = c.Int(nullable: false),
                        Conversions = c.Int(nullable: false),
                        Impressions = c.Int(nullable: false),
                        AffiliateName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DevTests");
        }
    }
}
