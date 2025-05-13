using Ecommerce.Identity.Application.Commands;
using Ecommerce.Identity.Application.Services;
using Ecommerce.Identity.Domain.Entities;
using Ecommerce.Identity.Domain.Repositories;
using Ecommerce.Identity.Domain.ValueObjects;
using MediatR;

namespace Ecommerce.Identity.Application.Handlers;

public class RegistrarUsuarioCommandHandler : IRequestHandler<RegistrarUsuarioCommand, string?>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly TokenService _tokenService;

    public RegistrarUsuarioCommandHandler(
        IUsuarioRepository usuarioRepository,
        IUnitOfWork unitOfWork,
        TokenService tokenService)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
    }

    public async Task<string?> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
    {
        // Verifica se já existe um usuário com o e-mail
        var usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(request.Email);
        if (usuarioExistente != null)
            return null;

        // Criação de Value Objects
        var email = new Email(request.Email);
        var senha = new Senha(request.Senha);

        // Criação da entidade
        var usuario = new Usuario(request.Nome, email, senha);

        // Persiste no banco
        await _usuarioRepository.AdicionarAsync(usuario);
        await _unitOfWork.CommitAsync();

        // Gera o token JWT
        var token = _tokenService.GerarToken(usuario);

        return token;
    }
}
