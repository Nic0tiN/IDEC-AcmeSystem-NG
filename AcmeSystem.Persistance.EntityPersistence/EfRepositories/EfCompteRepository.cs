using System.Collections.Generic;
using System.Linq;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Presentation.ClientWeb.Infrastructure.DbContext;

namespace AcmeSystem.Persistence.EntityPersistence.EfRepositories
{
    public class EfCompteRepository : ICompteRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        /**
         * Todo: Clarifier si AcmeSystemDbContext à bien sa place ici, sachant que cela crée une dépendance vers AcmeSystem.Presentation...
         */
        public EfCompteRepository(AcmeSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public Compte Create(Compte entity)
        {
            entity = _context.Add(entity).Entity;

            _context.SaveChanges();

            return entity;
        }

        public bool Delete(Compte entity)
        {
            _context.Remove(entity);

            return _context.SaveChanges() > 0;
        }

        public ICollection<Compte> GetAll()
        {
            return _context.Set<Compte>().ToList();
        }

        public Compte GetById(int id)
        {
            return GetAll().FirstOrDefault(compte => compte.Id == id);
        }

        public Compte Update(Compte entity)
        {
            entity =_context.Update(entity).Entity;

            _context.SaveChanges();

            return entity;
        }
    }
}
