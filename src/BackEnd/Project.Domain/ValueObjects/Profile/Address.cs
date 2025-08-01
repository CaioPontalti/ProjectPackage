using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project.Domain.ValueObjects.Profile;

public class Address
{
    public string PostalCode { get; private set; }
    public string AddressDescription { get; private set; }
    public int? Number { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Neighborhood { get; private set; }
    public string Complement { get; private set; }

    public static Address Create(string postalCode, string addressDescription, int? number, string state, string city, string neighborhood, string complement)
    {
        return new Address
        {
            PostalCode = postalCode,
            AddressDescription = addressDescription,
            Number = number,
            State = state,
            City = city,
            Neighborhood = neighborhood,
            Complement = complement
        };
    }
}
