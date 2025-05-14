using Ecommerce.Catalog.Domain.Entities;
using MediatR;

namespace Ecommerce.Catalog.Application.Queries.Categorias;

public class ListarCategoriasQuery : IRequest<IEnumerable<Categoria>> { }
