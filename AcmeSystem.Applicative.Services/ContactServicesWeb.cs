using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Business.Metier.Services;
using System;
using System.Collections.Generic;

namespace AcmeSystem.Applicative.Services
{
    public class ContactServicesWeb : IService<Contact>
    {
        IContactRepository _contactRepository;

        public ContactServicesWeb(IContactRepository contactRepository)
        {
            Console.WriteLine("Services Web pour les contacts \n");
            _contactRepository = contactRepository;
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
            return _contactRepository.GetAll();
        }

        public Contact GetId(int id)
        {
            throw new NotImplementedException();
        }

        public Contact Save(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Contact Update(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
