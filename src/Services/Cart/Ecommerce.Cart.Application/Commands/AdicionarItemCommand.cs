using MediatR;

namespace Ecommerce.Cart.Application.Commands;

public class AdicionarItemCommand : IRequest<bool>
{
    public Guid ProdutoId { get; set; }
    public string NomeProduto { get; set; }
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }

    // O UsuarioId será preenchido no controller a partir do JWT
    public Guid ClienteId { get; set; }
}
