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
        private Microsoft.EntityFrameworkCore.DbContext _context;
        /**
         * Todo: Clarifier si AcmeSystemDbContext à bien sa place ici, sachant que cela crée une dépendance vers AcmeSystem.Presentation...
         */
        public EfContactRepository(AcmeSystemDbContext dbContext)
        {
            _context = dbContext;
            _contacts = _context.Set<Contact>().ToList();
        }

        public Contact Create(Contact entity)
        {
            _contacts.Add(entity);

            return entity;
        }

        public bool Delete(Contact entity)
        {
            _context.Remove(entity);

            return _context.SaveChanges() > 0;
        }

        public ICollection<Contact> GetAll()
        {
            return _context.Set<Contact>().ToList();
        }

        public Contact GetById(int id)
        {
            return GetAll().FirstOrDefault(contact => contact.Id == id);
        }

        public Contact Update(int id, Contact entity)
        {
            entity =_context.Update(entity).Entity;

            _context.SaveChanges();

            return entity;
        }
    }
}
