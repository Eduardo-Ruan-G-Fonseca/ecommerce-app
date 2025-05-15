using MediatR;

namespace Ecommerce.Customers.Application.Commands;

public class CadastrarClienteCommand : IRequest<bool>
{
    public Guid UsuarioId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CpfCnpj { get; set; }
    public string Telefone { get; set; }

    public string EnderecoRua { get; set; }
    public string EnderecoNumero { get; set; }
    public string EnderecoComplemento { get; set; }
    public string EnderecoBairro { get; set; }
    public string EnderecoCidade { get; set; }
    public string EnderecoEstado { get; set; }
    public string EnderecoCep { get; set; }
}
