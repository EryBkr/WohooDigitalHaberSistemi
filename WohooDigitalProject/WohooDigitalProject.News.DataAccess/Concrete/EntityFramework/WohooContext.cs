using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WohooDigitalProject.News.Entities.Concrete;

namespace WohooDigitalProject.News.DataAccess.Concrete.EntityFramework
{
    public class WohooContext:DbContext
    {
        public WohooContext():base("WohooDatabase")
        {
            Database.SetInitializer(new MyInitilaizer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Haber> New { get; set; }
    }
}
