using Application.Features.Auth.Commands.RegisterCommands;
using Application.Features.Auth.Commands.LoginCommands;
using Application.Features.Auth.Dtos;
using Core.Security.JWT;
using Domain.Entities;
using Core.Security.Entities;

namespace Application.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
        Task<AccessToken> CreateAccessToken(ApplicationUser applicationUser);
        Task<RefreshToken> CreateRefreshToken(User createdApplicationUser, string ipAddress);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<bool> LoginAsync(LoginCommand request, ApplicationUser existingUser);
        Task<ApplicationUser> RegisterAsync(RegisterCommand request);
    }
}
