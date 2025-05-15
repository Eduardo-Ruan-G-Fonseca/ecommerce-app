using Ecommerce.Cart.Application.Commands;
using Ecommerce.Cart.Domain.Repositories;
using MediatR;

namespace Ecommerce.Cart.Application.Handlers;

public class RemoverItemCommandHandler : IRequestHandler<RemoverItemCommand, bool>
{
    private readonly ICarrinhoRepository _carrinhoRepository;

    public RemoverItemCommandHandler(ICarrinhoRepository carrinhoRepository)
    {
        _carrinhoRepository = carrinhoRepository;
    }

    public async Task<bool> Handle(RemoverItemCommand request, CancellationToken cancellationToken)
    {
        var carrinho = await _carrinhoRepository.ObterPorClienteIdAsync(request.ClienteId);

        if (carrinho == null)
            return false;

        var item = carrinho.Itens.FirstOrDefault(i => i.ProdutoId == request.ProdutoId);
        if (item == null)
            return false;

        carrinho.Itens.Remove(item);
        await _carrinhoRepository.AtualizarAsync(carrinho);

        return await _carrinhoRepository.CommitAsync();
    }
}
