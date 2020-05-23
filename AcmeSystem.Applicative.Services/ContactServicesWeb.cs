using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Business.Metier.Services;
using System;
using System.Collections.Generic;

namespace AcmeSystem.Applicative.Services
{
    public class ContactServicesWeb : IService<Contact>
    {
        IRepository<Contact> _contactRepository;

        public ContactServicesWeb(IRepository<Contact> contactRepository)
        {
            Console.WriteLine("Services Web pour les contacts \n");
            _contactRepository = contactRepository;
        }

        public Contact GetId(int id, string includes = "")
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

        public ICollection<Contact> GetAll(string includes = "")
        {
            return _contactRepository.GetAll();
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
