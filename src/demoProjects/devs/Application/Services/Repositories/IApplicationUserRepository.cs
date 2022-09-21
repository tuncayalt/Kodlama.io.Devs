using Application.Features.ApplicationUsers.Dtos;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>, IAsyncRepository<ApplicationUser>
    {
        IList<OperationClaim> GetClaims(ApplicationUser applicationUser);
    }
}
