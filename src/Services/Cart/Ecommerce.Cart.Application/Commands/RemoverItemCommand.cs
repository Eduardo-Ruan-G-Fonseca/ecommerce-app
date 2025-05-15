using MediatR;

namespace Ecommerce.Cart.Application.Commands;

public class RemoverItemCommand : IRequest<bool>
{
    public Guid ClienteId { get; set; }
    public Guid ProdutoId { get; set; }

    public RemoverItemCommand(Guid clienteId, Guid produtoId)
    {
        ClienteId = clienteId;
        ProdutoId = produtoId;
    }
}
