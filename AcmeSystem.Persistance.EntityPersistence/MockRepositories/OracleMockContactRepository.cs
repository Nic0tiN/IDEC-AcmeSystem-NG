using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeSystem.Persistance.EntityPersistence.MockRepositories
{
    public class OracleMockContactRepository : IContactRepository
    {
        ICollection<Contact> _contacts;
        public OracleMockContactRepository()
        {
            Console.WriteLine("OracleMockContactRepository pour les contacts");
            _contacts = ContactFactory.GetFakeContacts();
        }

        public ICollection<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
