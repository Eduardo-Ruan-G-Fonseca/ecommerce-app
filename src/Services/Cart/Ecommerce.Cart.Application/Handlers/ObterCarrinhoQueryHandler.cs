using Ecommerce.Cart.Application.Queries;
using Ecommerce.Cart.Domain.Entities;
using Ecommerce.Cart.Domain.Repositories;
using MediatR;

namespace Ecommerce.Cart.Application.Handlers;

public class ObterCarrinhoQueryHandler : IRequestHandler<ObterCarrinhoQuery, Carrinho?>
{
    private readonly ICarrinhoRepository _carrinhoRepository;

    public ObterCarrinhoQueryHandler(ICarrinhoRepository carrinhoRepository)
    {
        _carrinhoRepository = carrinhoRepository;
    }

    public async Task<Carrinho?> Handle(ObterCarrinhoQuery request, CancellationToken cancellationToken)
    {
        return await _carrinhoRepository.ObterPorClienteIdAsync(request.ClienteId);
    }
}