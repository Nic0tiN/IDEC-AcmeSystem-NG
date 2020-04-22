using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeSystem.Persistence.EntityPersistence.MockRepositories
{
    public class OracleMockContactRepository : IContactRepository
    {
        ICollection<Contact> _contacts;
        public OracleMockContactRepository()
        {
            Console.WriteLine("OracleMockContactRepository pour les contacts");
            _contacts = ContactFactory.GetFakeContacts();
        }

        public Contact Create(Contact entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Contact entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Contact Update(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
