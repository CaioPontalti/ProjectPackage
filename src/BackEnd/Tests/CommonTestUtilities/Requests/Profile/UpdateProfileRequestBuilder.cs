using Bogus;
using Project.Application.UseCases.Profile.Update.Request;
using Project.Domain.ValueObjects.Profile;

namespace CommonTestUtilities.Requests.Profile;

public static class UpdateProfileRequestBuilder
{
    public static UpdateProfileRequest BuildSuccess()
    {
        var addressFaker = new Faker<Address>("pt_BR")
            .RuleFor(a => a.PostalCode, f => f.Address.ZipCode("00000-000"))
            .RuleFor(a => a.AddressDescription, f => f.Address.FullAddress())
            .RuleFor(a => a.Neighborhood, f => f.Address.Locale)
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.State, f => f.Address.State());

        return new Faker<UpdateProfileRequest>("pt_BR")
            .RuleFor(a => a.Id, f => f.Random.Guid().ToString())
            .RuleFor(a => a.Name, f => f.Person.FullName)
            .RuleFor(a => a.BirthDate, f => f.Date.Past(30))
            .RuleFor(a => a.CellPhone, f => f.Phone.PhoneNumber("+55 ## #####-####"))
            .RuleFor(a => a.Address, f => addressFaker.Generate());
    }

    public static UpdateProfileRequest BuildIdIsEmpty()
    {
        var addressFaker = new Faker<Address>("pt_BR")
            .RuleFor(a => a.PostalCode, f => f.Address.ZipCode("00000-000"))
            .RuleFor(a => a.AddressDescription, f => f.Address.FullAddress())
            .RuleFor(a => a.Neighborhood, f => f.Address.Locale)
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.State, f => f.Address.State());

        return new Faker<UpdateProfileRequest>("pt_BR")
            .RuleFor(a => a.Id, f => string.Empty)
            .RuleFor(a => a.Name, f => f.Person.FullName)
            .RuleFor(a => a.BirthDate, f => f.Date.Past(30))
            .RuleFor(a => a.CellPhone, f => f.Phone.PhoneNumber("+55 ## #####-####"))
            .RuleFor(a => a.Address, f => addressFaker.Generate());
    }

    public static UpdateProfileRequest BuildAddressIsInvalid()
    {
        var addressFaker = new Faker<Address>("pt_BR")
            .RuleFor(a => a.AddressDescription, f => f.Address.FullAddress())
            .RuleFor(a => a.Neighborhood, f => f.Address.Locale)
            .RuleFor(a => a.State, f => f.Address.State());

        return new Faker<UpdateProfileRequest>("pt_BR")
            .RuleFor(a => a.Id, f => f.Random.Guid().ToString())
            .RuleFor(a => a.Name, f => f.Person.FullName)
            .RuleFor(a => a.BirthDate, f => f.Date.Past(30))
            .RuleFor(a => a.CellPhone, f => f.Phone.PhoneNumber("+55 ## #####-####"))
            .RuleFor(a => a.Address, f => addressFaker.Generate());
    }
}
