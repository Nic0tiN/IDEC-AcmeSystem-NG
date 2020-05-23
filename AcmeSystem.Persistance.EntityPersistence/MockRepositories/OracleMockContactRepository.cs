using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AcmeSystem.Persistence.EntityPersistence.MockRepositories
{
    public class OracleMockContactRepository : IRepository<Contact>
    {
        ICollection<Contact> _contacts;
        public OracleMockContactRepository()
        {
            Console.WriteLine("OracleMockContactRepository pour les contacts");
            _contacts = ContactFactory.GetFakeContacts();
        }

        public ICollection<Contact> Get(Expression<Func<Contact, bool>> filter = null, Func<IQueryable<Contact>, IOrderedQueryable<Contact>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
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
