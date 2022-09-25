using Application.Features.Auth.Commands.RegisterCommands;
using Application.Features.Auth.Commands.LoginCommands;
using Application.Features.Auth.Dtos;
using Core.Security.JWT;
using Domain.Entities;

namespace Application.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<AccessToken> CreateAccessToken(ApplicationUser applicationUser);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<bool> LoginAsync(LoginCommand request, ApplicationUser existingUser);
        Task<ApplicationUser> RegisterAsync(RegisterCommand request);
    }
}
