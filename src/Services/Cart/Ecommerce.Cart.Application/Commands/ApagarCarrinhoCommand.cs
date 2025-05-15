using MediatR;

namespace Ecommerce.Cart.Application.Commands;

public class ApagarCarrinhoCommand : IRequest<bool>
{
    public Guid ClienteId { get; set; }

    public ApagarCarrinhoCommand(Guid clienteId)
    {
        ClienteId = clienteId;
    }
}
