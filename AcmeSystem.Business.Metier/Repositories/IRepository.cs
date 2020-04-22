using System.Collections.Generic;


namespace AcmeSystem.Business.Metier.Repositories
{
    public interface IRepository<TRepository>
    {
        TRepository GetById(int id);
        ICollection<TRepository> GetAll();
        TRepository Create(TRepository entity);
        TRepository Update(TRepository entity);
        bool Delete(TRepository entity);
    }
}
