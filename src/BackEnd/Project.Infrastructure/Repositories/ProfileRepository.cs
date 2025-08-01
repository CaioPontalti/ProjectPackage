using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Project.Domain.Entities.v1;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Models.v1.MongoDb;

namespace Project.Infrastructure.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly IMongoCollection<ProfileMongoDb> _collection;
    private readonly IConfiguration _configuration;

    public ProfileRepository(IConfiguration configuration)
    {
        _configuration = configuration;

        var database = new MongoClient(_configuration["MongoSettings:Connection"])
            .GetDatabase(_configuration["MongoSettings:Database"]);

        _collection = database.GetCollection<ProfileMongoDb>("profiles");
    }

    public async Task CreateAsync(Profile profile)
    {
        var profileMongoDb = (ProfileMongoDb)profile;
        await _collection.InsertOneAsync(profileMongoDb);
    }

    public async Task<Profile> GetByAccountId(string accountId)
    {
        var profileMongoDb = await _collection.Find(p => p.AccountId == accountId).FirstOrDefaultAsync();
        return profileMongoDb is null ? null : (Profile)profileMongoDb;
    }
}
