using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using Project.Domain.Entities.v1;

namespace Project.Domain.Models.v1.MongoDb;

public class AccountMongoDb
{
    public ObjectId Id { get; set; }

    [JsonProperty("email")]
    [BsonElement("email")]
    public string Email { get; set; }

    [JsonProperty("passwordHash")]
    [BsonElement("passwordHash")]
    public string PasswordHash { get; set; }

    [JsonProperty("role")]
    [BsonElement("role")]
    public string Role { get; set; }

    [JsonProperty("accountType")]
    [BsonElement("accountType")]
    public string AccountType { get; set; }


    [JsonProperty("createdDate")]
    [BsonElement("createdDate")]
    public DateTime CreatedDate { get; set; }

    [JsonProperty("lastUpdatedDate")]
    [BsonElement("lastUpdatedDate")]
    public DateTime LastUpdatedDate { get; set; }

    [JsonProperty("isActive")]
    [BsonElement("isActive")]
    public bool IsActive { get; set; }


    public static explicit operator AccountMongoDb(Account user)
    {
        return new AccountMongoDb
        {
            Id = new ObjectId(user.Id),
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            Role = user.Role,
            AccountType = user.AccountType,
            CreatedDate = user.CreatedDate,
            LastUpdatedDate = user.LastUpdatedDate,
            IsActive = user.IsActive
        };
    }

    public static explicit operator Account(AccountMongoDb user)
    {
        return new Account(
            user.Id, 
            user.Email, 
            user.PasswordHash, 
            user.Role,
            user.AccountType,
            user.CreatedDate, 
            user.LastUpdatedDate, 
            user.IsActive);
    }
}