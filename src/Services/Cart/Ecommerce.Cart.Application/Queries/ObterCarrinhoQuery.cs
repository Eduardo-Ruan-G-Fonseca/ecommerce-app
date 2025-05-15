using Ecommerce.Cart.Domain.Entities;
using MediatR;

namespace Ecommerce.Cart.Application.Queries;

public class ObterCarrinhoQuery : IRequest<Carrinho?>
{
    public Guid ClienteId { get; set; }

    public ObterCarrinhoQuery(Guid clienteId)
    {
        ClienteId = clienteId;
    }
}
