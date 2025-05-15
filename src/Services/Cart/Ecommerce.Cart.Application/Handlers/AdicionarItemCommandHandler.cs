using Ecommerce.Cart.Application.Commands;
using Ecommerce.Cart.Domain.Entities;
using Ecommerce.Cart.Domain.Repositories;
using MediatR;

namespace Ecommerce.Cart.Application.Handlers;

public class AdicionarItemCommandHandler : IRequestHandler<AdicionarItemCommand, bool>
{
    private readonly ICarrinhoRepository _carrinhoRepository;

    public AdicionarItemCommandHandler(ICarrinhoRepository carrinhoRepository)
    {
        _carrinhoRepository = carrinhoRepository;
    }

    public async Task<bool> Handle(AdicionarItemCommand request, CancellationToken cancellationToken)
    {
        var carrinho = await _carrinhoRepository.ObterPorClienteIdAsync(request.ClienteId);

        if (carrinho == null)
        {
            carrinho = new Carrinho
            {
                Id = Guid.NewGuid(),
                ClienteId = request.ClienteId,
                Itens = new List<ItemCarrinho>()
            };
        }

        var itemExistente = carrinho.Itens.FirstOrDefault(i => i.ProdutoId == request.ProdutoId);

        if (itemExistente != null)
        {
            itemExistente.Quantidade += request.Quantidade;
        }
        else
        {
            carrinho.Itens.Add(new ItemCarrinho
            {
                Id = Guid.NewGuid(),
                CarrinhoId = carrinho.Id,
                ProdutoId = request.ProdutoId,
                NomeProduto = request.NomeProduto,
                PrecoUnitario = request.PrecoUnitario,
                Quantidade = request.Quantidade
            });
        }

        if (carrinho.Id == Guid.Empty || await _carrinhoRepository.ObterPorClienteIdAsync(request.ClienteId) == null)
            await _carrinhoRepository.AdicionarAsync(carrinho);
        else
            await _carrinhoRepository.AtualizarAsync(carrinho);

        return await _carrinhoRepository.CommitAsync();
    }
}
