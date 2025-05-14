using Ecommerce.Identity.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Identity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuariosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar([FromBody] RegistrarUsuarioCommand command)
    {
        var token = await _mediator.Send(command);
        if (token == null)
            return Conflict("Usuário já existe ou falha ao registrar.");

        return Ok(new { token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUsuarioCommand command)
    {
        var token = await _mediator.Send(command);
        if (token == null)
            return Unauthorized("Credenciais inválidas.");

        return Ok(new { token });
    }
}
