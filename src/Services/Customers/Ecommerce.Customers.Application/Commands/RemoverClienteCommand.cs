using MediatR;

namespace Ecommerce.Customers.Application.Commands;

public class RemoverClienteCommand : IRequest<bool>
{
    public Guid UsuarioId { get; set; }

    public RemoverClienteCommand(Guid usuarioId)
    {
        UsuarioId = usuarioId;
    }
}
