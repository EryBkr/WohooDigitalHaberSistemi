using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WohooDigitalProject.Core.DataAccess;
using WohooDigitalProject.News.Entities.ComplexTypes;
using WohooDigitalProject.News.Entities.Concrete;

namespace WohooDigitalProject.News.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        UserAndRole GetByUserNameAndPassword(string userName, string password);
    }
}
