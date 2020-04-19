using System;
using System.Collections.Generic;
using System.Linq;

namespace AcmeSystem.Business.Metier.Services
{
    public interface IService<TService>
    {
        ICollection<TService> GetAll();
    }
}
