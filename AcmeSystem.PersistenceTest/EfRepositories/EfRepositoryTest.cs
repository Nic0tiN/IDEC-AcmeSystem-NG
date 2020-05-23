using System.Linq;
using AcmeSystem.Business.Metier.DbContext;
using AcmeSystem.Persistence.EntityPersistence.EfRepositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Presentation.ClientWeb.Infrastructure.DbContext;
using Microsoft.Extensions.Configuration;

namespace AcmeSystem.Persistence.EntityPersistenceTest.EfRepositories
{
    class EfRepositoryTest
    {
        private AcmeSystemDbContext _dbContext;
        private EfRepository<Contact> _contactRepository;
        private IConfiguration _config;

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        private void Seed()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            // Adresse
            Adresse adresse = new Adresse() {Localite = "Pasta", Npa = "4242", Numero = "24", Rue = "Plap"};
            _dbContext.Adresses.Add(adresse);

            // Comptes
            Compte compte = new Compte() {Nom = "Plap"};
            _dbContext.Comptes.Add(compte);

            // Contacts
            _dbContext.Contacts.Add(new Contact()
            {
                Adresse = new Adresse() {Localite = "Test", Npa = "2020", Numero = "42", Rue = "Plop"},
                Compte = new Compte() {Nom = "Plap"},
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
        }

        [Test]
        public void testCreate()
        {
            Assert.AreEqual(2, _dbContext.Contacts.ToList().Count);
            Assert.AreEqual(2, _dbContext.Adresses.ToList().Count);
            Assert.AreEqual(2, _dbContext.Comptes.ToList().Count);
            Contact assert = new Contact()
            {
                Adresse = new Adresse() {Localite = "Test", Npa = "2020", Numero = "42", Rue = "Plop"},
                Compte = new Compte() { Nom = "Plap" },
                Nom = "Test",
                Prenom = "Eur"
            };
            Contact contact = _contactRepository.Create(assert);

            Assert.AreEqual(assert, contact);
            Assert.AreEqual(3, _dbContext.Contacts.ToList().Count);
            Assert.AreEqual(3, _dbContext.Adresses.ToList().Count);
            Assert.AreEqual(3, _dbContext.Comptes.ToList().Count);
        }

        [Test]
        public void testUpdate()
        {
            Contact assert = _contactRepository.GetById(1);
            assert.Nom = "Valeureux";
            assert.Compte.Nom = "Incroyable";

            Assert.AreEqual(2, _dbContext.Contacts.ToList().Count);
            Assert.AreEqual(2, _dbContext.Adresses.ToList().Count);
            Assert.AreEqual(2, _dbContext.Comptes.ToList().Count);

            Contact contact = _contactRepository.Update(assert);

            Assert.AreEqual(assert, contact);
            Assert.AreEqual(2, _dbContext.Contacts.ToList().Count);
            Assert.AreEqual(2, _dbContext.Adresses.ToList().Count);
            Assert.AreEqual(2, _dbContext.Comptes.ToList().Count);
        }
        [Test]
        public void testDelete()
        {
            Assert.AreNotEqual(null, _contactRepository.GetById(1));
            
            bool assert = _contactRepository.Delete(_contactRepository.GetById(1));

            Assert.AreEqual(assert, true);
            Assert.AreEqual(null, _contactRepository.GetById(1));
        }
    }
}
