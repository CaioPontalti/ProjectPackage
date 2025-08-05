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

    public async Task CreateAsync(Account account)
    {
        var accountMongoDb = (AccountMongoDb)account;
        await _collection.InsertOneAsync(accountMongoDb);
    }

    public async Task<Account> GetByEmailAsync(string email)
    {
        var accountMongoDb = await _collection.Find(u => u.Email == email).FirstOrDefaultAsync();
        return accountMongoDb is null ? null : (Account)accountMongoDb;
    }

    public async Task UpdateAsync(Account account)
    {
        var accountMongoDb = (AccountMongoDb)account;
        var filter = Builders<AccountMongoDb>.Filter.Eq(u => u.Id, accountMongoDb.Id);
        
        await _collection.ReplaceOneAsync(filter, accountMongoDb);
    }

    public async Task<Account> GetByIdAsync(string id)
    {
        var accountMongoDb = await _collection.Find(u => u.Id.ToString() == id).FirstOrDefaultAsync();
        return accountMongoDb is null ? null : (Account)accountMongoDb;
    }

    public async Task<IEnumerable<Account>> GetAllAsync(string search)
    {
        var filter = AccountFilter.SearchBuilderFilder(search);

        var accounts = await _collection.Find(filter).ToListAsync();
        return accounts.Select(account => (Account)account);
    }
}