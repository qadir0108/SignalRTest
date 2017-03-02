namespace SignalRTest.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SignalRTest.Data.DevTestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SignalRTest.Data.DevTestContext context)
        {
            //  This method will be called after migrating to the latest version.

            var CampaignName = "Test Compaign";
            if (
                context.DevTests.FirstOrDefault(
                    x => x.CampaignName.Equals(CampaignName, StringComparison.InvariantCultureIgnoreCase)) == null)
            {
                context.DevTests.AddOrUpdate(new DevTest()
                {
                    CampaignName = CampaignName,
                    AffiliateName = "Affiliate Marketer",
                    Date = DateTime.Now,
                    Clicks = 10,
                    Conversions = 100,
                    Impressions = 1000
                });
                context.SaveChanges();
            }
        }
    }
}
