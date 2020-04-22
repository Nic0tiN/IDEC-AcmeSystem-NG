using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;
using AcmeSystem.Business.Metier.Model;

namespace AcmeSystem.Business.Metier.DbContext
{
    public interface IDbContext : IDisposable
    {
        DbSet<Adresse> Adresses { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Compte> Comptes { get; set; }
        int SaveChanges();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
