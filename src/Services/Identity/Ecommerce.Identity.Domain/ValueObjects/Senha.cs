namespace Ecommerce.Identity.Domain.ValueObjects;

public class Senha
{
    public string ValorHash { get; private set; }

    protected Senha() { }

    public Senha(string senhaPura)
    {
        if (string.IsNullOrWhiteSpace(senhaPura) || senhaPura.Length < 6)
            throw new ArgumentException("A senha deve ter no mínimo 6 caracteres.");

        ValorHash = Hash(senhaPura);
    }

    private string Hash(string input)
    {
        // Simulação simples de hash
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
    }

    public bool Verificar(string tentativa)
    {
        return Hash(tentativa) == ValorHash;
    }
}
