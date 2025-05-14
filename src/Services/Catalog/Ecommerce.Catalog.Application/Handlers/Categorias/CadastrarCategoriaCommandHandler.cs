using Ecommerce.Catalog.Application.Commands.Categorias;
using Ecommerce.Catalog.Domain.Entities;
using Ecommerce.Catalog.Domain.Repositories;
using MediatR;

namespace Ecommerce.Catalog.Application.Handlers.Categorais;

public class CadastrarCategoriaCommandHandler : IRequestHandler<CadastrarCategoriaCommand, Guid?>
{
    private readonly ICategoriaRepository _repository;

    public CadastrarCategoriaCommandHandler(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid?> Handle(CadastrarCategoriaCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Nome))
            return null;

        var categoria = new Categoria(request.Nome);
        return await _repository.AdicionarAsync(categoria, cancellationToken);
    }
}
