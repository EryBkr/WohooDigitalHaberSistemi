using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WohooDigitalProject.News.Entities.Concrete;

namespace WohooDigitalProject.News.DataAccess.Concrete.EntityFramework
{
    public class MyInitilaizer:DropCreateDatabaseIfModelChanges<WohooContext>
    {
        protected override void Seed(WohooContext context)
        {
            List<Haber> haberler = new List<Haber>()
            {
                new Haber(){Title="Haber 1",Description="Güzel Haber",Image="haber-1.jpg",IsActive=true,OrderNumber=1,UpdateDate=DateTime.Now},
                new Haber(){Title="Haber 2",Description="Güzel Haber 2",Image="haber-1.jpg",IsActive=true,OrderNumber=2,UpdateDate=DateTime.Now}
            };

            foreach (var item in haberler)
            {
                context.New.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
