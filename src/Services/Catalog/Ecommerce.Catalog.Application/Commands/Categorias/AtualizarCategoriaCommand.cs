using MediatR;

namespace Ecommerce.Catalog.Application.Commands.Categorias;

public class AtualizarCategoriaCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public AtualizarCategoriaCommand(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}
