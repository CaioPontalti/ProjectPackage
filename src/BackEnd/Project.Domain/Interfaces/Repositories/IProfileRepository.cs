using Project.Domain.Entities.v1;

namespace Project.Domain.Interfaces.Repositories;

public interface IProfileRepository
{
    Task CreateAsync(Profile profile);
    Task UpdateAsync(Profile profile);
    Task<Profile> GetByIdAsync(string id);
    Task<Profile> GetByAccountIdAsync(string accountId);
}