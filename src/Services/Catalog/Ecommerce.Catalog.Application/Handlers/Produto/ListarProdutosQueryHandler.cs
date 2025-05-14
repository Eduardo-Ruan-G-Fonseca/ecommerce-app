using Ecommerce.Catalog.Application.Queries.Produtos;
using Ecommerce.Catalog.Domain.Entities;
using Ecommerce.Catalog.Domain.Repositories;
using MediatR;

namespace Ecommerce.Catalog.Application.Handlers.Produtos;

public class ListarProdutosQueryHandler : IRequestHandler<ListarProdutosQuery, IEnumerable<Produto>>
{
    private readonly IProdutoRepository _repository;

    public ListarProdutosQueryHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Produto>> Handle(ListarProdutosQuery request, CancellationToken cancellationToken)
    {
        return await _repository.ListarTodosAsync();
    }
}
