using Ecommerce.Identity.Domain.ValueObjects;

namespace Ecommerce.Identity.Domain.Entities;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public Senha Senha { get; private set; }
    public DateTime DataCadastro { get; private set; }

    protected Usuario() { } // para o EF Core

    public Usuario(string nome, Email email, Senha senha)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        Senha = senha;
        DataCadastro = DateTime.UtcNow;
    }
}
