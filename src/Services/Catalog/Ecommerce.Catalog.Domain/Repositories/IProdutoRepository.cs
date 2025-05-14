using Ecommerce.Catalog.Domain.Entities;

namespace Ecommerce.Catalog.Domain.Repositories;

public interface IProdutoRepository
{
    Task<Guid> AdicionarAsync(Produto produto, CancellationToken cancellationToken);
    Task AtualizarAsync(Produto produto, CancellationToken cancellationToken);
    Task RemoverAsync(Produto produto, CancellationToken cancellationToken);
    Task<Produto?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<Produto>> ListarTodosAsync();

}
