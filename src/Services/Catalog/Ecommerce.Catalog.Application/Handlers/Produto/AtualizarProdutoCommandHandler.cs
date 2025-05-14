using Ecommerce.Catalog.Application.Commands.Produtos;
using Ecommerce.Catalog.Domain.Repositories;
using MediatR;

namespace Ecommerce.Catalog.Application.Handlers.Produtos;

public class AtualizarProdutoCommandHandler : IRequestHandler<AtualizarProdutoCommand, bool>
{
    private readonly IProdutoRepository _repository;

    public AtualizarProdutoCommandHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(AtualizarProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = await _repository.ObterPorIdAsync(request.Id);
        if (produto == null)
            return false;

        produto.Atualizar(request.Nome, request.Preco, request.Estoque, request.Descricao);
        await _repository.AtualizarAsync(produto, cancellationToken);
        return true;
    }
}
