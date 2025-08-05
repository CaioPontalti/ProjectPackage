namespace Project.Domain.ValueObjects.Profile;

public class Address
{
    public string PostalCode { get; set; }
    public string AddressDescription { get; set; }
    public int? Number { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public string Complement { get; set; }

    public Address() { }

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