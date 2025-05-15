using Ecommerce.Customers.Application.Commands;
using Ecommerce.Customers.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.Customers.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClienteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarCliente([FromBody] CadastrarClienteCommand command)
    {
        var usuarioIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (usuarioIdClaim == null)
            return Unauthorized("Usuário não autenticado.");

        command.UsuarioId = Guid.Parse(usuarioIdClaim.Value);

        var resultado = await _mediator.Send(command);

        if (!resultado)
            return BadRequest("Não foi possível cadastrar o cliente.");

        return Ok("Cliente cadastrado com sucesso.");
    }

    [HttpGet("me")]
    public async Task<IActionResult> ObterClienteAtual()
    {
        var usuarioIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (usuarioIdClaim == null)
            return Unauthorized("Usuário não autenticado.");

        var usuarioId = Guid.Parse(usuarioIdClaim.Value);

        var cliente = await _mediator.Send(new ObterClientePorUsuarioIdQuery(usuarioId));

        if (cliente == null)
            return NotFound("Cliente não encontrado.");

        return Ok(cliente);
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarCliente([FromBody] AtualizarClienteCommand command)
    {
        var usuarioIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (usuarioIdClaim == null)
            return Unauthorized("Usuário não autenticado.");

        command.UsuarioId = Guid.Parse(usuarioIdClaim.Value);

        var sucesso = await _mediator.Send(command);

        if (!sucesso)
            return NotFound("Cliente não encontrado.");

        return Ok("Dados atualizados com sucesso.");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoverCliente()
    {
        var usuarioIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (usuarioIdClaim == null)
            return Unauthorized("Usuário não autenticado.");

        var usuarioId = Guid.Parse(usuarioIdClaim.Value);

        var resultado = await _mediator.Send(new RemoverClienteCommand(usuarioId));

        if (!resultado)
            return NotFound("Cliente não encontrado.");

        return Ok("Cliente removido com sucesso.");
    }


}
