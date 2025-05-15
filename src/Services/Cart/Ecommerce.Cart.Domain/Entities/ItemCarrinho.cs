namespace Ecommerce.Cart.Domain.Entities;

public class ItemCarrinho
{
    public Guid Id { get; set; }
    public Guid CarrinhoId { get; set; }

    public Guid ProdutoId { get; set; }
    public string NomeProduto { get; set; }
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }

    public decimal CalcularValor()
    {
        return PrecoUnitario * Quantidade;
    }
}
