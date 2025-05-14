using MediatR;

namespace Ecommerce.Catalog.Application.Commands.Produtos;

public class AtualizarProdutoCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }

    public AtualizarProdutoCommand(Guid id, string nome, decimal preco, int estoque, string? descricao = null)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
        Descricao = descricao;
    }
}
