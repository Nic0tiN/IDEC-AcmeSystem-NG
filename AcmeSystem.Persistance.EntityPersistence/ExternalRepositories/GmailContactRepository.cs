using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using Google.Apis.Services;
using System.Collections.Generic;

namespace AcmeSystem.Persistence.EntityPersistence.ExternalRepositories
{
    class GmailContactRepository : IContactRepository
    {
        private IClientService _service;

        public GmailContactRepository(IClientService service)
        {
            _service = service;
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
