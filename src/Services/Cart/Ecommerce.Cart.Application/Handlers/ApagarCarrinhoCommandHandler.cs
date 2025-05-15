using Ecommerce.Cart.Application.Commands;
using Ecommerce.Cart.Domain.Repositories;
using MediatR;

namespace Ecommerce.Cart.Application.Handlers;

public class ApagarCarrinhoCommandHandler : IRequestHandler<ApagarCarrinhoCommand, bool>
{
    private readonly ICarrinhoRepository _carrinhoRepository;

    public ApagarCarrinhoCommandHandler(ICarrinhoRepository carrinhoRepository)
    {
        _carrinhoRepository = carrinhoRepository;
    }

    public async Task<bool> Handle(ApagarCarrinhoCommand request, CancellationToken cancellationToken)
    {
        var carrinho = await _carrinhoRepository.ObterPorClienteIdAsync(request.ClienteId);
        if (carrinho == null)
            return false;

        _carrinhoRepository.Remover(carrinho);
        return await _carrinhoRepository.CommitAsync();
    }
}
