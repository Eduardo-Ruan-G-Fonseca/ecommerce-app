using Microsoft.EntityFrameworkCore;
using Ecommerce.Customers.Domain.Entities;

namespace Ecommerce.Customers.Infrastructure.Data;

public class ClienteDbContext : DbContext
{
    public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().ToTable("Clientes");
        base.OnModelCreating(modelBuilder);
    }
}
