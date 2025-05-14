using Ecommerce.Catalog.Application.Queries.Categorias;
using Ecommerce.Catalog.Domain.Entities;
using Ecommerce.Catalog.Domain.Repositories;
using MediatR;

namespace Ecommerce.Catalog.Application.Handlers.Categorias;

public class ListarCategoriasQueryHandler : IRequestHandler<ListarCategoriasQuery, IEnumerable<Categoria>>
{
    private readonly ICategoriaRepository _repository;

    public ListarCategoriasQueryHandler(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Categoria>> Handle(ListarCategoriasQuery request, CancellationToken cancellationToken)
    {
        return await _repository.ListarTodasAsync();
    }
}
