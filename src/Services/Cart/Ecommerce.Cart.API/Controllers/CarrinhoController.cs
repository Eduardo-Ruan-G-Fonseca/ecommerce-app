using Ecommerce.Cart.Application.Commands;
using Ecommerce.Cart.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.Cart.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CarrinhoController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarrinhoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("adicionar")]
    public async Task<IActionResult> AdicionarItem([FromBody] AdicionarItemCommand command)
    {
        var clienteIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (clienteIdClaim == null)
            return Unauthorized("Token JWT inválido.");

        command.ClienteId = Guid.Parse(clienteIdClaim.Value);

        var sucesso = await _mediator.Send(command);

        if (!sucesso)
            return BadRequest("Não foi possível adicionar o item ao carrinho.");

        return Ok("Item adicionado com sucesso.");
    }

    [HttpDelete("remover-item/{produtoId}")]
    public async Task<IActionResult> RemoverItem(Guid produtoId)
    {
        var clienteIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (clienteIdClaim == null)
            return Unauthorized("Token inválido.");

        var clienteId = Guid.Parse(clienteIdClaim.Value);

        var sucesso = await _mediator.Send(new RemoverItemCommand(clienteId, produtoId));

        if (!sucesso)
            return NotFound("Item não encontrado no carrinho.");

        return Ok("Item removido com sucesso.");
    }

    [HttpGet]
    public async Task<IActionResult> ObterCarrinho()
    {
        var clienteIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (clienteIdClaim == null)
            return Unauthorized("Token inválido.");

        var clienteId = Guid.Parse(clienteIdClaim.Value);

        var carrinho = await _mediator.Send(new ObterCarrinhoQuery(clienteId));

        if (carrinho == null || !carrinho.Itens.Any())
            return NotFound("Carrinho vazio.");

        return Ok(carrinho);
    }

    [HttpDelete]
    public async Task<IActionResult> ApagarCarrinho()
    {
        var clienteIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (clienteIdClaim == null)
            return Unauthorized("Token inválido.");

        var clienteId = Guid.Parse(clienteIdClaim.Value);

        var sucesso = await _mediator.Send(new ApagarCarrinhoCommand(clienteId));

        if (!sucesso)
            return NotFound("Carrinho não encontrado.");

        return Ok("Carrinho apagado com sucesso.");
    }

}
