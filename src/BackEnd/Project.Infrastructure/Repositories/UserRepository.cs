using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Project.Domain.Entities.v1;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Models.v1.MongoDb;

namespace Project.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<UserMongoDb> _collection;
    private readonly IConfiguration _configuration;

    public UserRepository(IConfiguration configuration)
    {
        _configuration = configuration;

        var database = new MongoClient(_configuration["MongoSettings:Connection"])
            .GetDatabase(_configuration["MongoSettings:Database"]);

        _collection = database.GetCollection<UserMongoDb>("users");
    }

    public async Task CreateAsync(User user)
    {
        var userMongoDb = (UserMongoDb)user;
        await _collection.InsertOneAsync(userMongoDb);
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var userMongoDb = await _collection.Find(u => u.Email == email).FirstOrDefaultAsync();
        return userMongoDb is null ? null : (User)userMongoDb;
    }

    public async Task UpdateAsync(User user)
    {
        var userMongoDb = (UserMongoDb)user;
        var filter = Builders<UserMongoDb>.Filter.Eq(u => u.Id, userMongoDb.Id);
        
        await _collection.ReplaceOneAsync(filter, userMongoDb);
    }

    public async Task<User> GetByIdAsync(string id)
    {
        var userMongoDb = await _collection.Find(u => u.Id.ToString() == id).FirstOrDefaultAsync();
        return userMongoDb is null ? null : (User)userMongoDb;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _collection.Find(_ => true).ToListAsync();
        return users.Select(user => (User)user);
    }
}