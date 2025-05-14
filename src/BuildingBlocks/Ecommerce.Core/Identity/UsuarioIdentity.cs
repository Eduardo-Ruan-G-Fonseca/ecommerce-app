using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Core.Identity;

public class UsuarioIdentity : IdentityUser<Guid>
{
    public string Nome { get; set; } = null!;
}
