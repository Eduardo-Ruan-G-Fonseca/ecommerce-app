using Ecommerce.Catalog.Application.Commands.Categorias;
using Ecommerce.Catalog.Domain.Repositories;
using MediatR;

namespace Ecommerce.Catalog.Application.Handlers.Categorias;

public class AtualizarCategoriaCommandHandler : IRequestHandler<AtualizarCategoriaCommand, bool>
{
    private readonly ICategoriaRepository _repository;

    public AtualizarCategoriaCommandHandler(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(AtualizarCategoriaCommand request, CancellationToken cancellationToken)
    {
        var categoria = await _repository.ObterPorIdAsync(request.Id);
        if (categoria == null)
            return false;

        categoria.AtualizarNome(request.Nome);
        await _repository.AtualizarAsync(categoria, cancellationToken);
        return true;
    }
}
