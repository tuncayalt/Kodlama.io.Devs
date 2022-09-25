using Application.Features.ApplicationUsers.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.ApplicationUsers.Models
{
    public class GetListApplicationUsersModel : BasePageableModel
    {
        public IList<GetListApplicationUserDto> Items { get; set; }
    }
}