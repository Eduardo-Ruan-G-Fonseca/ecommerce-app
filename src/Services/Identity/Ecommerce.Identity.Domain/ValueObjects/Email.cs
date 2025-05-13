namespace Ecommerce.Identity.Domain.ValueObjects;

public class Email
{
    public string Endereco { get; private set; }

    protected Email() { }

    public Email(string endereco)
    {
        if (string.IsNullOrWhiteSpace(endereco) || !endereco.Contains("@"))
            throw new ArgumentException("Email inválido");

        Endereco = endereco.Trim().ToLower();
    }

    public override string ToString() => Endereco;
}
