using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Identity.Infrastructure.Data;

public class EcommerceIdentityDbContext : IdentityDbContext<UsuarioIdentity, IdentityRole<Guid>, Guid>
{
    public EcommerceIdentityDbContext(DbContextOptions<EcommerceIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UsuarioIdentity>().Property(u => u.Nome).IsRequired().HasMaxLength(100);
    }
}
