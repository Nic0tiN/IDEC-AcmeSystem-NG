using AcmeSystem.Business.Metier.Repositories;
using AcmeSystem.Persistence.EntityPersistence.MockRepositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Persistence.EntityPersistence.EfRepositories;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;

namespace AcmeSystem.PersistenceTest
{
    public class ContactRepositoryTest
    {
        private MockContactRepository _contactRepository;
        
        [SetUp]
        public void Setup()
        {
            _contactRepository = new MockContactRepository();
        }

        [Test]
        public void Can_get_Contact_By_Id()
        {
            var expected = "Newton_Mock";

            Assert.AreEqual(expected, _contactRepository.GetById(1).Nom);
        }

        [Test]
        public void CanCreateContact()
        {
            
            var expected = new Contact()
            {
                Id = 101,
                Nom = "Nouveau",
                Prenom = "Contact"
            };

            var contact = _contactRepository.Create(new Contact()
            {
                Nom = expected.Nom,
                Prenom = expected.Prenom
            });
            
            Assert.AreEqual(expected.Id,contact.Id );
            Assert.AreEqual(expected.Nom, contact.Nom);
            Assert.AreEqual(13, _contactRepository.GetAll().Count);
        }

        [Test]
        public void CanUpdateContact()
        {
            var expected = "Updated Contact ";
            Assert.AreEqual(expected, _contactRepository.Update(1, new Contact() { Nom = "Contact", Prenom = "Updated"} ).ToString());
            Assert.AreEqual(12, _contactRepository.GetAll().Count);
        }

        [Test]
        public void CanDeleteContact()
        {
            var contact = _contactRepository.GetById(1);
            Assert.True(_contactRepository.Delete(contact));
            Assert.AreEqual(11, _contactRepository.GetAll().Count);
        }
    }
}
