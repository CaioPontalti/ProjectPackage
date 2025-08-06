using MongoDB.Bson;
using MongoDB.Driver;
using Project.Domain.Models.v1.MongoDb;

namespace Project.Infrastructure.Filters;

public static class ProfileFilter
{
    public static FilterDefinition<ProfileMongoDb> GetByIdBuilderFilder(string id)
        => Builders<ProfileMongoDb>.Filter.Eq(p => p.Id, new ObjectId(id));
}