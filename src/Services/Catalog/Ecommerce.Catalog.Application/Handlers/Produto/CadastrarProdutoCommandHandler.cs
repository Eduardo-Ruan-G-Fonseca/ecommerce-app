using Ecommerce.Catalog.Application.Commands.Produtos;
using Ecommerce.Catalog.Domain.Entities;
using Ecommerce.Catalog.Domain.Repositories;
using MediatR;

namespace Ecommerce.Catalog.Application.Handlers.Produtos;

public class CadastrarProdutoCommandHandler : IRequestHandler<CadastrarProdutoCommand, Guid?>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public CadastrarProdutoCommandHandler(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
    {
        _produtoRepository = produtoRepository;
        _categoriaRepository = categoriaRepository;
    }

    public async Task<Guid?> Handle(CadastrarProdutoCommand request, CancellationToken cancellationToken)
    {
        var categoria = await _categoriaRepository.ObterPorIdAsync(request.CategoriaId);
        if (categoria == null)
            return null;

        var produto = new Produto(request.Nome, request.Preco, request.Estoque, request.CategoriaId, request.Descricao);
        return await _produtoRepository.AdicionarAsync(produto, cancellationToken);
    }
}
