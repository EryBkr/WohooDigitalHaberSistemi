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
using WohooDigitalProject.News.Entities.Concrete;

namespace WohooDigitalProject.News.Bussiness.Concrete.EntityFramework
{
    public class EFHaberService : IHaberService
    {
        IHaberDal _haberDal;
        public EFHaberService(IHaberDal haberDal)
        {
            _haberDal = haberDal;
        }
        public void Add(Haber entity)
        {
            entity.UpdateDate = DateTime.Now;
            ValidationTool.FluentValidate(new HaberValidations(),entity);
            _haberDal.Add(entity);
            LogServices.AddLog("Haber Eklendi");
        }

        public void Delete(Haber entity)
        {
            _haberDal.Delete(entity);
            LogServices.AddLog("Haber Silindi");
        }

        public Haber Get(int id)
        {
            return _haberDal.Get(id);
        }

        public IQueryable<Haber> GetAll()
        {
            LogServices.AddLog("Haberler Getirildi");
            return _haberDal.GetAll();
        }

        public void Update(Haber entity)
        {
            
            entity.UpdateDate = DateTime.Now;
            _haberDal.Update(entity);
            LogServices.AddLog("Haber Güncellendi");
        }
    }
}
