using Application.Features.Auth.Commands.RegisterCommands;
using Application.Features.Auth.Commands.LoginCommands;
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
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthenticationService(IApplicationUserRepository applicationUserRepository, IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository)
        {
            _applicationUserRepository = applicationUserRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            var addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
            return addedRefreshToken;
        }

        public async Task<AccessToken> CreateAccessToken(ApplicationUser applicationUser)
        {
            var claims = _applicationUserRepository.GetClaims(applicationUser);
            var accessToken = _tokenHelper.CreateToken(applicationUser.User, claims);
            return accessToken;
        }

        public async Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return await Task.FromResult(refreshToken);
        }

        public Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            return _applicationUserRepository.GetAsync(u => u.User.Email == email, u => u.Include(a => a.User));
        }

        public Task<bool> LoginAsync(LoginCommand request, ApplicationUser existingUser)
        {
            var result = HashingHelper.VerifyPasswordHash(request.Password, existingUser.User.PasswordHash, existingUser.User.PasswordSalt);
            return Task.FromResult(result);
        }

        public async Task<ApplicationUser> RegisterAsync(RegisterCommand request)
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
