using AcmeSystem.Applicative.Services;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Persistence.EntityPersistence.EfRepositories;
using AcmeSystem.Persistence.EntityPersistence.MockRepositories;
using AcmeSystem.Presentation.ClientWeb.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace AcmeSystem.Applicative.ServicesTest
{
    class ServicesTest
    {
        private AcmeSystemDbContext _dbContext;
        private EfRepository<Contact> _contactRepository;
  //      private MockContactRepository _contactRepository;
        private Service<Contact> _service;

        private void Seed()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            // Adresse
            Adresse adresse = new Adresse() { Localite = "Pasta", Npa = "4242", Numero = "24", Rue = "Plap" };
            _dbContext.Adresses.Add(adresse);

            // Comptes
            Compte compte = new Compte() { Nom = "Plap" };
            _dbContext.Comptes.Add(compte);

            // Contacts
            _dbContext.Contacts.Add(new Contact()
            {
                Adresse = new Adresse() { Localite = "Test", Npa = "2020", Numero = "42", Rue = "Plop" },
                Compte = new Compte() { Nom = "Plap" },
                Nom = "Test",
                Prenom = "Eur"
            });
            _dbContext.Contacts.Add(new Contact()
            {
                Adresse = adresse,
                Compte = compte,
                Nom = "Test avec",
                Prenom = "Adresse"
            });

            _dbContext.SaveChanges();
        }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AcmeSystemDbContext>();
            options.UseSqlite(
                "Data Source=AcmeSystemTest.db");
            _dbContext = new AcmeSystemDbContext(options.Options);
            Seed();
            _contactRepository = new EfRepository<Contact>(_dbContext);
            _service = new Service<Contact>(_contactRepository);
        }
        [Test]
        public void GetByIdTest()
        {
            Assert.AreNotEqual(null, _service.GetId(1));
        }
        [Test]
        public void CreateTest()
        {
            var assertCount = _service.GetAll().Count + 1;
            var newContact = new Contact()
            {
                Adresse = new Adresse() {Localite = "Localite", Npa = "Npa", Numero = "Numéro", Rue = "Rue"},
                Compte = new Compte() {Nom = "Nom"},
                Nom = "Nom",
                Prenom = "Prenom"
            };

            Assert.AreEqual(newContact, _service.Create(newContact));
            Assert.AreEqual(assertCount, _service.GetAll().Count);
        }
        [Test]
        public void UpdateTest()
        {
            var assertCount = _service.GetAll().Count;
            var contact = _service.GetId(1);
            contact.Nom = "Updated";
            Assert.AreEqual(contact, _service.Update(contact));
            Assert.AreEqual("Updated", _service.GetId(1).Nom);
            Assert.AreEqual(assertCount, _service.GetAll().Count);
        }

        [Test]
        public void DeleteTest()
        {
            var assertCount = _service.GetAll().Count - 1;
            var contact = _service.GetId(1);

            Assert.AreEqual(true, _service.Delete(contact));
            Assert.AreEqual(assertCount, _service.GetAll().Count);
        }
    }
}
