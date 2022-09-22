using Application.Features.Technologies.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }

        public string[] Roles => new[] { "Technology.Update" };
    }
}
