using Project.Domain.Entities.v1;

namespace Project.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetByEmailAsync(string email);
        Task<Account> GetByIdAsync(string id);
        Task<IEnumerable<Account>> GetAllAsync(string search);
        Task CreateAsync(Account user);
        Task UpdateAsync(Account user);
    }
}
