namespace Project.Web.DTOs.Response.User;

public record User(string Id, string Name, string Email, string Tipo, DateTime CreatedDate, DateTime LastUpdatedDate, bool IsActive);