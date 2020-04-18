using AcmeSystem.Applicative.Services;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Business.Metier.Services;
using AcmeSystem.Persistance.EntityPersistence.MockRepositories;
using System;
using System.Collections.Generic;

namespace AcmeSystem.Presentation.ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IContactRepository _contactRepository = new OracleMockContactRepository();

            IContactServices _contactServices = new ContactServicesWeb(_contactRepository);

            foreach (Contact contact in _contactServices.GetAll())
                Console.WriteLine(contact);

            Console.ReadLine();
        }
    }
}
