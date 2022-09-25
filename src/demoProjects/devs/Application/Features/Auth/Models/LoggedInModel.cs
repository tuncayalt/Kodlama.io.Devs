using Application.Features.Auth.Dtos;
using Core.Security.JWT;

namespace Application.Features.Auth.Models
{
    public class LoggedInModel
    {
        public LoggedInDto ApplicationUser { get; set; }
        public AccessToken AccessToken { get; set; }
    }
}
