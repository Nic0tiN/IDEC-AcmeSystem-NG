using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AcmeSystem.Business.Metier.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        ICollection<TEntity> GetAll();

        ICollection<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        // ICollection<TRepository> GetAll<TModel>();
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}
