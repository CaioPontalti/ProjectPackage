namespace Project.Web.DTOs.Response.User.GetAll;

public record User(string Id, string Name, string Email, string Role, DateTime CreatedDate, DateTime LastUpdatedDate, bool IsActive);