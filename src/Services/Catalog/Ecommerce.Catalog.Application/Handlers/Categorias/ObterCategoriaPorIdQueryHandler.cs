using Ecommerce.Catalog.Application.Queries.Categorias;
using Ecommerce.Catalog.Domain.Entities;
using Ecommerce.Catalog.Domain.Repositories;
using MediatR;

namespace Ecommerce.Catalog.Application.Handlers.Categorias;

public class ObterCategoriaPorIdQueryHandler : IRequestHandler<ObterCategoriaPorIdQuery, Categoria?>
{
    private readonly ICategoriaRepository _repository;

    public ObterCategoriaPorIdQueryHandler(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Categoria?> Handle(ObterCategoriaPorIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.ObterPorIdAsync(request.Id);
    }
}
