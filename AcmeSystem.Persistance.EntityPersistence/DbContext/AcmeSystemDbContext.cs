using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcmeSystem.Business.Metier.Model;

namespace AcmeSystem.Presentation.ClientWeb.Infrastructure.DbContext
{
    public class AcmeSystemDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AcmeSystemDbContext(DbContextOptions<AcmeSystemDbContext> options) : base(options) { }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
