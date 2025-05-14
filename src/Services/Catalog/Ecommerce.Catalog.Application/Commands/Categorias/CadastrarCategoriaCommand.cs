using MediatR;

namespace Ecommerce.Catalog.Application.Commands.Categorias;

public class CadastrarCategoriaCommand : IRequest<Guid?>
{
    public string Nome { get; set; }

    public CadastrarCategoriaCommand(string nome)
    {
        Nome = nome;
    }
}
