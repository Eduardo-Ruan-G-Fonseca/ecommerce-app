using Ecommerce.Customers.Domain.Entities;
using Ecommerce.Customers.Domain.Repositories;
using Ecommerce.Customers.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Customers.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ClienteDbContext _context;

    public ClienteRepository(ClienteDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task<Cliente?> ObterPorIdAsync(Guid id)
    {
        return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Cliente?> ObterPorUsuarioIdAsync(Guid usuarioId)
    {
        return await _context.Clientes.FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);
    }
    public async Task RemoverAsync(Cliente cliente)
    {
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
    }

}
