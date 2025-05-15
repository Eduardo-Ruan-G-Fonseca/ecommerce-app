namespace Ecommerce.Cart.Domain.Entities;

public class Carrinho
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public ICollection<ItemCarrinho> Itens { get; set; } = new List<ItemCarrinho>();

    public decimal CalcularValorTotal()
    {
        return Itens.Sum(i => i.CalcularValor());
    }
}
