using Ecommerce.Catalog.Domain.Entities;

namespace Ecommerce.Catalog.Domain.Repositories;

public interface ICategoriaRepository
{
    Task<Guid> AdicionarAsync(Categoria categoria, CancellationToken cancellationToken);
    Task<Categoria?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<Categoria>> ListarTodasAsync();
    Task AtualizarAsync(Categoria categoria, CancellationToken cancellationToken);
    Task RemoverAsync(Categoria categoria, CancellationToken cancellationToken);


}
