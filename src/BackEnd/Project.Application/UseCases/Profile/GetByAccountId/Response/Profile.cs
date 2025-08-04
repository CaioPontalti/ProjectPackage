using Project.Domain.ValueObjects.Profile;

namespace Project.Application.UseCases.Profile.GetById.Response;

public class Profile
{
    public string Id { get; set; }
    public string AccountId { get; set; }
    public string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public Address Address { get; set; }
    public string CellPhone { get; set; }

    public static explicit operator Profile(Domain.Entities.v1.Profile profile)
    {
        return new Profile
        {
            Id = profile.Id,
            AccountId = profile.AccountId,
            Name = profile.Name,
            BirthDate = profile.BirthDate,
            Address = profile.Address,
            CellPhone = profile.CellPhone
        };
    }
}