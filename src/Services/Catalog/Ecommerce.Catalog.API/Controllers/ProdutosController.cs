using Ecommerce.Catalog.Application.Commands.Produtos;
using Ecommerce.Catalog.Application.Queries.Produtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.API.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProdutosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProdutosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarProdutoCommand command)
    {
        var id = await _mediator.Send(command);
        if (id == null)
            return BadRequest("Categoria inválida.");

        return CreatedAtAction(nameof(ObterPorId), new { id }, new { id });
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var produtos = await _mediator.Send(new ListarProdutosQuery());
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var produto = await _mediator.Send(new ObterProdutoPorIdQuery(id));
        if (produto == null)
            return NotFound();

        return Ok(produto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarProdutoCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID do produto não confere.");

        var sucesso = await _mediator.Send(command);
        return sucesso ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(Guid id)
    {
        var sucesso = await _mediator.Send(new RemoverProdutoCommand(id));
        return sucesso ? NoContent() : NotFound();
    }
}
