using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Identity.Application.Commands;

public class LoginUsuarioCommand : IRequest<string?>
{
    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    public string Senha { get; set; }

    public LoginUsuarioCommand(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }
}
