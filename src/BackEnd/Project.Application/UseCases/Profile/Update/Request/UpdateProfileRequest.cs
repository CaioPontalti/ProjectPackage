using Project.Application.Resources.Messages.Profile;
using Project.Application.Resources.Request;
using Project.Domain.ValueObjects.Profile;

namespace Project.Application.UseCases.Profile.Update.Request;

public class UpdateProfileRequest : RequestBase
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public Address Address { get; set; }
    public string CellPhone { get; set; }

    public override void Validate()
    {
        if (string.IsNullOrEmpty(Id))
            Notifications.Add(ProfileMessageValidation.IdRequerid);

        if (string.IsNullOrEmpty(Name))
            Notifications.Add(ProfileMessageValidation.NameRequerid);        

        if (BirthDate is null || BirthDate >= DateTime.Now)
            Notifications.Add(ProfileMessageValidation.BirthDateInvalid);

        if (Address is null || 
            string.IsNullOrEmpty(Address.AddressDescription) ||
            Address.Number == null ||
            string.IsNullOrEmpty(Address.PostalCode) ||
            string.IsNullOrEmpty(Address.City) ||
            string.IsNullOrEmpty(Address.State) ||
            string.IsNullOrEmpty(Address.Neighborhood))
            Notifications.Add(ProfileMessageValidation.AddressInvalid);

        if (string.IsNullOrEmpty(CellPhone))
            Notifications.Add(ProfileMessageValidation.CellPhoneInvalid);
    }
}