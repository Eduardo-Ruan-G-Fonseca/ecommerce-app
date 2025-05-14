using MediatR;

namespace Ecommerce.Catalog.Application.Commands.Produtos;

public class CadastrarProdutoCommand : IRequest<Guid?>
{
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public Guid CategoriaId { get; set; }

    public CadastrarProdutoCommand(string nome, decimal preco, int estoque, Guid categoriaId, string? descricao = null)
    {
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
        CategoriaId = categoriaId;
        Descricao = descricao;
    }
}
