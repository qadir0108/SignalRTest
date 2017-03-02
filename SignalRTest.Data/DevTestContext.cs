using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRTest.Data.Migrations;

namespace SignalRTest.Data
{
    public class DevTestContext : DbContext
    {

        public DevTestContext() : base("DevTestContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DevTestContext, Configuration>());
        }

        protected void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<DevTest> DevTests { get; set; }

        public static DevTestContext Create()
        {
            return new DevTestContext();
        }
    }
}
