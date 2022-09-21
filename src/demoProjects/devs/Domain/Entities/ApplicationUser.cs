using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class ApplicationUser : Entity
    {
        public ApplicationUser(int id, int userId, string gitHubAddress) : this()
        {
            Id = id;
            UserId = userId;
            GitHubAddress = gitHubAddress;
        }
        public ApplicationUser()
        {

        }

        public string GitHubAddress { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
