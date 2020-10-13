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
        //public DbTestContext() : base("DbTest")

        //public DbTestContext() 
        {
            //Database.SetInitializer<DbTestContext>(new CreateDatabaseIfNotExists<DbTestContext>());
        }

        public DbSet<Test> Tests { get; set; }
    }
}
