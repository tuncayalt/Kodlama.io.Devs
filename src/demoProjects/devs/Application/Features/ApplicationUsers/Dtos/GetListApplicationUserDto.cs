using Core.Security.Enums;

namespace Application.Features.ApplicationUsers.Dtos
{
    public class GetListApplicationUserDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public AuthenticatorType AuthenticatorType { get; set; }
        public string GitHubAddress { get; set; }
    }
}
