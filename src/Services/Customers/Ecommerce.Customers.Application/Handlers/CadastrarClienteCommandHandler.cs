using Ecommerce.Customers.Application.Commands;
using Ecommerce.Customers.Domain.Entities;
using Ecommerce.Customers.Domain.Repositories;
using MediatR;

namespace Ecommerce.Customers.Application.Handlers;

public class CadastrarClienteCommandHandler : IRequestHandler<CadastrarClienteCommand, bool>
{
    private readonly IClienteRepository _clienteRepository;

    public CadastrarClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<bool> Handle(CadastrarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = new Cliente
        {
            Id = Guid.NewGuid(),
            UsuarioId = request.UsuarioId,
            Nome = request.Nome,
            Email = request.Email,
            CpfCnpj = request.CpfCnpj,
            Telefone = request.Telefone,
            EnderecoRua = request.EnderecoRua,
            EnderecoNumero = request.EnderecoNumero,
            EnderecoComplemento = request.EnderecoComplemento,
            EnderecoBairro = request.EnderecoBairro,
            EnderecoCidade = request.EnderecoCidade,
            EnderecoEstado = request.EnderecoEstado,
            EnderecoCep = request.EnderecoCep,
            CriadoEm = DateTime.UtcNow
        };

        await _clienteRepository.AdicionarAsync(cliente);
        return true;
    }
}
