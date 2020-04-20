using System.Collections.Generic;
using System.Linq;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Presentation.ClientWeb.Infrastructure.DbContext;

namespace AcmeSystem.Persistence.EntityPersistence.EfRepositories
{
    public class EfContactRepository : IContactRepository
    {
        private readonly ICollection<Contact> _contacts;

        public EfContactRepository(AcmeSystemDbContext dbContext)
        {
            _contacts = dbContext.Set<Contact>().ToList();
        }
        public Contact GetById(int id)
        {
            return GetAll().FirstOrDefault(contact => contact.Id == id);
        }

        public ICollection<Contact> GetAll()
        {
            return _contacts;
        }
    }
}
