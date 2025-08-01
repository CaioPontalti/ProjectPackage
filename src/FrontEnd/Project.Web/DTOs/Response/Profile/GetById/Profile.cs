using Project.Web.DTOs.ValueObjects.Profile;

namespace Project.Web.DTOs.Response.User.GetById;

public class Profile
{
    public string Id { get; set; }
    public string AccountId { get; set; }
    public string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public Address Address { get; set; }
    public string CellPhone { get; set; }
}