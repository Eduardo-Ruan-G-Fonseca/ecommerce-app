using Ecommerce.Catalog.Application.Commands.Categorias;
using Ecommerce.Catalog.Application.Queries.Categorias;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoriasController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarCategoriaCommand command)
    {
        var id = await _mediator.Send(command);
        if (id == null)
            return BadRequest("Nome inválido.");

        return CreatedAtAction(nameof(ObterPorId), new { id }, new { id });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var categoria = await _mediator.Send(new ObterCategoriaPorIdQuery(id));

        if (categoria == null)
            return NotFound();

        return Ok(categoria);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var categorias = await _mediator.Send(new ListarCategoriasQuery());
        return Ok(categorias);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(Guid id, [FromBody] string novoNome)
    {
        var sucesso = await _mediator.Send(new AtualizarCategoriaCommand(id, novoNome));
        if (!sucesso)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(Guid id)
    {
        var sucesso = await _mediator.Send(new RemoverCategoriaCommand(id));
        if (!sucesso)
            return NotFound();

        return NoContent();
    }


}
