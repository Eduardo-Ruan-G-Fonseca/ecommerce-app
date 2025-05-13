using Ecommerce.Identity.Domain.Entities;
using Ecommerce.Identity.Domain.Repositories;
using Ecommerce.Identity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Identity.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IdentityDbContext _context;

    public UsuarioRepository(IdentityDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.Endereco == email);
    }

    public async Task AdicionarAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
    }
}
