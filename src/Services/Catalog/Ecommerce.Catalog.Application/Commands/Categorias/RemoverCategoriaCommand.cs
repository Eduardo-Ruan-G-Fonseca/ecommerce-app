using MediatR;

namespace Ecommerce.Catalog.Application.Commands.Categorias;

public class RemoverCategoriaCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public RemoverCategoriaCommand(Guid id)
    {
        Id = id;
    }
}
