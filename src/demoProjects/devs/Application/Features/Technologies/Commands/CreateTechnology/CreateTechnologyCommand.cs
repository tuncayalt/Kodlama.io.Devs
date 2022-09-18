using Application.Features.Technologies.Dtos;
using MediatR;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }
    }
}
