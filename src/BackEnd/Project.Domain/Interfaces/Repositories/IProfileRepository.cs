using Project.Domain.Entities.v1;

namespace Project.Domain.Interfaces.Repositories;

public interface IProfileRepository
{
    Task CreateAsync(Profile profile);
    Task<Profile> GetByAccountId(string accountId);
}