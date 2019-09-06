using FluentValidation;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WohooDigitalProject.Core.CrossCuttingConcerns.Logging.Log4Net;
using WohooDigitalProject.Core.CrossCuttingConcerns.Validations.FluentValidations;
using WohooDigitalProject.News.Bussiness.Abstract;
using WohooDigitalProject.News.Bussiness.ValidationRules.FluentValidations;
using WohooDigitalProject.News.DataAccess.Abstract;
using WohooDigitalProject.News.Entities.ComplexTypes;
using WohooDigitalProject.News.Entities.Concrete;

namespace WohooDigitalProject.News.Bussiness.Concrete.EntityFramework
{
    public class EFUserService : IUserService
    {
        private IUserDal _userDal;
        private IValidator<User> _validator;

        public EFUserService(IUserDal userDal,IValidator<User> validator)
        {
            _userDal = userDal;
            _validator = validator;
        }
        public void Add(User entity)
        {
            ValidationTool.FluentValidate(new UserValidations(), entity);
            _userDal.Add(entity);
        }

        public void Delete(User entity)
        {
            _userDal.Delete(entity);
        }

        public User Get(int id)
        {
            return _userDal.Get(id);
        }

        public IQueryable<User> GetAll()
        {
            
            LogServices.AddLog("Kullanıcılar Getirildi");   
            return _userDal.GetAll();
        }

        public UserAndRole GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.GetByUserNameAndPassword(userName,password);
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }
    }
}
