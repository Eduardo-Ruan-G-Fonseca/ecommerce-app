using Ecommerce.Catalog.Domain.Entities;

public class Produto
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string? Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }
    public DateTime DataCadastro { get; private set; }

    // Relacionamento com Categoria
    public Guid CategoriaId { get; private set; }
    public Categoria Categoria { get; private set; }

    protected Produto() { }

    public Produto(string nome, decimal preco, int estoque, Guid categoriaId, string? descricao = null)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
        Descricao = descricao;
        CategoriaId = categoriaId;
        DataCadastro = DateTime.UtcNow;
    }

    public void DebitarEstoque(int quantidade)
    {
        if (quantidade <= 0 || quantidade > Estoque)
            throw new InvalidOperationException("Quantidade inválida para débito");

        Estoque -= quantidade;
    }

    public void ReporEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new InvalidOperationException("Quantidade inválida para reposição");

        Estoque += quantidade;
    }
    public void Atualizar(string nome, decimal preco, int estoque, string? descricao)
    {
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
        Descricao = descricao;
    }

}
