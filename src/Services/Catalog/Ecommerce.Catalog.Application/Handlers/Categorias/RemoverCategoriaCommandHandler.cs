using Ecommerce.Catalog.Application.Commands.Categorias;
using Ecommerce.Catalog.Domain.Repositories;
using MediatR;

namespace Ecommerce.Catalog.Application.Handlers.Categorias;

public class RemoverCategoriaCommandHandler : IRequestHandler<RemoverCategoriaCommand, bool>
{
    private readonly ICategoriaRepository _repository;

    public RemoverCategoriaCommandHandler(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(RemoverCategoriaCommand request, CancellationToken cancellationToken)
    {
        var categoria = await _repository.ObterPorIdAsync(request.Id);
        if (categoria == null)
            return false;

        await _repository.RemoverAsync(categoria, cancellationToken);
        return true;
    }
}
