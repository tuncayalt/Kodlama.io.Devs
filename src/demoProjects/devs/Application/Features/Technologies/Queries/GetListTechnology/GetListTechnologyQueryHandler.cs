using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Technologies.Queries.GetListTechnology
{
    public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, GetListTechnologyModel>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<GetListTechnologyModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
        {
            var technologies = await _technologyRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                include: t => t.Include(t => t.Language));
            var getListTechnologyModel = _mapper.Map<GetListTechnologyModel>(technologies);
            return getListTechnologyModel;
        }
    }
}
