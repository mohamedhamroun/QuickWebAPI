using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AssWebApi.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class quickContext: DbContext
    {

        public quickContext()
            : base("QuickContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Remorqueur> Remorqueurs { get; set; }
        public DbSet<Alerte> Alertes { get; set; }
        public DbSet<AlerteRemorqueur> AlerteRemorqueurs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    
    }
}