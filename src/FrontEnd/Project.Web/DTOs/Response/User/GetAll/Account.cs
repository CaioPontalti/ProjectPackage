namespace Project.Web.DTOs.Response.User.GetAll;

public record Account(string Id, string Name, string Email, string Role, DateTime CreatedDate, DateTime LastUpdatedDate, bool IsActive);