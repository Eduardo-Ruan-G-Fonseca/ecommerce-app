using Ecommerce.Catalog.Application.Queries.Produtos;
using Ecommerce.Catalog.Domain.Entities;
using Ecommerce.Catalog.Domain.Repositories;
using MediatR;

namespace Ecommerce.Catalog.Application.Handlers.Produtos;

public class ObterProdutoPorIdQueryHandler : IRequestHandler<ObterProdutoPorIdQuery, Produto?>
{
    private readonly IProdutoRepository _repository;

    public ObterProdutoPorIdQueryHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Produto?> Handle(ObterProdutoPorIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.ObterPorIdAsync(request.Id);
    }
}
