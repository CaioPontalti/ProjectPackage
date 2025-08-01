using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Project.Domain.Entities.v1;
using Project.Domain.ValueObjects.Profile;

namespace Project.Domain.Models.v1.MongoDb;

public class ProfileMongoDb
{
    public ObjectId Id { get; set; }

    [JsonProperty("accountId")]
    [BsonElement("accountId")]
    public string AccountId { get; set; }

    [JsonProperty("name")]
    [BsonElement("name")]
    public string Name { get; set; }

    [JsonProperty("birthDate")]
    [BsonElement("birthDate")]
    public DateTime? BirthDate { get; set; }

    [JsonProperty("address")]
    [BsonElement("address")]
    public Address Address { get; set; }

    [JsonProperty("cellPhone")]
    [BsonElement("cellPhone")]
    public string CellPhone { get; set; }

    public static explicit operator ProfileMongoDb(Profile profile)
    {
        return new ProfileMongoDb
        {
            Id = new ObjectId(profile.Id),
            AccountId = profile.AccountId,
            Name = profile.Name,
            BirthDate = profile.BirthDate,
            Address = profile.Address,
            CellPhone = profile.CellPhone
        };
    }

    public static explicit operator Profile(ProfileMongoDb profileMongoDb)
    {
        return new Profile(profileMongoDb.Id, 
                           profileMongoDb.AccountId, 
                           profileMongoDb.Name, 
                           profileMongoDb.Address, 
                           profileMongoDb.BirthDate, 
                           profileMongoDb.CellPhone); 
    }
}