using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Project.Domain.Entities.v1;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Models.v1.MongoDb;
using Project.Infrastructure.Filters;

namespace Project.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IMongoCollection<AccountMongoDb> _collection;
    private readonly IConfiguration _configuration;

    public AccountRepository(IConfiguration configuration)
    {
        _configuration = configuration;

        var database = new MongoClient(_configuration["MongoSettings:Connection"])
            .GetDatabase(_configuration["MongoSettings:Database"]);

        _collection = database.GetCollection<AccountMongoDb>("accounts");
    }

    public async Task CreateAsync(Account user)
    {
        var userMongoDb = (AccountMongoDb)user;
        await _collection.InsertOneAsync(userMongoDb);
    }

    public async Task<Account> GetByEmailAsync(string email)
    {
        var userMongoDb = await _collection.Find(u => u.Email == email).FirstOrDefaultAsync();
        return userMongoDb is null ? null : (Account)userMongoDb;
    }

    public async Task UpdateAsync(Account user)
    {
        var userMongoDb = (AccountMongoDb)user;
        var filter = Builders<AccountMongoDb>.Filter.Eq(u => u.Id, userMongoDb.Id);
        
        await _collection.ReplaceOneAsync(filter, userMongoDb);
    }

    public async Task<Account> GetByIdAsync(string id)
    {
        var userMongoDb = await _collection.Find(u => u.Id.ToString() == id).FirstOrDefaultAsync();
        return userMongoDb is null ? null : (Account)userMongoDb;
    }

    public async Task<IEnumerable<Account>> GetAllAsync(string search)
    {
        var filter = AccountFilter.BuilderFilder(search);

        var users = await _collection.Find(filter).ToListAsync();
        return users.Select(user => (Account)user);
    }
}