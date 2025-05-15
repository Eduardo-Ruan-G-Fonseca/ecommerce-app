using Ecommerce.Customers.Domain.Entities;

namespace Ecommerce.Customers.Domain.Repositories;

public interface IClienteRepository
{
    Task AdicionarAsync(Cliente cliente);
    Task AtualizarAsync(Cliente cliente);
    Task<Cliente?> ObterPorIdAsync(Guid id);
    Task<Cliente?> ObterPorUsuarioIdAsync(Guid usuarioId);
    Task RemoverAsync(Cliente cliente);
}
