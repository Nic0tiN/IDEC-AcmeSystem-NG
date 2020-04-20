using System.Collections.Generic;


namespace AcmeSystem.Business.Metier.Repositories
{
    public interface IRepository<TRepository>
    {
        TRepository GetById(int id);
        ICollection<TRepository> GetAll();
    }
}
