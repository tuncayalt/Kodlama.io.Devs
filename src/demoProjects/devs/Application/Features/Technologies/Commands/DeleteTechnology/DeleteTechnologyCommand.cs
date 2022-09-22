using Application.Features.Technologies.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { "Technology.Delete" };
    }
}
