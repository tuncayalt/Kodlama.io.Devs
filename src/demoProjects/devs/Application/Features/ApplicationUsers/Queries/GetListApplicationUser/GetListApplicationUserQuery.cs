using Application.Features.ApplicationUsers.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.ApplicationUsers.Queries.GetListApplicationUser
{
    public class GetListApplicationUserQuery : IRequest<GetListApplicationUsersModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
