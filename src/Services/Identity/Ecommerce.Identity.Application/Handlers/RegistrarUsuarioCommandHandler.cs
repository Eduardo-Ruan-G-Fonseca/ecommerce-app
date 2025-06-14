﻿using Ecommerce.Identity.Application.Commands;
using Ecommerce.Identity.Application.Services;
using Ecommerce.Core.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Identity.Application.Handlers;

public class RegistrarUsuarioCommandHandler : IRequestHandler<RegistrarUsuarioCommand, string?>
{
    private readonly UserManager<UsuarioIdentity> _userManager;
    private readonly TokenService _tokenService;

    public RegistrarUsuarioCommandHandler(
        UserManager<UsuarioIdentity> userManager,
        TokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<string?> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var existente = await _userManager.FindByEmailAsync(request.Email);
        if (existente != null)
            return null;

        var usuario = new UsuarioIdentity
        {
            UserName = request.Email,
            Email = request.Email,
            Nome = request.Nome
        };

        var resultado = await _userManager.CreateAsync(usuario, request.Senha);
        if (!resultado.Succeeded)
            return null;

        return _tokenService.GerarToken(usuario);
    }
}
