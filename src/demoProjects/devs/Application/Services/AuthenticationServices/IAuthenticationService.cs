using Application.Features.ApplicationUsers.Commands.CreateApplicationUser;
using Application.Features.ApplicationUsers.Commands.LoginApplicationUser;
using Application.Features.ApplicationUsers.Dtos;
using Core.Security.JWT;
using Domain.Entities;

namespace Application.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<AccessToken> CreateAccessToken(ApplicationUser applicationUser);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<bool> LoginAsync(LoginApplicationUserCommand request, ApplicationUser existingUser);
        Task<ApplicationUser> RegisterAsync(CreateApplicationUserCommand request);
    }
}
