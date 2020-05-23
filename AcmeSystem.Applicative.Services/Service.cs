using System;
using System.Collections.Generic;
using System.Linq;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Business.Metier.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AcmeSystem.Applicative.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Model
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            Console.WriteLine("Services Normaux\n");
            _repository = repository;
        }

        public bool Delete(TEntity entity)
        {
            return _repository.Delete(entity);
        }

        public ICollection<TEntity> GetAll(string includes = "")
        {
            return _repository.Get(null, null, includes);
        }

        public TEntity GetId(int id, string includes = "")
        {
            return _repository.Get(e => e.Id == id, null, includes).First();
        }

        public TEntity Create(TEntity entity)
        {
            return _repository.Create(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }
        public TEntity Save(TEntity entity)
        {
            if (entity.IsNew)
            {
                return _repository.Create(entity);
            }
            else
            {
                return _repository.Update(entity);
            }
        }
    }
}
