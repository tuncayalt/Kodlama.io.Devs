using Application.Features.ApplicationUsers.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ApplicationUsers.Queries.GetListApplicationUser
{
    public class GetListApplicationUserQueryHandler : IRequestHandler<GetListApplicationUserQuery, GetListApplicationUsersModel>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;

        public GetListApplicationUserQueryHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
        }

        public async Task<GetListApplicationUsersModel> Handle(GetListApplicationUserQuery request, CancellationToken cancellationToken)
        {
            var applicationUsers = await _applicationUserRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, include: a => a.Include(a => a.User));
            var getListApplicationUserModel = _mapper.Map<GetListApplicationUsersModel>(applicationUsers);
            return getListApplicationUserModel;
        }
    }
}
