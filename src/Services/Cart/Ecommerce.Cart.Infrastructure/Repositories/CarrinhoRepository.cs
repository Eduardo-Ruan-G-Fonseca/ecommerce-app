using Ecommerce.Cart.Domain.Entities;
using Ecommerce.Cart.Domain.Repositories;
using Ecommerce.Cart.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Cart.Infrastructure.Repositories;

public class CarrinhoRepository : ICarrinhoRepository
{
    private readonly CarrinhoDbContext _context;

    public CarrinhoRepository(CarrinhoDbContext context)
    {
        _context = context;
    }

    public async Task<Carrinho?> ObterPorClienteIdAsync(Guid clienteId)
    {
        return await _context.Carrinhos
            .Include(c => c.Itens)
            .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
    }

    public async Task AdicionarAsync(Carrinho carrinho)
    {
        await _context.Carrinhos.AddAsync(carrinho);
    }

    public async Task AtualizarAsync(Carrinho carrinho)
    {
        _context.Carrinhos.Update(carrinho);
    }

    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    public void Remover(Carrinho carrinho)
    {
        _context.Carrinhos.Remove(carrinho);
    }

}
