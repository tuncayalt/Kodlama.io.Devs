using Application.Features.ApplicationUsers.Dtos;
using Core.Security.JWT;

namespace Application.Features.ApplicationUsers.Models
{
    public class CreatedApplicationUserModel
    {
        public CreatedApplicationUserDto ApplicationUser { get; set; }
        public AccessToken AccessToken { get; set; }
    }
}
