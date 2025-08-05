namespace Project.Web.DTOs.ValueObjects.Profile;

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
}