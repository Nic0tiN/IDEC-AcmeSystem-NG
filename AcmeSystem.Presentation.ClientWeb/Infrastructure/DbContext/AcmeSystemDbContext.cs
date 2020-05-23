using AcmeSystem.Business.Metier.DbContext;
using Microsoft.EntityFrameworkCore;
using AcmeSystem.Business.Metier.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AcmeSystem.Presentation.ClientWeb.Infrastructure.DbContext
{
    public class AcmeSystemDbContext : AcmeContext
    {
        public AcmeSystemDbContext(DbContextOptions<AcmeSystemDbContext> options) : base(options) { }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasOne(a => a.Adresse);
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Compte);
            modelBuilder.Entity<Contact>()
                .HasMany(c => c.ContactTags);
            modelBuilder.Entity<ContactTag>()
                .HasKey(ct => new {ct.ContactId, ct.TagId});
            modelBuilder.Entity<ContactTag>()
                .HasOne(ct => ct.Contact)
                .WithMany(c => c.ContactTags)
                .HasForeignKey(cdt => cdt.ContactId);
            modelBuilder.Entity<ContactTag>()
                .HasOne(ct => ct.Tag)
                .WithMany(t => t.ContactTags)
                .HasForeignKey(ct => ct.TagId);
        }
    }
}
