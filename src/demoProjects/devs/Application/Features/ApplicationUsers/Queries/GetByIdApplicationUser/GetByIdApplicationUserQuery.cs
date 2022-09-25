using Application.Features.ApplicationUsers.Dtos;
using MediatR;

namespace Application.Features.ApplicationUsers.Queries.GetByIdApplicationUser
{
    public class GetByIdApplicationUserQuery : IRequest<GetByIdApplicationUserDto>
    {
        public int Id { get; set; }
    }
}
