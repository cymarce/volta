using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comunicatore
{
    public class DbTestContext : DbContext
    {
        //public DbTestContext() : base("name=Comunicatore.Properties.Settings.TestDBConnectionString")
        public DbTestContext() : base("DbTest")
        {
            Database.SetInitializer<DbTestContext>(new CreateDatabaseIfNotExists<DbTestContext>());
        }

        public DbSet<Test> Tests { get; set; }
    }
}
