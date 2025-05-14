using Ecommerce.Identity.Application.Commands;
using Ecommerce.Identity.Application.Services;
using Ecommerce.Core.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Identity.Application.Handlers;

public class LoginUsuarioCommandHandler : IRequestHandler<LoginUsuarioCommand, string?>
{
    private readonly UserManager<UsuarioIdentity> _userManager;
    private readonly SignInManager<UsuarioIdentity> _signInManager;
    private readonly TokenService _tokenService;

    public LoginUsuarioCommandHandler(
        UserManager<UsuarioIdentity> userManager,
        SignInManager<UsuarioIdentity> signInManager,
        TokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<string?> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _userManager.FindByEmailAsync(request.Email);
        if (usuario == null)
            return null;

        var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, request.Senha, false);
        if (!resultado.Succeeded)
            return null;

        return _tokenService.GerarToken(usuario);
    }
}
