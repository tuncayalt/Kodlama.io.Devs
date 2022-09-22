using Application.Features.ApplicationUsers.Models;
using MediatR;

namespace Application.Features.ApplicationUsers.Commands.LoginApplicationUser
{
    public class LoginApplicationUserCommand : IRequest<LoggedInApplicationUserModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
