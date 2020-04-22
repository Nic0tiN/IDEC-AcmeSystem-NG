using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Business.Metier.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeSystem.Applicative.Services
{
    public class CompteServices : ICompteServices
    {
        ICompteRepository _compteRepository;

        public CompteServices(ICompteRepository compteRepository)
        {
            Console.WriteLine("Services Normaux pour les comptes \n");
            _compteRepository = compteRepository;
        }

        public bool Delete(Compte entity)
        {
            return _compteRepository.Delete(entity);
        }

        public ICollection<Compte> GetAll()
        {
            return _compteRepository.GetAll();
        }

        public Compte GetId(int id)
        {
            return _compteRepository.GetById(id);
        }

        public Compte Save(Compte entity)
        {
            if (entity.Id == null)
            {
                return _compteRepository.Create(entity);
            }
            else
            {
                return _compteRepository.Update(entity);
            }
        }
    }
}
