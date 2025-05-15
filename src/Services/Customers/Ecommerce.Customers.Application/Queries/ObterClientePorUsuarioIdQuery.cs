using Ecommerce.Customers.Domain.Entities;
using MediatR;

namespace Ecommerce.Customers.Application.Queries;

public class ObterClientePorUsuarioIdQuery : IRequest<Cliente?>
{
    public Guid UsuarioId { get; set; }

    public ObterClientePorUsuarioIdQuery(Guid usuarioId)
    {
        UsuarioId = usuarioId;
    }
}
