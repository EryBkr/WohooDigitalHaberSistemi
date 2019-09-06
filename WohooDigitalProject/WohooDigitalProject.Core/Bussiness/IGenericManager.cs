using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WohooDigitalProject.Core.Entities;

namespace WohooDigitalProject.Core.Bussiness
{
    public interface IGenericManager<T> where T : class, IEntity, new()
    {
        IQueryable<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
