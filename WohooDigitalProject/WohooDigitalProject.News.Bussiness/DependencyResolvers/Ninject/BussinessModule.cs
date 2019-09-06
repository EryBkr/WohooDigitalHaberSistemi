using FluentValidation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WohooDigitalProject.News.Bussiness.Abstract;
using WohooDigitalProject.News.Bussiness.Concrete.EntityFramework;
using WohooDigitalProject.News.Bussiness.ValidationRules.FluentValidations;
using WohooDigitalProject.News.DataAccess.Abstract;
using WohooDigitalProject.News.DataAccess.Concrete.EntityFramework;
using WohooDigitalProject.News.Entities.Concrete;

namespace WohooDigitalProject.News.Bussiness.DependencyResolvers.Ninject
{
    public class BussinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<EFUserService>().InSingletonScope();
            Bind<IUserDal>().To<EFUserDal>().InSingletonScope();

            Bind<IHaberDal>().To<EFHaberDal>().InSingletonScope();
            Bind<IHaberService>().To<EFHaberService>().InSingletonScope();

            Bind<IValidator<User>>().To<UserValidations>().InSingletonScope();
        }
    }
}
