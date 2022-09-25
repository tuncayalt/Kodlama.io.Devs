using Application.Features.Auth.Models;
using MediatR;

namespace Application.Features.Auth.Commands.RegisterCommands
{
    public class RegisterCommand : IRequest<RegisteredModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GitHubAddress { get; set; }
    }
}
