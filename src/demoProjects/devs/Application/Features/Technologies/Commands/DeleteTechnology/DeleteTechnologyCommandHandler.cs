using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        private readonly DeleteTechnologyBusinessRules _deleteTechnologyBusinessRules;

        public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, DeleteTechnologyBusinessRules deleteTechnologyBusinessRules)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
            _deleteTechnologyBusinessRules = deleteTechnologyBusinessRules;
        }

        public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
        {
            var existingTechnology = await _technologyRepository.GetAsync(t => t.Id == request.Id);

            _deleteTechnologyBusinessRules.ShouldExist(existingTechnology);

            var deletedTechnology = await _technologyRepository.DeleteAsync(existingTechnology!);
            var deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedTechnology);
            return deletedTechnologyDto;
        }
    }
}
