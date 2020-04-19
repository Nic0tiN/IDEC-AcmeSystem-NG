using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeSystem.Business.Metier.Repositories
{
    public interface IRepository<TRepository>
    {
        TRepository GetById(int id);
        ICollection<TRepository> GetAll();
    }
}
