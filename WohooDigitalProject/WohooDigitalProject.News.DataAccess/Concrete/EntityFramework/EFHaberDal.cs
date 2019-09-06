using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WohooDigitalProject.Core.DataAccess.EntityFramework;
using WohooDigitalProject.News.DataAccess.Abstract;
using WohooDigitalProject.News.Entities.Concrete;

namespace WohooDigitalProject.News.DataAccess.Concrete.EntityFramework
{
    public class EFHaberDal:EFRepositoryBase<WohooContext,Haber>,IHaberDal
    {
    }
}
