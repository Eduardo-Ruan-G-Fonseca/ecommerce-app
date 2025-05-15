using Ecommerce.Cart.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Cart.Infrastructure.Data;

public class CarrinhoDbContext : DbContext
{
    public CarrinhoDbContext(DbContextOptions<CarrinhoDbContext> options) : base(options) { }

    public DbSet<Carrinho> Carrinhos { get; set; }
    public DbSet<ItemCarrinho> ItensCarrinho { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrinho>(entity =>
        {
            entity.ToTable("Carrinhos");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.ClienteId)
                  .IsRequired();

            entity.HasMany(c => c.Itens)
                  .WithOne()
                  .HasForeignKey(i => i.CarrinhoId);
        });

        modelBuilder.Entity<ItemCarrinho>(entity =>
        {
            entity.ToTable("ItensCarrinho");

            entity.HasKey(i => i.Id);

            entity.Property(i => i.ProdutoId)
                  .IsRequired();

            entity.Property(i => i.NomeProduto)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(i => i.PrecoUnitario)
                  .HasColumnType("decimal(18,2)")
                  .IsRequired();

            entity.Property(i => i.Quantidade)
                  .IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}
