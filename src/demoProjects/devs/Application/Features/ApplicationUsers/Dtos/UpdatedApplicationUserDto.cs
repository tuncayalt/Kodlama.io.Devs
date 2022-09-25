namespace Application.Features.ApplicationUsers.Dtos
{
    public class UpdatedApplicationUserDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GitHubAddress { get; set; }
    }
}
