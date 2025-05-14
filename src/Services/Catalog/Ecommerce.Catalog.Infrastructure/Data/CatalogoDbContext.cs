using Ecommerce.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Catalog.Infrastructure.Data;

public class CatalogoDbContext : DbContext
{
    public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Categoria
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("Categorias");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.DataCadastro)
                .IsRequired();

            // Relacionamento 1:N
            entity.HasMany(c => c.Produtos)
                  .WithOne(p => p.Categoria)
                  .HasForeignKey(p => p.CategoriaId);
        });

        // Produto
        modelBuilder.Entity<Produto>(entity =>
        {
            entity.ToTable("Produtos");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Descricao)
                .HasMaxLength(1000);

            entity.Property(p => p.Preco)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.Property(p => p.Estoque)
                .IsRequired();

            entity.Property(p => p.DataCadastro)
                .IsRequired();

            entity.Property(p => p.CategoriaId)
                .IsRequired();
        });
    }
}
