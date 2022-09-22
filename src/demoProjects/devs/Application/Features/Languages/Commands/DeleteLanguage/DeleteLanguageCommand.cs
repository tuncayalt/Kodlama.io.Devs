using Application.Features.Languages.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<DeletedLanguageDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { "Language.Delete" };
    }
}
