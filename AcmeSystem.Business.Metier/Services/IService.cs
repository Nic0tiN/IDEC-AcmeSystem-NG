using System.Collections.Generic;

namespace AcmeSystem.Business.Metier.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        ICollection<TEntity> GetAll(string includes = "");
        TEntity GetId(int id, string includes = "");
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Save(TEntity entity);
        bool Delete(TEntity entity);
    }
}
