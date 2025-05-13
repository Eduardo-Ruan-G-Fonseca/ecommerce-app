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
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var token = await _mediator.Send(command);

        if (token == null)
            return Conflict("Já existe um usuário com este e-mail.");

        return Ok(new { token });
    }
}
