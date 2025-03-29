using Microsoft.EntityFrameworkCore;
using Romanel.Evaluation.domain.Entities;
using Romanel.Evaluation.Infrastructure.EventStore;

namespace Romanel.Evaluation.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<StoredEvent> StoredEvents { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nome).IsRequired().HasMaxLength(100);
                entity.Property(c => c.CPF).IsRequired().HasMaxLength(11);
                entity.Property(c => c.DataNascimento).IsRequired();
                entity.Property(c => c.Telefone).IsRequired().HasMaxLength(11);
                entity.Property(c => c.Email).IsRequired().HasMaxLength(255);
                entity.OwnsOne(c => c.Endereco, e =>
                {
                    e.Property(x => x.CEP).IsRequired().HasMaxLength(8);
                    e.Property(x => x.Logradouro).IsRequired().HasMaxLength(200);
                    e.Property(x => x.Numero).IsRequired().HasMaxLength(10);
                    e.Property(x => x.Bairro).IsRequired().HasMaxLength(100);
                    e.Property(x => x.Cidade).IsRequired().HasMaxLength(100);
                    e.Property(x => x.Estado).IsRequired().HasMaxLength(2);
                });
                entity.Ignore(c => c.DomainEvents); 
            });

            modelBuilder.Entity<StoredEvent>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Data).IsRequired();
                entity.Property(e => e.Type).IsRequired().HasMaxLength(100);
                entity.Property(e => e.OccurredOn).IsRequired();
            });
        }
    }
}
