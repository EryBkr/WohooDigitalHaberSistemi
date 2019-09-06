using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WohooDigitalProject.Core.DataAccess.EntityFramework;
using WohooDigitalProject.News.DataAccess.Abstract;
using WohooDigitalProject.News.Entities.ComplexTypes;
using WohooDigitalProject.News.Entities.Concrete;

namespace WohooDigitalProject.News.DataAccess.Concrete.EntityFramework
{
    public class EFUserDal : EFRepositoryBase<WohooContext, User>, IUserDal
    {
        public UserAndRole GetByUserNameAndPassword(string userName, string password)
        {
            using (WohooContext context=new WohooContext())
            {
                var user = context.Users.Where(i => i.UserName == userName && i.Password == password).Select(i => new UserAndRole { UserName = i.UserName, EMail = i.EMail, Password = i.Password}).FirstOrDefault();
                return user;

            }
        }
    }
}
