using Application.Features.ApplicationUsers.Commands.CreateApplicationUser;
using Application.Features.ApplicationUsers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;

        public AuthenticationService(IApplicationUserRepository applicationUserRepository, IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper)
        {
            _applicationUserRepository = applicationUserRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> CreateAccessToken(ApplicationUser applicationUser)
        {
            var claims = _applicationUserRepository.GetClaims(applicationUser);
            var accessToken = _tokenHelper.CreateToken(applicationUser.User, claims);
            return accessToken;
        }

        public Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            return _applicationUserRepository.GetAsync(u => u.User.Email == email, u => u.Include(a => a.User));
        }

        public async Task<ApplicationUser> RegisterAsync(CreateApplicationUserCommand request)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            var appUser = _mapper.Map<ApplicationUser>(request);
            appUser.User = _mapper.Map<User>(request);
            appUser.User.PasswordHash = passwordHash;
            appUser.User.PasswordSalt = passwordSalt;
            appUser.User.Status = true;

            var createdUser = await _userRepository.AddAsync(appUser.User);
            appUser.UserId = createdUser.Id;
            var createdAppUser = await _applicationUserRepository.AddAsync(appUser);
            
            return createdAppUser;
        }
    }
}
