using System;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using Google.Apis.Services;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AcmeSystem.Persistence.EntityPersistence.ExternalRepositories
{
    class GmailContactRepository : IRepository<Contact>
    {
        private IClientService _service;

        public GmailContactRepository(IClientService service)
        {
            _service = service;
        }

        public ICollection<Contact> Get(Expression<Func<Contact, bool>> filter = null, Func<IQueryable<Contact>, IOrderedQueryable<Contact>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Contact Create(Contact entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Contact entity)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Contact> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Contact GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Contact Update(Contact entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
