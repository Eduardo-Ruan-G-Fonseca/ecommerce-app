using Ecommerce.Catalog.Application.Commands.Produtos;
using Ecommerce.Catalog.Domain.Repositories;
using MediatR;

namespace Ecommerce.Catalog.Application.Handlers.Produtos;

public class RemoverProdutoCommandHandler : IRequestHandler<RemoverProdutoCommand, bool>
{
    private readonly IProdutoRepository _repository;

    public RemoverProdutoCommandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(RemoverProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = await _repository.ObterPorIdAsync(request.Id);
        if (produto == null)
            return false;

        await _repository.RemoverAsync(produto, cancellationToken);
        return true;
    }
}
