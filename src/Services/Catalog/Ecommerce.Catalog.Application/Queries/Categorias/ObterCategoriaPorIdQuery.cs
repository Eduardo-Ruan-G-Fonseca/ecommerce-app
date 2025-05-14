using Ecommerce.Catalog.Domain.Entities;
using MediatR;

namespace Ecommerce.Catalog.Application.Queries.Categorias;

public class ObterCategoriaPorIdQuery : IRequest<Categoria?>
{
    public Guid Id { get; set; }

    public ObterCategoriaPorIdQuery(Guid id)
    {
        Id = id;
    }
}
