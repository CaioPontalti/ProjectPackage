using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using Project.Domain.Entities.v1;

namespace Project.Domain.Models.v1.MongoDb;

public class UserMongoDb
{
    public ObjectId Id { get; set; }

    [JsonProperty("email")]
    [BsonElement("email")]
    public string Email { get; set; }

    [JsonProperty("name")]
    [BsonElement("name")]
    public string Name { get; set; }

    [JsonProperty("passwordHash")]
    [BsonElement("passwordHash")]
    public string PasswordHash { get; set; }

    [JsonProperty("createdDate")]
    [BsonElement("createdDate")]
    public DateTime CreatedDate { get; set; }

    [JsonProperty("lastUpdatedDate")]
    [BsonElement("lastUpdatedDate")]
    public DateTime LastUpdatedDate { get; set; }

    [JsonProperty("isActive")]
    [BsonElement("isActive")]
    public bool IsActive { get; set; }


    public static explicit operator UserMongoDb(User user)
    {
        return new UserMongoDb
        {
            Id = new ObjectId(user.Id),
            Email = user.Email,
            Name = user.Name,
            PasswordHash = user.PasswordHash,
            CreatedDate = user.CreatedDate,
            LastUpdatedDate = user.LastUpdatedDate,
            IsActive = user.IsActive
        };
    }

    public static explicit operator User(UserMongoDb user)
    {
        return new User(
            user.Id, 
            user.Email, 
            user.Name,
            user.PasswordHash, 
            user.CreatedDate, 
            user.LastUpdatedDate, 
            user.IsActive);
    }
}
