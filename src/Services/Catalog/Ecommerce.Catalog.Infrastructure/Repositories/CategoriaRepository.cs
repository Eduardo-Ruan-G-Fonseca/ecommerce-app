using Ecommerce.Catalog.Domain.Entities;
using Ecommerce.Catalog.Domain.Repositories;
using Ecommerce.Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Catalog.Infrastructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly CatalogoDbContext _context;

    public CategoriaRepository(CatalogoDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AdicionarAsync(Categoria categoria, CancellationToken cancellationToken)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync(cancellationToken);
        return categoria.Id;
    }

    public async Task<Categoria?> ObterPorIdAsync(Guid id)
    {
        return await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Categoria>> ListarTodasAsync()
    {
        return await _context.Categorias.ToListAsync();
    }

    public async Task AtualizarAsync(Categoria categoria, CancellationToken cancellationToken)
    {
        _context.Categorias.Update(categoria);
        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task RemoverAsync(Categoria categoria, CancellationToken cancellationToken)
    {
        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync(cancellationToken);
    }


}
