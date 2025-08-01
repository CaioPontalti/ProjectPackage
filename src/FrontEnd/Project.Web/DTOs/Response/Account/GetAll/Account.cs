namespace Project.Web.DTOs.Response.User.GetAll;

public record Account(string Id, string Email, string Role, string AccountType, DateTime CreatedDate, DateTime LastUpdatedDate, bool IsActive);