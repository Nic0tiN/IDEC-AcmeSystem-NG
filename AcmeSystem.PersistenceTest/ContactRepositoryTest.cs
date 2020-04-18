using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Persistance.EntityPersistence.MockRepositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeSystem.PersistenceTest
{
    public class ContactRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_get_Contact_By_Id()
        {
            IContactRepository _contactRepository = new MockContactRepository();

            var expected = "Newton_Mock";

            Assert.AreEqual(expected, _contactRepository.GetById(1).Nom);
        }
    }
}
