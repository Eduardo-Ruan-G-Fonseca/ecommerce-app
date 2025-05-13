using MediatR;

namespace Ecommerce.Identity.Application.Commands;

public class RegistrarUsuarioCommand : IRequest<string?>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }

    public RegistrarUsuarioCommand(string nome, string email, string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
    }
}

