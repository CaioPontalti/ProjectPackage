using MongoDB.Bson;
using MongoDB.Driver;
using Project.Domain.Models.v1.MongoDb;

namespace Project.Infrastructure.Filters;

public static class UserFilter
{
    public static FilterDefinition<UserMongoDb> BuilderFilder(string search)
    {
        FilterDefinition<UserMongoDb> filter;

        if (string.IsNullOrEmpty(search))
        {
            filter = Builders<UserMongoDb>.Filter.Empty;
            return filter;
        }

        filter = Builders<UserMongoDb>.Filter.Or(
                Builders<UserMongoDb>.Filter.Regex(u => u.Name, new BsonRegularExpression(search, "i")),
                Builders<UserMongoDb>.Filter.Regex(u => u.Email, new BsonRegularExpression(search, "i"))
            );

        return filter;
    }
}
