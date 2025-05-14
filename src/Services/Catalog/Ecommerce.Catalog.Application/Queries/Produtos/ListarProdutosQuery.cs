using Ecommerce.Catalog.Domain.Entities;
using MediatR;

namespace Ecommerce.Catalog.Application.Queries.Produtos;

public class ListarProdutosQuery : IRequest<IEnumerable<Produto>> { }
