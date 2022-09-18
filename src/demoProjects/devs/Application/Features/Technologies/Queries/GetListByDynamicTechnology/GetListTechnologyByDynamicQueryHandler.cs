using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Technologies.Queries.GetListByDynamicTechnology
{
    public class GetListTechnologyByDynamicQueryHandler : IRequestHandler<GetListTechnologyByDynamicQuery, GetListTechnologyModel>
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyRepository _technologyRepository;

        public GetListTechnologyByDynamicQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<GetListTechnologyModel> Handle(GetListTechnologyByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Technology> technologies = await _technologyRepository.GetListByDynamicAsync(
                request.Dynamic, 
                include: t => t.Include(t => t.Language),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);

            var mappedTechnologies = _mapper.Map<GetListTechnologyModel>(technologies);
            return mappedTechnologies;
        }
    }
}
