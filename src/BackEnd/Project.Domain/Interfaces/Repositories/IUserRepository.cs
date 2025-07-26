using Project.Domain.Entities.v1;

namespace Project.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(string id);
        Task<IEnumerable<User>> GetAllAsync(string search);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
    }
}
