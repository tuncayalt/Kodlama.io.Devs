using Application.Features.Auth.Models;
using MediatR;

namespace Application.Features.Auth.Commands.LoginCommands
{
    public class LoginCommand : IRequest<LoggedInModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
