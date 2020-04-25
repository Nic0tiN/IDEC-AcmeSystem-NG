using System;
using System.Collections.Generic;
using System.Text;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Business.Metier.Services;

namespace AcmeSystem.Applicative.Services
{
    public class Service<TEntity> : IService<TEntity>
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

        public ICollection<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetId(int id)
        {
            return _repository.GetById(id);
        }

        public TEntity Save(TEntity entity)
        {
            Model model = (Model) (object) entity;
            if (model.Id != null)
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
