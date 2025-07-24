namespace Project.Web.DTOs.Response.User;

public record User(string Id, string Name, string Email, DateTime CreatedDate, DateTime LastUpdatedDate, bool IsActive);