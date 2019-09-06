using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WohooDigitalProject.Core.Entities;

namespace WohooDigitalProject.Core.DataAccess.EntityFramework
{
    public class EFRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        TContext _context;
        private DbSet<TEntity> _objectSet;

        public EFRepositoryBase()
        {
            _context = SingletonRepository<TContext>.CreateDatabase();
            _objectSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _objectSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _objectSet.Remove(entity);
            _context.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return _objectSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _objectSet;
        }

        public void Update(TEntity entity)
        {
            _objectSet.AddOrUpdate(entity);
            _context.SaveChanges();
        }
    }
}
