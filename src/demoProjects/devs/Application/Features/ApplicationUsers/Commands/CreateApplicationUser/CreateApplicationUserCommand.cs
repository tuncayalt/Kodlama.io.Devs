using Application.Features.ApplicationUsers.Models;
using MediatR;

namespace Application.Features.ApplicationUsers.Commands.CreateApplicationUser
{
    public class CreateApplicationUserCommand : IRequest<CreatedApplicationUserModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GitHubAddress { get; set; }
    }
}
