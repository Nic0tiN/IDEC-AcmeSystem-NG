using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Business.Metier.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeSystem.Applicative.Services
{
    public class ContactServicesWeb : IContactServices
    {
        IContactRepository _contactRepository;

        public ContactServicesWeb(IContactRepository contactRepository)
        {
            Console.WriteLine("Services Web pour les contacts \n");
            _contactRepository = contactRepository;
        }
        public ICollection<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }
    }
}
