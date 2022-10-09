using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories
{
    public interface IOperationClaimRepository : IRepository<OperationClaim>,  IAsyncRepository<OperationClaim>
    {
    }
}
