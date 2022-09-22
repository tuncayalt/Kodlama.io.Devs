using Application.Features.Technologies.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>, ISecuredRequest
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }

        public string[] Roles => new[] { "Technology.Create" };
    }
}
