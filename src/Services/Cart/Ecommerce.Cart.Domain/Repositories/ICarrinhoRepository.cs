using Ecommerce.Cart.Domain.Entities;

namespace Ecommerce.Cart.Domain.Repositories;

public interface ICarrinhoRepository
{
    Task<Carrinho?> ObterPorClienteIdAsync(Guid clienteId);
    Task AdicionarAsync(Carrinho carrinho);
    Task AtualizarAsync(Carrinho carrinho);
    Task<bool> CommitAsync(); // opcional para SaveChanges centralizado
    void Remover(Carrinho carrinho);

}
