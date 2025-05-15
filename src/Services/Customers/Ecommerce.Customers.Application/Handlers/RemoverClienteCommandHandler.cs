using Ecommerce.Customers.Application.Commands;
using Ecommerce.Customers.Domain.Repositories;
using MediatR;

namespace Ecommerce.Customers.Application.Handlers;

public class RemoverClienteCommandHandler : IRequestHandler<RemoverClienteCommand, bool>
{
    private readonly IClienteRepository _clienteRepository;

    public RemoverClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<bool> Handle(RemoverClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.ObterPorUsuarioIdAsync(request.UsuarioId);
        if (cliente == null)
            return false;

        await _clienteRepository.RemoverAsync(cliente);
        return true;
    }
}
