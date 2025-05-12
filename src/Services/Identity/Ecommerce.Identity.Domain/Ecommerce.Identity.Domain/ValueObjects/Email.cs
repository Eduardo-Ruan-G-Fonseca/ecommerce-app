namespace Ecommerce.Identity.Domain.ValueObjects;

public class Email
{
    public string Endereco { get; private set; }

    protected Email() { }

    public Email(string endereco)
    {
        if (string.IsNullOrWhiteSpace(endereco))
            throw new ArgumentException("Email não pode ser vazio.");

        if (!endereco.Contains("@"))
            throw new ArgumentException("Email inválido.");

        Endereco = endereco.Trim().ToLower();
    }

    public override string ToString() => Endereco;
}
