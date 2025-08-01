using MongoDB.Bson;
using MongoDB.Driver;
using Project.Domain.Models.v1.MongoDb;

namespace Project.Infrastructure.Filters;

public static class AccountFilter
{
    public static FilterDefinition<AccountMongoDb> BuilderFilder(string search)
    {
        FilterDefinition<AccountMongoDb> filter;

        if (string.IsNullOrEmpty(search))
        {
            filter = Builders<AccountMongoDb>.Filter.Empty;
            return filter;
        }

        filter = Builders<AccountMongoDb>.Filter.Or(
                Builders<AccountMongoDb>.Filter.Regex(u => u.Email, new BsonRegularExpression(search, "i"))
            );

        return filter;
    }
}
