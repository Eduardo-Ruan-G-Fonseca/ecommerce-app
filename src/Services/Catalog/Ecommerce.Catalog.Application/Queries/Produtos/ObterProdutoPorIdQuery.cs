using Ecommerce.Catalog.Domain.Entities;
using MediatR;

namespace Ecommerce.Catalog.Application.Queries.Produtos;

public class ObterProdutoPorIdQuery : IRequest<Produto?>
{
    public Guid Id { get; set; }

    public ObterProdutoPorIdQuery(Guid id)
    {
        Id = id;
    }
}
