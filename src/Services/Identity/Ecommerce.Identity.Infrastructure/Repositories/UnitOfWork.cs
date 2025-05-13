using Ecommerce.Identity.Domain.Repositories;
using Ecommerce.Identity.Infrastructure.Data;

namespace Ecommerce.Identity.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IdentityDbContext _context;

    public UnitOfWork(IdentityDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
