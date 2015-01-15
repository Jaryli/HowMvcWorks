using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CRM.Dao
{
    public class CRMDbContext : DbContext
    {
        public CRMDbContext()
            : base("CrmConnection")
        {
            Database.SetInitializer<CRMDbContext>(new MigrateDatabaseToLatestVersion<CRMDbContext, Migrations.Configuration>());
        }
        public DbSet<CRM.Model.Customer> CustomerSet { get; set; }
        public DbSet<CRM.Model.CustomerAddress> CustomerAddressSet { get; set; }
    }
}
