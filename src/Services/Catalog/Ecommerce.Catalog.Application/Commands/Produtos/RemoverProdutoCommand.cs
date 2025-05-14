using MediatR;

namespace Ecommerce.Catalog.Application.Commands.Produtos;

public class RemoverProdutoCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public RemoverProdutoCommand(Guid id)
    {
        Id = id;
    }
}
