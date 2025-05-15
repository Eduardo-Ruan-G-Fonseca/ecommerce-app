using Ecommerce.Customers.Application.Queries;
using Ecommerce.Customers.Domain.Entities;
using Ecommerce.Customers.Domain.Repositories;
using MediatR;

namespace Ecommerce.Customers.Application.Handlers;

public class ObterClientePorUsuarioIdQueryHandler : IRequestHandler<ObterClientePorUsuarioIdQuery, Cliente?>
{
    private readonly IClienteRepository _clienteRepository;

    public ObterClientePorUsuarioIdQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente?> Handle(ObterClientePorUsuarioIdQuery request, CancellationToken cancellationToken)
    {
        return await _clienteRepository.ObterPorUsuarioIdAsync(request.UsuarioId);
    }
}
