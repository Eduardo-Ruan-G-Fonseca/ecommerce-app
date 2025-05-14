namespace Ecommerce.Catalog.Domain.Entities;

public class Categoria
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public DateTime DataCadastro { get; private set; }

    // Relacionamento: uma categoria tem muitos produtos
    public ICollection<Produto> Produtos { get; private set; }

    protected Categoria() { }

    public Categoria(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        DataCadastro = DateTime.UtcNow;
        Produtos = new List<Produto>();
    }
    public void AtualizarNome(string novoNome)
    {
        if (!string.IsNullOrWhiteSpace(novoNome))
            Nome = novoNome;
    }

}
