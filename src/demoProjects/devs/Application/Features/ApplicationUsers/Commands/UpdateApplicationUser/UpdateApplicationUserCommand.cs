using Application.Features.ApplicationUsers.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.ApplicationUsers.Commands.UpdateApplicationUser
{
    public class UpdateApplicationUserCommand : IRequest<UpdatedApplicationUserDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GitHubAddress { get; set; }

        public string[] Roles => new[] { "ApplicationUser.Update" };
    }
}
