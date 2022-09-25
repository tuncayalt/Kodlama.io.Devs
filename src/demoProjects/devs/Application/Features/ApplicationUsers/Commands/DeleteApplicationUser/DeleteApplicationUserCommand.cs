using Application.Features.ApplicationUsers.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.ApplicationUsers.Commands.DeleteApplicationUser
{
    public class DeleteApplicationUserCommand : IRequest<DeletedApplicationUserDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { "ApplicationUser.Delete" };
    }
}
