using System.Collections.Generic;
using System.Linq;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Presentation.ClientWeb.Infrastructure.DbContext;

namespace AcmeSystem.Persistence.EntityPersistence.EfRepositories
{
    public class EfAdresseRepository : IAdresseRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        /**
         * Todo: Clarifier si AcmeSystemDbContext à bien sa place ici, sachant que cela crée une dépendance vers AcmeSystem.Presentation...
         */
        public EfAdresseRepository(AcmeSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public Adresse Create(Adresse entity)
        {
            entity = _context.Add(entity).Entity;

            _context.SaveChanges();

            return entity;
        }

        public bool Delete(Adresse entity)
        {
            _context.Remove(entity);

            return _context.SaveChanges() > 0;
        }

        public ICollection<Adresse> GetAll()
        {
            return _context.Set<Adresse>().ToList();
        }

        public Adresse GetById(int id)
        {
            return GetAll().FirstOrDefault(adresse => adresse.Id == id);
        }

        public Adresse Update(Adresse entity)
        {
            entity =_context.Update(entity).Entity;

            _context.SaveChanges();

            return entity;
        }
    }
}
