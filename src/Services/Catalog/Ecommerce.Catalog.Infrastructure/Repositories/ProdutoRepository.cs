using Ecommerce.Catalog.Domain.Entities;
using Ecommerce.Catalog.Domain.Repositories;
using Ecommerce.Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Catalog.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly CatalogoDbContext _context;

    public ProdutoRepository(CatalogoDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AdicionarAsync(Produto produto, CancellationToken cancellationToken)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync(cancellationToken);
        return produto.Id;
    }

    public async Task AtualizarAsync(Produto produto, CancellationToken cancellationToken)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoverAsync(Produto produto, CancellationToken cancellationToken)
    {
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Produto?> ObterPorIdAsync(Guid id)
    {
        return await _context.Produtos.FindAsync(id);
    }

    public async Task<IEnumerable<Produto>> ListarTodosAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

}
