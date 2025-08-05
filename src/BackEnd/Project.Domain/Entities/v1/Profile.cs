using MongoDB.Bson;
using Project.Domain.Extensions;
using Project.Domain.ValueObjects.Profile;

namespace Project.Domain.Entities.v1;

public class Profile
{
    public string Id { get; private set; }
    public string AccountId { get; private set; }
    public string Name { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public Address Address { get; private set; }
    public string CellPhone { get; set; }

    public Profile() { }

    public Profile(ObjectId id, string accountId, string name, Address address, DateTime? birthDate, string cellPhone)
    {
        Id = id.ToString();
        AccountId = accountId;  
        Name = name;
        Address = address;
        BirthDate = birthDate;
        Address = address;
        CellPhone = cellPhone;
    }

    public static Profile Create(string accountId, string name, DateTime? birthDate, string cellPhone)
    {
        var address = Address.Create(null, null, null, null, null,null, null);
        return new Profile(ObjectId.GenerateNewId(), accountId, name, address,  birthDate, cellPhone);
    }

    public void Update(string name, DateTime? birthDate, string cellPhone, Address address)
    {
        Name = name;
        BirthDate = birthDate.NormalizeDateTimeForMongo();
        CellPhone = cellPhone;  
        Address = address;
    }
}