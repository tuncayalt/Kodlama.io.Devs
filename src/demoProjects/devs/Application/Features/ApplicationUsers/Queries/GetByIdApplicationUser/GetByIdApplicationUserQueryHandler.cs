using Application.Features.ApplicationUsers.Dtos;
using Application.Features.ApplicationUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ApplicationUsers.Queries.GetByIdApplicationUser
{
    public class GetByIdApplicationUserQueryHandler : IRequestHandler<GetByIdApplicationUserQuery, GetByIdApplicationUserDto>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;
        private readonly GetByIdApplicationUserBusinessRules _getByIdApplicationUserBusinessRules;

        public GetByIdApplicationUserQueryHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper, GetByIdApplicationUserBusinessRules getByIdApplicationUserBusinessRules)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
            _getByIdApplicationUserBusinessRules = getByIdApplicationUserBusinessRules;
        }

        public async Task<GetByIdApplicationUserDto> Handle(GetByIdApplicationUserQuery request, CancellationToken cancellationToken)
        {
            var existingApplicationUser = await _applicationUserRepository.GetAsync(l => l.Id == request.Id, a => a.Include(a => a.User));
            _getByIdApplicationUserBusinessRules.ShouldExist(existingApplicationUser);

            var getByIdApplicationUserDto = _mapper.Map<GetByIdApplicationUserDto>(existingApplicationUser);
            return getByIdApplicationUserDto;
        }
    }
}
