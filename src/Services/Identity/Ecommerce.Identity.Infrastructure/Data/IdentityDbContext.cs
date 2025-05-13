using Ecommerce.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Identity.Infrastructure.Data;


public class IdentityDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuarios");
            entity.HasKey(u => u.Id);

            entity.OwnsOne(u => u.Email)
                  .Property(e => e.Endereco)
                  .HasColumnName("Email")
                  .IsRequired();

            entity.OwnsOne(u => u.Senha)
                  .Property(s => s.ValorHash)
                  .HasColumnName("SenhaHash")
                  .IsRequired();
        });
    }
}
