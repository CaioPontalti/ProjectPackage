using Bogus;
using Project.Domain.Entities.v1;
using Project.Domain.ValueObjects.Profile;

namespace CommonTestUtilities.Entities;

public class ProfileMock
{
    public static Profile CreateProfileBuilder()
    {
        return new Faker<Profile>()
            .RuleFor(a => a.Id, f => f.Random.Guid().ToString())
            .RuleFor(a => a.AccountId, f => f.Random.Guid().ToString())
            .RuleFor(a => a.Name, f => f.Person.FullName)
            .RuleFor(a => a.BirthDate, f => f.Date.Past(40, DateTime.Today.AddYears(-18)))
            .RuleFor(a => a.CellPhone, f => f.Phone.PhoneNumber())
            .RuleFor(a => a.Address, f => new Address());
    }
}