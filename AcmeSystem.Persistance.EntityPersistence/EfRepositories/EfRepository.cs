using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AcmeSystem.Business.Metier.Repositories;
using Microsoft.EntityFrameworkCore;
using AcmeSystem.Business.Metier.DbContext;
using AcmeSystem.Business.Metier.Model;

namespace AcmeSystem.Persistence.EntityPersistence.EfRepositories
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AcmeContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EfRepository(AcmeContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<TEntity>();
        }

        public ICollection<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public TEntity Create(TEntity entity)
        {
            entity = (TEntity) _context.Add<TEntity>(entity).Entity;
            var created = _context.SaveChanges();

            return entity;
        }

        public bool Delete(TEntity entity)
        {
            _context.Remove<TEntity>(entity);

            return _context.SaveChanges() > 0;
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public virtual ICollection<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Update(TEntity entity)
        {
            entity = (TEntity) _context.Update<TEntity>(entity).Entity;
            _context.SaveChanges();

            return entity;
        }

        public ICollection<TEntity> GetAll<TModel>()
        {
            throw new System.NotImplementedException();
        }
    }
}
