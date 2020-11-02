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
        public DbTestContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Globali.dblocation + @"\TestDB.mdf;Integrated Security=True;Connect Timeout=5")
        {
            //Database.SetInitializer<DbTestContext>(new CreateDatabaseIfNotExists<DbTestContext>());
            //Database.SetInitializer<DbTestContext>(new DropCreateDatabaseIfModelChanges<DbTestContext>());
            Database.SetInitializer<DbTestContext>(null);
        }
        public DbSet<Test> Tests { get; set; }
    }
}
