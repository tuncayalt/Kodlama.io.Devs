namespace Application.Features.ApplicationUsers.Dtos
{
    public class DeletedApplicationUserDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GitHubAddress { get; set; }
    }
}
