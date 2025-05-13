using Ecommerce.Identity.Domain.Entities;

namespace Ecommerce.Identity.Domain.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorEmailAsync(string email);
    Task AdicionarAsync(Usuario usuario);
}
