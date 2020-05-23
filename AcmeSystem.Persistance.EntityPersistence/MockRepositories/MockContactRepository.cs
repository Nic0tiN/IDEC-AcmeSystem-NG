using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AcmeSystem.Infrastructure.Helpers;

namespace AcmeSystem.Persistence.EntityPersistence.MockRepositories
{
    public class MockContactRepository : IRepository<Contact>
    {
        ICollection<Contact> _contacts;
        public MockContactRepository()
        {
            Console.WriteLine("MockRepository pour les contacts ");
            _contacts = ContactFactory.GetFakeContacts();
        }

        public ICollection<Contact> Get(Expression<Func<Contact, bool>> filter = null, Func<IQueryable<Contact>, IOrderedQueryable<Contact>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Contact Create(Contact contact)
        {
            contact.Id = IdContactGenerator.GetNext();

            _contacts.Add(contact);

            return contact;
        }

        public ICollection<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact GetById(int id)
        {
            foreach (var contact in GetAll())
                if (contact.Id == id)
                    return contact;
            
            return null;
        }

        public Contact Update(Contact contact)
        {
            return contact;
        }

        public bool Delete(Contact contact)
        {
            return _contacts.Remove(contact);
        }
    }
}
