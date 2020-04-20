using System;
using System.Collections.Generic;
using System.Linq;

namespace AcmeSystem.Business.Metier.Services
{
    public interface IService<TEntity>
    {
        ICollection<TEntity> GetAll();
        TEntity GetId(int id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}
