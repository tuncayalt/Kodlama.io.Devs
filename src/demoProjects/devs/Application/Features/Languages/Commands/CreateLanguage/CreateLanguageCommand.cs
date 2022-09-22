using Application.Features.Languages.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommand : IRequest<CreatedLanguageDto>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles => new[] { "Language.Add" };
    }
}
