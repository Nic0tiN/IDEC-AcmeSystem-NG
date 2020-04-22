using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Business.Metier.Services;
using System;
using System.Collections.Generic;

namespace AcmeSystem.Applicative.Services
{
    public class AdresseServices : IAdresseServices
    {
        IAdresseRepository _adresseRepository;

        public AdresseServices(IAdresseRepository adresseRepository)
        {
            Console.WriteLine("Services Normaux pour les adresses \n");
            _adresseRepository = adresseRepository;
        }

        public Adresse Save(Adresse entity)
        {
            if (entity.Id != null)
            {
                return _adresseRepository.Create(entity);
            }
            else
            {
                return _adresseRepository.Update(entity);
            }
        }

        public bool Delete(Adresse entity)
        {
            return _adresseRepository.Delete(entity);
        }

        public ICollection<Adresse> GetAll()
        {
            return _adresseRepository.GetAll();
        }

        public Adresse GetId(int id)
        {
            return _adresseRepository.GetById(id);
        }
    }
}
