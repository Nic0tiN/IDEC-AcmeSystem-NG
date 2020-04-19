using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Business.Metier.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeSystem.Applicative.Services
{
    public class ContactServices : IContactServices
    {
        IContactRepository _contactRepository;

        public ContactServices(IContactRepository contactRepository)
        {
            Console.WriteLine("Services Normaux pour les contacts \n");
            _contactRepository = contactRepository;
        }

        public ICollection<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }
    }
}
