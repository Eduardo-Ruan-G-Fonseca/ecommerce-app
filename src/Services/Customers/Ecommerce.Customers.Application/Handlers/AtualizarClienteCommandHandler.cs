using Ecommerce.Customers.Domain.Repositories;
using Ecommerce.Customers.Application.Commands;
using MediatR;

namespace Ecommerce.Customers.Application.Handlers;

public class AtualizarClienteCommandHandler : IRequestHandler<AtualizarClienteCommand, bool>
{
    private readonly IClienteRepository _clienteRepository;

    public AtualizarClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<bool> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.ObterPorUsuarioIdAsync(request.UsuarioId);

        if (cliente == null)
            return false;

        cliente.Nome = request.Nome;
        cliente.Email = request.Email;
        cliente.CpfCnpj = request.CpfCnpj;
        cliente.Telefone = request.Telefone;
        cliente.EnderecoRua = request.EnderecoRua;
        cliente.EnderecoNumero = request.EnderecoNumero;
        cliente.EnderecoComplemento = request.EnderecoComplemento;
        cliente.EnderecoBairro = request.EnderecoBairro;
        cliente.EnderecoCidade = request.EnderecoCidade;
        cliente.EnderecoEstado = request.EnderecoEstado;
        cliente.EnderecoCep = request.EnderecoCep;

        await _clienteRepository.AtualizarAsync(cliente);
        return true;
    }
}
